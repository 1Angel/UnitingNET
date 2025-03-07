import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Observable } from 'rxjs';
import { Communities, Response } from '../models/Communities-response.interface';

@Injectable({
  providedIn: 'root'
})
export class CommunitiesService {

  private readonly http = inject(HttpClient);
  private readonly ApiUrl = environment.apiUrl;

  GetCommunities(): Observable<Response>{
    return this.http.get<Response>(`${this.ApiUrl}/communities?pageNumber=1&pageSize=2`);
  }
}
