import { FormGroup, FormControl, Validators, ValidationErrors } from '@angular/forms';


export class TraineeService {

  form: FormGroup = new FormGroup({
    firstname: new FormControl('', Validators.required),
    lastname: new FormControl('', Validators.required),
    personalPhoneNumber: new FormControl('', [Validators.minLength(10), Validators.required]),
    marketingPhoneNumber: new FormControl(''),
    personalEmail: new FormControl('', Validators.email),
    marketingEmail: new FormControl(''),
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

  populateForm(Trainee) {
    this.form.setValue(Trainee);
  }

requireMatch(control: FormControl): ValidationErrors | null {
    const selection: any = control.value;
    if (!(selection === 'GC EAD' || selection === 'OPT' || selection === 'OPT STEM' || selection === 'Citizen')) {
      return { requireMatch: true };
    }
    return null;
  }
}
