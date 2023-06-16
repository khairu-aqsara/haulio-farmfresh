import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {LayoutModule} from "./layout/layout.module";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LandingpageComponent } from './secreen/landingpage/landingpage.component';
import {HttpClientModule} from "@angular/common/http";
import { DetailComponent } from './secreen/detail/detail.component';
import { CategoryComponent } from './secreen/category/category.component';

@NgModule({
  declarations: [
    AppComponent,
    LandingpageComponent,
    DetailComponent,
    CategoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    NgbModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
