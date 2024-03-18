import { ChangeDetectionStrategy, Component, Input } from '@angular/core';

@Component({
  selector: 'card-item',
  templateUrl: './card-item.component.html',
  styleUrls: ['./card-item.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CardItemComp {
  @Input() item: any;
}
