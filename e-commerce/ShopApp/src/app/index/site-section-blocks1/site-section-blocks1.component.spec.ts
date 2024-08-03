import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SiteSectionBlocks1Component } from './site-section-blocks1.component';

describe('SiteSectionBlocks1Component', () => {
  let component: SiteSectionBlocks1Component;
  let fixture: ComponentFixture<SiteSectionBlocks1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SiteSectionBlocks1Component]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SiteSectionBlocks1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
