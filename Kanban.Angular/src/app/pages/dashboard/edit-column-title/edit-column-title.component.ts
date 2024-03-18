import { ChangeDetectionStrategy, Component, Input } from '@angular/core';

@Component({
  selector: 'app-edit-column-title',
  templateUrl: './edit-column-title.component.html',
  styleUrls: ['./edit-column-title.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EditColumnTitleComponent {
  @Input() column: any;
}
