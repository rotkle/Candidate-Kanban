import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.scss'],
})
export class CandidateComponent {
  items = [
    {
      caption: 'Dashboard',
      routerLink: '/',
    },
    {
      caption: 'Candidate',
    },
  ];

  canId: number;
  constructor(private route: ActivatedRoute ) {}

  ngOnInit() {
    this.canId = this.route.snapshot.params['id'];
  }
}
