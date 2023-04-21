import {Component, Input, OnInit} from '@angular/core';
import {Routine} from "../../module/routine";
import {FormArray, FormBuilder, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-routine-dashboard',
  templateUrl: './routine-dashboard.component.html'
})
export class RoutineDashboardComponent implements OnInit {

  @Input()
  routine!: Routine;

  settingsForm!: FormGroup;

  get workForm() : FormArray {
    return this.settingsForm.get("work") as FormArray;
  }

  setForm(id: number): FormArray {
    return (this.settingsForm.get("work") as FormArray).controls[id].get("sets") as FormArray;
  }

  constructor(private _formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.settingsForm = this._formBuilder.group({
      date: this.routine.date,
      work: this._formBuilder.array(this.routine.worksets.map(item => this._formBuilder.group({
        name: item.name,
        sets: this._formBuilder.array(item.sets.map(element => this._formBuilder.group({
          weight: element.weight,
          rep: element.repetition
        })))
      })))
    });
  }

}
