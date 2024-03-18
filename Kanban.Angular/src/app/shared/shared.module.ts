import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CandidateForm } from '../components/candidate-form/candidate-form.component';
import {
  TuiAlertModule,
  TuiButtonModule,
  TuiDataListModule,
  TuiDialogModule,
  TuiErrorModule,
  TuiHintModule,
  TuiNotificationModule,
  TuiTextfieldControllerModule,
} from '@taiga-ui/core';
import {
  TuiBreadcrumbsModule,
  TuiDataListWrapperModule,
  TuiFieldErrorPipeModule,
  TuiInputModule,
  TuiMultiSelectModule,
  TuiSelectModule,
} from '@taiga-ui/kit';
import { TuiIconModule } from '@taiga-ui/experimental';
import { LoadingComponent } from './Loading/loading.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TuiButtonModule,
    TuiBreadcrumbsModule,
    TuiInputModule,
    TuiAlertModule,
    TuiNotificationModule,
    TuiFieldErrorPipeModule,
    TuiErrorModule,
    TuiIconModule,
    TuiDialogModule,
    TuiDataListModule,
    TuiDataListWrapperModule,
    TuiSelectModule,
    TuiMultiSelectModule,
    TuiTextfieldControllerModule,
    TuiHintModule,
  ],
  declarations: [CandidateForm, LoadingComponent],
  exports: [
    CommonModule,
    FormsModule,
    CandidateForm,
    TuiButtonModule,
    TuiBreadcrumbsModule,
    TuiInputModule,
    TuiAlertModule,
    TuiNotificationModule,
    TuiFieldErrorPipeModule,
    TuiErrorModule,
    TuiIconModule,
    TuiDialogModule,
    TuiDataListModule,
    TuiDataListWrapperModule,
    TuiSelectModule,
    TuiMultiSelectModule,
    TuiTextfieldControllerModule,
    TuiHintModule,
    LoadingComponent,
  ],
})
export class SharedModule {}
