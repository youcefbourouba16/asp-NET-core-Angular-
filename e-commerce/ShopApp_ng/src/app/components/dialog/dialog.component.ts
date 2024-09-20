import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styles: ``,
})
export class DialogComponent {
  constructor(
    public dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, message: string, cancelButtonText: string, confirmButtonText: string }
  ) {}
    
      onConfirm(): void {
        this.dialogRef.close(true);
      }
    
      onCancel(): void {
        this.dialogRef.close(false);
      }
}
