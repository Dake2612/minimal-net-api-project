import { Injectable, inject } from '@angular/core';
import { ORDER_REPOSITORY_TOKEN } from '../../domain/repositories/repository.tokens';

@Injectable({
  providedIn: 'root'
})
export class GetStatesUseCase {
  private orderRepository = inject(ORDER_REPOSITORY_TOKEN);

  public async execute(): Promise<Array<string>> {
    return await this.orderRepository.getStates();
  }
}
