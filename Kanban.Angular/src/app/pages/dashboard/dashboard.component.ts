import {
  AfterViewInit,
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
} from '@angular/core';
import { DragulaService } from 'ng2-dragula';
import { Subscription } from 'rxjs';

// Models
import { IBoard } from '../../core/models/board.model';
import {
  ICandidate,
  ICandidateForm,
  IItem,
} from 'src/app/core/models/candidate.model';

// Services
import { HttpServices } from 'src/app/core/services/http.service';
import { UtilsServices } from 'src/app/core/services/utils.service';

// Constants
import { ApiPaths } from 'src/app/core/constants/api-urls';

// Used for autoscrolling
const autoScroll = require('dom-autoscroller');

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit, AfterViewInit, OnDestroy {
  subs = new Subscription();
  scollElemnts: any;

  // All elements
  columns: any;
  cards: any;

  open: boolean = false;
  isLoading: boolean = false;
  boardList: Array<any> = [];
  statusId: number;

  constructor(
    private dragulaService: DragulaService,
    private elRef: ElementRef,
    private httpServices: HttpServices,
    private utilsServices: UtilsServices
  ) {
    this.dragulaService.createGroup('COLUMNS', {
      direction: 'horizontal',
      moves: (el, container, handle: any) => {
        return handle.classList.contains('group-handle');
      },
      accepts: (el: any, target: any, source: any, sibling: any): boolean => {
        return !el.contains(target); // elements can not be dropped within themselves
      },
    });

    // Dropping cards
    this.subs.add(
      this.dragulaService.dropModel('CARDS').subscribe((args: any) => {
        const { target, source, item } = args;
        const t_dataset = target['dataset'] as DOMStringMap;
        const s_dataset = source['dataset'] as DOMStringMap;

        // just call api update if drag another column
        if (t_dataset['id'] !== s_dataset['id']) {
          const payload = {
            firstName: item.firstName,
            lastName: item.lastName,
            email: item.email,
            phoneNumber: item.phoneNumber,
            statusId: Number(t_dataset['id']),
            jobIds: item?.jobs?.map((item: IItem) => item.id) || [],
          };
  
          this.updateCandidate(payload, item.id);
        }
      })
    );
  }

  /**
   * Function to initalize scroll on the elements
   *
   * @memberof BoardDetailsComponent
   */
  initializeScroll() {
    this.columns = Array.from(
      this.elRef.nativeElement.querySelectorAll('.columns')
    );
    this.cards = Array.from(
      this.elRef.nativeElement.querySelectorAll('.cards')
    );
    // Enable autoscrolling
    this.scollElemnts = autoScroll([...this.columns, ...this.cards], {
      margin: 100,
      maxSpeed: 30,
      scrollWhenOutside: false,
      autoScroll: function () {
        // Only scroll when the pointer is down
        return this.down;
      },
    });
  }

  ngOnInit() {
    this.initData();
  }

  // init data list board
  async initData() {
    this.isLoading = true;

    try {
      const [resStatus, resCandidates] = (await Promise.allSettled([
        this.getStatus(),
        this.getCanidates(),
      ])) as { status: 'fulfilled' | 'rejected'; value: any }[];

      if (resStatus && resCandidates) {
        let newBoard = [];

        newBoard = resStatus?.value;
        newBoard.forEach((board: IBoard) => {
          board.candidates =
            resCandidates?.value.filter(
              (item: ICandidate) => item.status.id === board.id
            ) || [];
        });

        this.isLoading = false;
        this.boardList = newBoard;
      }
    } catch (error) {
      this.isLoading = false;
    }
  }

  ngAfterViewInit() {
    setTimeout(() => {
      this.initializeScroll();
    }, 500);
  }

  ngOnDestroy() {
    // Required to remove any autoscroll items else will drop frames
    if (this.scollElemnts) {
      this.scollElemnts.destroy(true);
    }
    // destroy all the subscriptions at once
    this.subs.unsubscribe();
    this.dragulaService.destroy('COLUMNS');
  }

  // TODO: get status
  getStatus() {
    const urlParam = ApiPaths.status;

    const promise = new Promise<void>((resolve, reject) => {
      this.httpServices.get(urlParam).subscribe({
        next: (res: any) => {
          resolve(res);
        },
        error: (err: any) => {
          // treat error
          this.utilsServices.handleMessage(err?.error?.message, 'error');
          reject(err);
        },
      });
    });
    return promise;
  }

  // TODO: get canidates
  getCanidates() {
    const urlParam = ApiPaths.candidates;

    const promise = new Promise<void>((resolve, reject) => {
      this.httpServices.get(urlParam).subscribe({
        next: (res: any) => {
          resolve(res);
        },
        error: (err: any) => {
          // treat error
          this.utilsServices.handleMessage(err?.error?.message, 'error');
          reject(err);
        },
      });
    });
    return promise;
  }

  // ToDO: update candidate
  updateCandidate(formdata: ICandidateForm, canId: number) {
    const urlParam = `${ApiPaths.candidates}/${canId}`;

    this.httpServices.put(urlParam, formdata).subscribe({
      next: () => {
        // show message
        this.utilsServices.handleMessage(
          'Candidate updated successfully!',
          'success',
          2000
        );
      },
      error: (err) => {
        // treat error
        this.utilsServices.handleMessage(err?.error?.message || err?.error?.title, 'error');
      },
      complete: () => {},
    });
  }

  // TODO: show modal add candidate
  showModalAddCandidate(statusId: number): void {
    this.statusId = statusId;
    this.open = true;
  }

  // TODO: close modal add candidate
  closeModalAddCandidate(): void {
    this.open = false;
  }

  // TODO: refresh board after add new candidate
  refresh() {
    this.closeModalAddCandidate();
    this.initData();
  }
}
