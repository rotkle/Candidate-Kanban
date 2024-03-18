import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CandidateRoutingModule } from './candidate-routing.module';
import { CandidateComponent } from './candidate.component';
import { CoreModule } from '../../core/core.module';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    CoreModule,
    CandidateRoutingModule,
    SharedModule,
  ],
  declarations: [
    CandidateComponent,
  ]
})
export class CandidateModule { }
