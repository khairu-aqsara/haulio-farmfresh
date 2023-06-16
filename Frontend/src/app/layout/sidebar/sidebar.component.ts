import {Component, OnInit} from '@angular/core';
import {RestApiService} from "../../shared/rest-api.service";
import {Router} from "@angular/router";
import {Category} from "../../shared/category";

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit{

  categories? : Category[];
  constructor(private http: RestApiService, private router: Router) {
  }
  ngOnInit(): void {
    this.getCategory();
  }

  getCategory()
  {
    this.http.getCategories().subscribe(data => this.categories = data);
  }

}
