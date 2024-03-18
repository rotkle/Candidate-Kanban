import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardModule } from './pages/dashboard/dashboard.module';
import { CandidateModule } from './pages/candidate/candidate.module';

const routes: Routes = [
  { path: '', loadChildren: () => DashboardModule },
  { path: 'candidate/:id', loadChildren: () => CandidateModule },
  { path: '**', redirectTo: '/' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
