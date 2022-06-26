import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StepmediaExerciseComponent } from './pages/stepmedia-exercise/stepmedia-exercise.component';

const routes: Routes = [{path:'', component: StepmediaExerciseComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
