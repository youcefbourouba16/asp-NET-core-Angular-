import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignUpRootComponent } from './sign-up-root.component';

describe('SignUpRootComponent', () => {
  let component: SignUpRootComponent;
  let fixture: ComponentFixture<SignUpRootComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SignUpRootComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SignUpRootComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
