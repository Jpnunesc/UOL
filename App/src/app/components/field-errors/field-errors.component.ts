import { Component, Host, SkipSelf, Input } from '@angular/core';
import { AbstractControlDirective, AbstractControl, FormGroupDirective } from '@angular/forms';

@Component({
  selector: 'field-errors',
  templateUrl: './field-errors.component.html',
  styleUrls: ['./field-errors.component.css']
})
export class FieldErrorsComponent {

  private static readonly errorMessages = {
    'required': () => 'Campo obrigatório',
    'minlength': (params) => 'The minimum number of characters is' + params.requiredLength,
    'maxlength': (params) => 'The maximum allowed number of characters is ' + params.requiredLength,
    'pattern': (params) => 'Campo obrigatório',
    'min': (params) => 'The minimum value is' + params.min.toString().replace('.',','),
    'email': (params) => 'Email inválido'
  };

  @Input()
  private control: AbstractControlDirective | AbstractControl;

  @Input()
   emailError = false;

   @Input()
   cpfError = false;

  constructor(
    @Host() @SkipSelf() private form: FormGroupDirective,
  ) {   }

  shouldShowErrors(): boolean {

    return (this.control &&
      this.control.errors &&
      (this.control.dirty || this.control.touched || this.form.submitted)) || (this.cpfError || this.emailError);
  }

  listOfErrors(): string[] {
    if(this.emailError) { 
      return ['Email inválido'];
    } else if(this.cpfError){
      return ['Cpf inválido'];
    }
    else {
      return Object.keys(this.control.errors)
      .map(field => this.getMessage(field, this.control.errors[field]));
    }
  }
  private getMessage(type: string, params: any) {
       return FieldErrorsComponent.errorMessages[type](params);
  }
}
