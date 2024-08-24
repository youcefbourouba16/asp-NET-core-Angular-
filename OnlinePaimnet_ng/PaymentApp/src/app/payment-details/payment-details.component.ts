import { Component, OnInit } from '@angular/core';
import { PaymentDetail } from '../shared/payment-detail.model';
import { PaymentDetailService } from '../shared/payment-detail.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styles: [
  ]
})
export class PaymentDetailsComponent implements OnInit {

  constructor(public service: PaymentDetailService,private toastr : ToastrService) {
  }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: PaymentDetail) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id : number){

    if(confirm('are you sure you want to delete this record  ? ')){

      this.service.deletePaymentDetail(id)
      .subscribe({
        next: res => {
          
          this.service.list= res as PaymentDetail[]
          this.toastr.error('Deleted ','Payemnt detail Deleted succesfully')
          
          
        },
        error: err => { console.log(err) }
      })
    }
    
  }
  

}
