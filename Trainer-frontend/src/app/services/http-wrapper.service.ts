import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {lastValueFrom} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class HttpWrapperService {

  constructor(private _http: HttpClient) { }

  public async Get<T>(path: string): Promise<T> {
    console.log("Http request GET: ", path);
    return lastValueFrom(this._http.get<T>(path));
  }

  async Post<T>(path: string, payload: T): Promise<boolean> {
    const _payload = JSON.stringify(payload);
    console.log(`Http request POST ${path} payload:`, _payload);
    return lastValueFrom(this._http.post<boolean>(path, _payload));
  }

  async Put<T>(path: string, payload: T): Promise<boolean> {
    const _payload = JSON.stringify(payload);
    console.log(`Http request PUT ${path} payload:`, _payload);
    return lastValueFrom(this._http.put<boolean>(path, _payload));
  }

  async Delete(path: string): Promise<boolean> {
    console.log(`Http request DELETE ${path}`);
    return lastValueFrom(this._http.delete<boolean>(path));
  }
}
