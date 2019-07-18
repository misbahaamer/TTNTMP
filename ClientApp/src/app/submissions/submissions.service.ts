import { FormGroup, FormControl, Validators, ValidationErrors } from '@angular/forms';


export class SubmissionService {

  form: FormGroup = new FormGroup({
    rep: new FormControl('', Validators.required),
    vendor: new FormControl(),
    primeVendor: new FormControl('', Validators.required),
    client: new FormControl(),
    implementationPartnerVendor: new FormControl(),
    vendorPerson: new FormControl(),
    vendorContact: new FormControl(),
    primeVendorPerson: new FormControl('', Validators.required),
    primeVendorContact: new FormControl('', Validators.required),
    firstCommunication: new FormControl('', Validators.required),
    role: new FormControl('', Validators.required),
    domain: new FormControl(),
    toolStack: new FormControl('', Validators.required),
    submissionAndProcess: new FormControl('', Validators.required),
    status: new FormControl('', [Validators.required, this.requireMatch]),
    reasonOnDecision: new FormControl(),
    updates: new FormControl(),
    id: new FormControl('', Validators.required)
  });

initializeFormGroup() {
  this.form.setValue({
    rep: '',
    vendor: '',
    primeVendor: '',
    client: '',
    implementationPartnerVendor: '',
    vendorPerson: '',
    vendorContact: '',
    primeVendorPerson: '',
    primeVendorContact: '',
    firstCommunication: '',
    role: '',
    domain: '',
    toolStack: '',
    submissionAndProcess: '',
    status: '',
    reasonOnDecision: '',
    updates: '',
    id: ''
    });
  }

  populateForm(submission) {
    this.form.setValue(submission);
  }

requireMatch(control: FormControl): ValidationErrors | null {
    const selection: any = control.value;
    if (!(selection === 'On Hold' || selection === 'Acceptance' || selection === 'Rejected' || selection === 'Ongoing')) {
      return { requireMatch: true };
    }
    return null;
  }
}
