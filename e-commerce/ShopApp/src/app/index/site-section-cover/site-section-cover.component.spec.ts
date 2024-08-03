import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SiteSectionCoverComponent } from './site-section-cover.component';

describe('SiteSectionCoverComponent', () => {
  let component: SiteSectionCoverComponent;
  let fixture: ComponentFixture<SiteSectionCoverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SiteSectionCoverComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SiteSectionCoverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
