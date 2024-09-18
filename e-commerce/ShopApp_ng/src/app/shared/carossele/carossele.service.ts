import { ElementRef, Injectable, Input, OnChanges } from '@angular/core';

declare var $: any;
@Injectable({
  providedIn: 'root'
})

export class CarosseleService  implements OnChanges{

  @Input() items: any[] = []; // Input to bind product data to the directive

  constructor(private el: ElementRef) {}

  ngOnChanges(): void {
    if (this.items.length > 0) {
      this.initializeCarousel();
    }
  }

  initializeCarousel(): void {
    $(this.el.nativeElement).owlCarousel({
      center: false,
      items: 1,
      loop: false,
      stagePadding: 15,
      margin: 20,
      nav: true,
      navText: ['<span class="icon-arrow_back">', '<span class="icon-arrow_forward">'],
      responsive: {
        600: {
          margin: 20,
          items: 2
        },
        1000: {
          margin: 20,
          items: 3
        },
        1200: {
          margin: 20,
          items: 3
        }
      }
    });
  }
}
