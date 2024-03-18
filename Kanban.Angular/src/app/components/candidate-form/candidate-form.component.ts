import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TuiIdentityMatcher, TuiStringHandler } from '@taiga-ui/cdk';
import { TUI_VALIDATION_ERRORS } from '@taiga-ui/kit';

// Constants
import { ApiPaths } from 'src/app/core/constants/api-urls';

// Models
import { ICandidateForm, IItem } from 'src/app/core/models/candidate.model';

// Services
import { HttpServices } from 'src/app/core/services/http.service';
import { UtilsServices } from 'src/app/core/services/utils.service';

const numberPattern = /^(\+)?[0-9\s]+$/;

@Component({
  selector: 'candidate-form',
  templateUrl: './candidate-form.component.html',
  providers: [
    {
      provide: TUI_VALIDATION_ERRORS,
      useValue: {
        required: 'This field is required!',
        email: 'Enter a valid email',
        pattern: 'Enter a valid phone number',
      },
    },
  ],
})
export class CandidateForm {
  @Input() isAddForm: boolean = false;
  @Input() canId: number;
  @Input() statusId: number;
  @Output() onCloseModal = new EventEmitter();
  @Output() onRefresh = new EventEmitter();

  candidateForm: FormGroup;
  isLoading: boolean = false;
  isSubmitting: boolean = false;

  // fake data
  jobs: readonly IItem[] = [];
  statusList: readonly IItem[] = [];

  stringify: TuiStringHandler<IItem> = (item) => item.name;
  readonly identityMatcher: TuiIdentityMatcher<IItem> = (hero1, hero2) =>
    hero1.id === hero2.id;

  constructor(
    private router: Router,
    private httpServices: HttpServices,
    private utilsServices: UtilsServices
  ) {}

  ngOnInit() {
    this.getJobs();
    this.initForm();
  }

  ngOnChanges() {
    if (this.canId) {
      this.getStatus();
      this.getCanidate();
    }
  }

  initForm() {
    this.candidateForm = new FormGroup({
      firstName: new FormControl(
        '',
        Validators.compose([Validators.required, this.utilsServices.maxLengthValidator('First name', 100)])
      ),
      lastName: new FormControl(
        '',
        Validators.compose([Validators.required, this.utilsServices.maxLengthValidator('Last name', 100)])
      ),
      email: new FormControl(
        '',
        Validators.compose([
          Validators.required,
          Validators.email,
          this.utilsServices.maxLengthValidator('Email', 200),
        ])
      ),
      phoneNumber: new FormControl(
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern(numberPattern),
          this.utilsServices.maxLengthValidator('Phone number', 30),
        ])
      ),
      status: new FormControl(
        null,
        Validators.compose([!this.isAddForm ? Validators.required : null])
      ),
      job: new FormControl(null),
    });
  }

  // TODO: get canidate
  getCanidate() {
    this.isLoading = true;
    const urlParam = `${ApiPaths.candidates}/${this.canId}`;

    this.httpServices.get(urlParam).subscribe({
      next: (res: any) => {
        // set form value
        this.candidateForm.controls['firstName'].setValue(res?.firstName);
        this.candidateForm.controls['lastName'].setValue(res?.lastName);
        this.candidateForm.controls['email'].setValue(res?.email);
        this.candidateForm.controls['phoneNumber'].setValue(res?.phoneNumber);
        this.candidateForm.controls['status'].setValue(res?.status);
        this.candidateForm.controls['job'].setValue(res?.jobs);
      },
      error: (err) => {
        // treat error
        this.utilsServices.handleMessage(err?.error?.message, 'error');
        this.isLoading = false;
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }

  // TODO: get status
  getStatus() {
    const urlParam = ApiPaths.status;

    this.httpServices.get(urlParam).subscribe({
      next: (res: any) => {
        this.statusList = res;
      },
      error: (err: any) => {
        // treat error
        this.utilsServices.handleMessage(err?.error?.message, 'error');
      },
    });
  }

  // TODO: get canidates
  getJobs() {
    const urlParam = ApiPaths.jobs;

    this.httpServices.get(urlParam).subscribe({
      next: (res: any) => {
        this.jobs = res;
      },
      error: (err: any) => {
        // treat error
        this.utilsServices.handleMessage(err?.error?.message, 'error');
      },
    });
  }

  // TODO: submit form
  submitForm(formData: any) {
    if (this.candidateForm.valid) {
      // // show message
      const payload = {
        firstName: formData.firstName,
        lastName: formData.lastName,
        email: formData.email,
        phoneNumber: formData.phoneNumber,
        statusId: this.isAddForm ? this.statusId : formData.status.id,
        jobIds: formData?.job?.map((item: IItem) => item.id) || [],
      };
      // // case add candidate
      if (this.isAddForm) {
        this.createCandidate(payload);
      } else {
        // case update candidate
        this.updateCandidate(payload);
      }
    } else {
      for (let i in this.candidateForm.controls) {
        this.candidateForm.controls[i].markAsTouched();
      }
    }
  }

  // TODO: create candidate
  createCandidate(formdata: ICandidateForm) {
    this.isSubmitting = true;
    const urlParam = `${ApiPaths.candidates}`;

    this.httpServices.post(urlParam, formdata).subscribe({
      next: () => {
        // show message
        this.utilsServices.handleMessage(
          'Candidate added successfully!',
          'success',
          2000
        );

        setTimeout(() => {
          this.refresh();
        }, 2000);
      },
      error: (err) => {
        // treat error
        this.utilsServices.handleMessage(
          err?.error?.message || err?.error?.title,
          'error'
        );
        this.isSubmitting = false;
      },
    });
  }

  // TODO: update candidate
  updateCandidate(formdata: ICandidateForm) {
    this.isSubmitting = true;
    const urlParam = `${ApiPaths.candidates}/${this.canId}`;

    this.httpServices.put(urlParam, formdata).subscribe({
      next: () => {
        // show message
        this.utilsServices.handleMessage(
          'Candidate updated successfully!',
          'success',
          2000
        );

        setTimeout(() => {
          this.redirectDashboard();
        }, 2000);
      },
      error: (err) => {
        // treat error
        this.utilsServices.handleMessage(
          err?.error?.message || err?.error?.title,
          'error'
        );
        this.isSubmitting = false;
      },
    });
  }

  // TODO: reset form
  resetForm() {
    this.candidateForm.reset();
    if (this.isAddForm) {
      this.closeModal();
    } else {
      this.redirectDashboard();
    }
  }

  // TODO: close modal
  closeModal() {
    this.onCloseModal.emit();
  }

  // TODO: redirect to dashboard
  redirectDashboard() {
    this.router.navigate(['/']);
  }

  // TODO: refresh board
  refresh() {
    this.onRefresh.emit();
  }
}
