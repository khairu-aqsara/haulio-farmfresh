import { NgModule } from '@angular/core';
import {CommonModule, JsonPipe, NgIf} from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import {NgbTypeahead} from "@ng-bootstrap/ng-bootstrap";
import {FormsModule} from "@angular/forms";
import {RouterLink} from "@angular/router";



@NgModule({
  declarations: [
    HeaderComponent,
    SidebarComponent
  ],
  exports: [
    HeaderComponent,
    SidebarComponent
  ],
    imports: [
        CommonModule,
        NgbTypeahead,
        FormsModule,
        RouterLink
    ]
})
export class LayoutModule { }
