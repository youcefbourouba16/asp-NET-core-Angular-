import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SiteSectionBlocks5FoterComponent } from './site-section-blocks5-foter.component';

describe('SiteSectionBlocks5FoterComponent', () => {
  let component: SiteSectionBlocks5FoterComponent;
  let fixture: ComponentFixture<SiteSectionBlocks5FoterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SiteSectionBlocks5FoterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SiteSectionBlocks5FoterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
