import { MatDialogRef } from '@angular/material';
import { Component } from '@angular/core';
import { SubmissionService } from './submissions.service';

@Component({
    selector: 'app-addsubmissions',
    templateUrl: './addsubmissions.component.html'
})

export class AddSubmissionsComponent {
    options: string[] = ['On Hold', 'Acceptance', 'Ongoing', 'Rejected'];
    constructor(
        private service: SubmissionService,
        private dialogRef: MatDialogRef<AddSubmissionsComponent>) {}
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
