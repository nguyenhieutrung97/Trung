import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StepmediaExerciseComponent } from './stepmedia-exercise.component';

describe('StepmediaExerciseComponent', () => {
  let component: StepmediaExerciseComponent;
  let fixture: ComponentFixture<StepmediaExerciseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StepmediaExerciseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StepmediaExerciseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
