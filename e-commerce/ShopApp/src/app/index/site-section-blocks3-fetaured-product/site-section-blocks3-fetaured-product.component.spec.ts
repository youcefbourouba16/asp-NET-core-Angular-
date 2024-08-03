import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SiteSectionBlocks3FetauredProductComponent } from './site-section-blocks3-fetaured-product.component';

describe('SiteSectionBlocks3FetauredProductComponent', () => {
  let component: SiteSectionBlocks3FetauredProductComponent;
  let fixture: ComponentFixture<SiteSectionBlocks3FetauredProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SiteSectionBlocks3FetauredProductComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SiteSectionBlocks3FetauredProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
