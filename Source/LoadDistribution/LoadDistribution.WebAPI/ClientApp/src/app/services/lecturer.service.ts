import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LecturerVM } from 'src/app/models/lecturerVM.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LecturerService {
  private readonly _controllerUrl: string = `${environment.baseUrl}/api/lecturer`;

  constructor(
    private readonly _httpClient: HttpClient
  ) { }

  get(): Observable<LecturerVM[]> {
    return this._httpClient.get<LecturerVM[]>(this._controllerUrl);
  }
}
