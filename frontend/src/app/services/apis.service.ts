import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class ApisService {

  constructor(private _http: HttpClient) { }
  URL = 'http://localhost:54984/api/upload';
  processFile(file) {

    return this._http.post<any>(this.URL, file);
  }
}
