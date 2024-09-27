import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { catchError, firstValueFrom, mergeMap, of } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  private config: any;
  private STORAGE_KEY = 'appConfig';
  private http = inject(HttpClient);

  public async getConfig(): Promise<any> {
    return await firstValueFrom(this.http
      .get(this.getConfigFile(), { observe: 'response' })
      .pipe(
        catchError((error) => {
          console.log(error);
          return of(null);
        }),
        mergeMap((response) => {
          this.config = response?.body;
          this.setConfigToStorage(this.config);
          return of(this.config);
        })
      ));
  }

  public getValue(key: string): any {
    if (this.config && this.config[key] !== undefined) {
      return this.config[key];
    }

    const storedConfig = this.getConfigFromStorage();
    if (storedConfig && storedConfig[key] !== undefined) {
      return storedConfig[key];
    }

    return null;
  }

  private getConfigFromStorage(): any {
    const storedConfig = sessionStorage.getItem(this.STORAGE_KEY);
    return storedConfig ? JSON.parse(storedConfig) : null;
  }

  private setConfigToStorage(config: any): void {
    sessionStorage.setItem(this.STORAGE_KEY, JSON.stringify(config));
  }

  private getConfigFile(): string {
    return environment.configFile;
  }
}
