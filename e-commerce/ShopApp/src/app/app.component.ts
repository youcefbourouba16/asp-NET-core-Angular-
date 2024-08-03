import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SiteSectionBlocks1Component } from './index/site-section-blocks1/site-section-blocks1.component';
import { NavBarComponent } from "./index/nav-bar/nav-bar.component";
import { SiteSectionCoverComponent } from "./index/site-section-cover/site-section-cover.component";
import { SiteSectionBlocks2Component } from "./index/site-section-blocks2/site-section-blocks2.component";
import { SiteSectionBlocks3CategoryComponent } from "./index/site-section-blocks3-category/site-section-blocks3-category.component";
import { SiteSectionBlocks3FetauredProductComponent } from "./index/site-section-blocks3-fetaured-product/site-section-blocks3-fetaured-product.component";
import { SiteSectionBlocks3BigSalesComponent } from "./index/site-section-blocks3-big-sales/site-section-blocks3-big-sales.component";
import { SiteSectionBlocks5FoterComponent } from "./index/site-section-blocks5-foter/site-section-blocks5-foter.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SiteSectionBlocks1Component, NavBarComponent, SiteSectionCoverComponent, SiteSectionBlocks2Component, SiteSectionBlocks3CategoryComponent, SiteSectionBlocks3FetauredProductComponent, SiteSectionBlocks3BigSalesComponent, SiteSectionBlocks5FoterComponent],
  templateUrl: './app.component.html',
  styles: [],
})
export class AppComponent {
  title = 'ShopApp';
}
