import { ChangeDetectionStrategy, Component, EventEmitter, Output } from '@angular/core';
@Component({
  selector: 'app-add-card',
  templateUrl: './add-card.component.html',
  styleUrls: ['./add-card.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AddCardComponent {

  @Output() onAddCandidate = new EventEmitter<any>();

  addCandidate() {
    this.onAddCandidate.emit();
  }
}

