import { FormGroup, FormControl, Validators, ValidationErrors } from '@angular/forms';


export class EmployeeService {

  form: FormGroup = new FormGroup({
    firstname: new FormControl('', Validators.required),
    lastname: new FormControl('', Validators.required),
    personalPhoneNumber: new FormControl('', Validators.minLength(10)),
    marketingPhoneNumber: new FormControl('', Validators.minLength(10)),
    personalEmail: new FormControl('', Validators.email),
    marketingEmail: new FormControl('', Validators.email),
    status: new FormControl('', [Validators.required, this.requireMatch]),
    dateofBirth: new FormControl('', Validators.required),
    id: new FormControl('', Validators.required)
  });

initializeFormGroup() {
    this.form.setValue({
      firstname: '',
      lastname: '',
      personalPhoneNumber: '',
      marketingPhoneNumber: '',
      personalEmail: '',
      marketingEmail: '',
      status: '',
      dateofBirth: '',
      id: ''
    });
  }

  populateForm(employee) {
    this.form.setValue(employee);
  }

requireMatch(control: FormControl): ValidationErrors | null {
    const selection: any = control.value;
    if (!(selection === 'GC EAD' || selection === 'OPT' || selection === 'OPT STEM' || selection === 'Citizen')) {
      return { requireMatch: true };
    }
    return null;
  }
}
