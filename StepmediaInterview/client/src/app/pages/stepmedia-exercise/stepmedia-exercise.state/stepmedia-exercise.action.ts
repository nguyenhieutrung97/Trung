import { createAction, props } from '@ngrx/store';

export const getCalculationResultAction = createAction('[StepmediaExercise Component] Get Calculation Result',props<{ input: number[] }>());