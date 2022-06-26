import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { getCalculationResultAction } from './stepmedia-exercise.state/stepmedia-exercise.action';
import { successAction } from 'src/app/shared/action/base.action';
import { AutoUnsubscribeComponent } from 'src/app/shared/component/auto-unsubscribe.component';


@Component({
  selector: 'app-stepmedia-exercise',
  templateUrl: './stepmedia-exercise.component.html',
  styleUrls: ['./stepmedia-exercise.component.css']
})
export class StepmediaExerciseComponent  extends AutoUnsubscribeComponent implements OnInit {
  output = "";
  inputForm = this.fb.group({
    input: ['', [Validators.required, Validators.pattern('^\\d+(?:,\\d+)+$')]],
  });

  constructor(
    private fb: FormBuilder, 
    private actions$: Actions,
    private store: Store
    ) {
      super();
  }

  ngOnInit(): void {
    this.safeSubscriptions(this.registerSubscriptions());
  }

  submitInputForm() {
    if(this.inputForm.valid) {
      const inputFormValue = this.inputForm.value;
      var input = inputFormValue.input?.split(',').map(i => parseInt(i));
      this.store.dispatch(getCalculationResultAction({input: input ?? []}));
    }
  }

  get input() { return this.inputForm.get('input'); }

  registerSubscriptions() {
    return [
      this.actions$.pipe(
        ofType(successAction)
      ).subscribe(result => {
        if(result.fromAction === getCalculationResultAction.type){
          this.output = result.payload
        }
      })
    ];
  }
}
