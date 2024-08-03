import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SiteSectionBlocks2Component } from './site-section-blocks2.component';

describe('SiteSectionBlocks2Component', () => {
  let component: SiteSectionBlocks2Component;
  let fixture: ComponentFixture<SiteSectionBlocks2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SiteSectionBlocks2Component]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SiteSectionBlocks2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
