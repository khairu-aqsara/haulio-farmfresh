import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LandingpageComponent} from "./secreen/landingpage/landingpage.component";
import {DetailComponent} from "./secreen/detail/detail.component";
import {CategoryComponent} from "./secreen/category/category.component";

const routes: Routes = [
  { path : '', component : LandingpageComponent },
  { path : 'product/:id/:slug', component : DetailComponent },
  { path : 'categories/:id', component : CategoryComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
