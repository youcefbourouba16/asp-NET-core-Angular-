import { Component, OnInit } from '@angular/core';
import { CheckoutService } from '../../shared/checkout/checkout.service';
import { CartViewModel } from '../../Models/productViewModel/cart-view-model';
import { CartService } from '../../shared/Cart/cart.service';
import { AccountSigninModel } from '../../Models/account-signin-model';
import { AuthService } from '../../shared/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'; // import FormBuilder and Validators
import { OrderItemViewModel } from '../../Models/OrderViewModel/orderviewmodel';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styles: ``
})
export class CheckoutComponent implements OnInit {

  public products: CartViewModel[] = [];
  public grandTotal!: number;
  public checkoutForm!: FormGroup; // FormGroup to hold form controls
  countriesList: any[] = [];
  isLoading: boolean = false;

  // Account data
  vm: AccountSigninModel = new AccountSigninModel(); // Model data for the form
  errorMessage: string | null = null;

  constructor(
    private fb: FormBuilder, // Inject FormBuilder
    private checkoutService: CheckoutService,
    private cartService: CartService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.getCountries();
    this.cartService.getProducts().subscribe((res) => {
      this.products = res;
      this.grandTotal = this.cartService.getTotalPrice();
    });

    // Initialize checkout form with FormBuilder
    this.checkoutForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      companyName: [''],
      address: ['', Validators.required],
      address2: [''],
      stateCountry: ['', Validators.required],
      postalCode: ['', Validators.required],
      emailAddress: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required],
      country: [null, Validators.required],
      orderNotes: [''],
      createAccount: [false], // Added create account checkbox
      password: [''], // Optional, for account creation
      conffpassword: [''] // Optional, for account creation confirmation
    });
  }

  getCountries(): void {
    this.isLoading = true;

    this.checkoutService.getCountries().subscribe(
      (data) => {
        this.countriesList = data;
        this.isLoading = false;
      },
      (error) => {
        console.error('Error fetching data:', error);
        this.isLoading = false;
      }
    );
  }

  onSubmit(): void {
    if (this.checkoutForm.invalid) {
      console.error('Form is invalid');
      return;
    }
  
    // Create an OrderViewModel instance
    const orderData: OrderItemViewModel = {
      aspNetUsersId: this.vm.email,  // User's ID
      orderDate: new Date(),            // Current date for the order
      totalAmount: this.grandTotal,     // The total amount for the order
      note: this.checkoutForm.get('orderNotes')?.value || '', // Optional order notes
      orderItems: this.products.map(product => ({
        itemId: product.id,
        itemName: product.name,  // Assuming `product.name` exists
        quantity: product.quantityBuying,
        price: product.price
      }) as OrderItemViewModel),
      shippingDetails: {
        state: this.checkoutForm.get('stateCountry')?.value,
        postalCode: this.checkoutForm.get('postalCode')?.value,
        country: this.checkoutForm.get('country')?.value,
        phone: this.checkoutForm.get('phone')?.value,
        emailAddress: this.checkoutForm.get('emailAddress')?.value
      }
    };
  
    // Call the checkout service to post the order
    this.checkoutService.postOrder(orderData).subscribe({
      next: (response) => {
        console.log('Order submitted successfully:', response);
        // Perform success actions, such as navigating to a success page
      },
      error: (err) => {
        console.error('Order submission failed:', err);
      }
    });
  
    // Handle account creation if the user checked the "Create Account" option
    if (this.checkoutForm.get('createAccount')?.value) {
      if (this.checkoutForm.get('password')?.value !== this.checkoutForm.get('conffpassword')?.value) {
        this.errorMessage = 'Passwords do not match.';
        return;
      }
  
      // Prepare the account creation data
      this.vm.email = this.checkoutForm.get('emailAddress')?.value;
      this.vm.password = this.checkoutForm.get('password')?.value;
      this.vm.conffpassword = this.checkoutForm.get('conffpassword')?.value;
  
      this.authService.signup(this.vm).subscribe({
        next: () => {
          console.log('Account created successfully');
        },
        error: (err) => {
          this.errorMessage = 'Registration failed. Please try again.';
          console.error(err);
        }
      });
    }
  }
  


  
  checkCoponCode(){
    
  }
}
