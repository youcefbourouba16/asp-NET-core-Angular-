import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThnkyouComponent } from './thnkyou.component';

describe('ThnkyouComponent', () => {
  let component: ThnkyouComponent;
  let fixture: ComponentFixture<ThnkyouComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ThnkyouComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ThnkyouComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
