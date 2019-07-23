import { MatDialogRef } from '@angular/material';
import { Component } from '@angular/core';
import { TraineeService } from './trainee.service';

@Component({
    selector: 'app-addtrainee',
    templateUrl: './addtrainee.component.html'
})

export class AddTraineeComponent {
    options: string[] = ['GC EAD', 'OPT', 'OPT STEM', 'Citizen'];
    constructor(
        private service: TraineeService,
        private dialogRef: MatDialogRef<AddTraineeComponent>) {}
        onSubmit() {
            if (this.service.form.valid) {
                this.dialogRef.close();
            }
          }

    onNoClick(): void {
        this.service.form.reset();
        this.dialogRef.close();
      }
}
