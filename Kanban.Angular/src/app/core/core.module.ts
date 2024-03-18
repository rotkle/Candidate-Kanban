import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DragulaModule } from 'ng2-dragula';
import { HttpServices } from './services/http.service';
import { UtilsServices } from './services/utils.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    DragulaModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
  ],
  declarations: [],
  exports: [
    RouterModule,
    DragulaModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [HttpServices, UtilsServices],
})
export class CoreModule {}
