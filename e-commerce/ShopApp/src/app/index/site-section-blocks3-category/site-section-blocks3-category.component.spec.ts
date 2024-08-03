import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SiteSectionBlocks3CategoryComponent } from './site-section-blocks3-category.component';

describe('SiteSectionBlocks3CategoryComponent', () => {
  let component: SiteSectionBlocks3CategoryComponent;
  let fixture: ComponentFixture<SiteSectionBlocks3CategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SiteSectionBlocks3CategoryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SiteSectionBlocks3CategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
