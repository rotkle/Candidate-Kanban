import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ICandidateForm } from '../models/candidate.model';

@Injectable()
export class HttpServices {
  constructor(private http: HttpClient) {}

  get(urlParam: string) {
    return this.http.get(urlParam);
  }

  put(url: string, data: ICandidateForm) {
    return this.http.put(url, data);
  }

  post(url: string, data: ICandidateForm) {
    return this.http.post(url, data);
  }
}
