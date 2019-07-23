import { FormGroup, FormControl, Validators, ValidationErrors } from '@angular/forms';


export class SubmissionService {

  form: FormGroup = new FormGroup({
    rep: new FormControl('', Validators.required),
    vendor: new FormControl(),
    primeVendor: new FormControl('', Validators.required),
    client: new FormControl(),
    vendorPerson: new FormControl(),
    vendorContact: new FormControl(),
    primeVendorPerson: new FormControl('', Validators.required),
    primeVendorContact: new FormControl('', Validators.required),
    role: new FormControl('', Validators.required),
    status: new FormControl('', [Validators.required, this.requireMatch]),
    reasonOnDecision: new FormControl(),
    id: new FormControl('', Validators.required)
  });

initializeFormGroup() {
  this.form.setValue({
    rep: '',
    vendor: '',
    primeVendor: '',
    client: '',
    vendorPerson: '',
    vendorContact: '',
    primeVendorPerson: '',
    primeVendorContact: '',
    role: '',
    status: '',
    reasonOnDecision: '',
    id: ''
    });
  }

  populateForm(submission) {
    this.form.setValue(submission);
  }

requireMatch(control: FormControl): ValidationErrors | null {
    const selection: any = control.value;
    if (!(selection === 'On Hold' || selection === 'Vendor passed' || selection === 'Rejected' ||
    selection === 'Ongoing' || selection === 'Confirmed')) {
      return { requireMatch: true };
    }
    return null;
  }
}
