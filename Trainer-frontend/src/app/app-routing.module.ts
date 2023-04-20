import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ShellComponent} from "./components/shell/shell.component";
import {TrainingSettingsComponent} from "./components/training-settings/training-settings.component";

const routes: Routes = [
  {path: "", component: ShellComponent},
  {path: "create", component: TrainingSettingsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
