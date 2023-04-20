import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ShellComponent } from './components/shell/shell.component';
import { HttpWrapperService } from "./services/http-wrapper.service";
import { HttpClientModule } from "@angular/common/http";
import { TrainingSettingsComponent } from './components/training-settings/training-settings.component';

@NgModule({
  declarations: [
    AppComponent,
    ShellComponent,
    TrainingSettingsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [
    HttpWrapperService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
