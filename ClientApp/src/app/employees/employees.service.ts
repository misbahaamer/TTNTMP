import { FormGroup, FormControl, Validators } from '@angular/forms';
import { EXAMPLE_DATA } from './employees-datasource';


export class EmployeeService {

  form: FormGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    id: new FormControl('', Validators.required)
  });

initializeFormGroup() {
    this.form.setValue({
      name: '',
      id: ''
    });
  }

  populateForm(employee) {
    this.form.setValue(employee);
  }

}
