import { Component, OnInit } from '@angular/core';
import {Routine} from "../../module/routine";
import {Workset} from "../../module/workset";
import {Sets} from "../../module/sets";

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html'
})
export class ShellComponent implements OnInit {

  routine: Routine = new Routine(0, []);
  constructor() {
  }

  ngOnInit(): void {
    this.routine = new Routine(1, [new Workset(1,"Lat",[new Sets(1,20,20, 1),new Sets(2,201,210, 1)],1)],new Date(Date.now()))
  }

}
