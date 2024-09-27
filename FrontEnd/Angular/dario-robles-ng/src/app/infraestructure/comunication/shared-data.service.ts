import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedDataService {
  public getFullName(firstName: string, lastName: string): string {
    return `${firstName} ${lastName}`;
  }
}
