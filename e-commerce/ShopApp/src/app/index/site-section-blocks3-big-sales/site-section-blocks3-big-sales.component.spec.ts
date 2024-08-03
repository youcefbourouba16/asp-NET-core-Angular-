import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SiteSectionBlocks3BigSalesComponent } from './site-section-blocks3-big-sales.component';

describe('SiteSectionBlocks3BigSalesComponent', () => {
  let component: SiteSectionBlocks3BigSalesComponent;
  let fixture: ComponentFixture<SiteSectionBlocks3BigSalesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SiteSectionBlocks3BigSalesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SiteSectionBlocks3BigSalesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
