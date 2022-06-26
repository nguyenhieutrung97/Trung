import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EMPTY, of } from 'rxjs';
import { map, mergeMap, catchError } from 'rxjs/operators';
import { errorAction, successAction } from 'src/app/shared/action/base.action';
import { CalculationService } from 'src/app/shared/services/calculation.service';
import { getCalculationResultAction } from './stepmedia-exercise.action';

@Injectable()
export class StepmediaExerciseEffect {
 
  loadGetUser$ = createEffect(() => this.actions$.pipe(
    ofType(getCalculationResultAction),
    mergeMap(action => this.calculationService.calculation(action.input)
      .pipe(
        map(result => successAction({fromAction: getCalculationResultAction.type ,payload: result})),
        catchError(error => of(errorAction({fromAction: getCalculationResultAction.type,payload :error}))) 
      ))
    )
  );
  constructor(
    private actions$: Actions,
    private calculationService: CalculationService
  ) {}
}