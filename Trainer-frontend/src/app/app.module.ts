import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ShellComponent } from './components/shell/shell.component';
import { HttpWrapperService } from "./services/http-wrapper.service";
import { HttpClientModule } from "@angular/common/http";
import { TrainingSettingsComponent } from './components/training-settings/training-settings.component';
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatCardModule} from "@angular/material/card";
import { RoutineDashboardComponent } from './components/routine-dashboard/routine-dashboard.component';
import {FlexModule} from "@angular/flex-layout";
import {ReactiveFormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";

@NgModule({
  declarations: [
    AppComponent,
    ShellComponent,
    TrainingSettingsComponent,
    RoutineDashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatToolbarModule,
    MatCardModule,
    FlexModule,
    ReactiveFormsModule,
    MatInputModule
  ],
  providers: [
    HttpWrapperService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
