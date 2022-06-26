import { createAction, props } from '@ngrx/store';
import { BaseActionRequest } from '../model/base-action-request.model';

export const successAction = createAction('[Base] Success Action',props<BaseActionRequest>());
export const errorAction = createAction('[Base] Error Action',props<BaseActionRequest>());