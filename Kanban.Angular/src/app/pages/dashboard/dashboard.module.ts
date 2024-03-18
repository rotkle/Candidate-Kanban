import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AddCardComponent } from './add-card/add-card.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { CoreModule } from '../../core/core.module';
import { EditColumnTitleComponent } from './edit-column-title/edit-column-title.component';
import { SharedModule } from '../../shared/shared.module';
import { CardItemComp } from './card-item/card-item.component';

@NgModule({
  imports: [
    CommonModule,
    CoreModule,
    DashboardRoutingModule,
    SharedModule,
  ],
  declarations: [
    DashboardComponent,
    AddCardComponent,
    EditColumnTitleComponent,
    CardItemComp,
  ]
})
export class DashboardModule { }
