import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { StepmediaExerciseComponent } from './pages/stepmedia-exercise/stepmedia-exercise.component';
import { StepmediaExerciseEffect } from './pages/stepmedia-exercise/stepmedia-exercise.state/stepmedia-exercise.effect';

@NgModule({
  declarations: [
    AppComponent,
    StepmediaExerciseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    EffectsModule.forRoot([StepmediaExerciseEffect]),
    StoreModule.forRoot({ })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
