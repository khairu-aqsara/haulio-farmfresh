import {Component, OnInit} from '@angular/core';
import {Product} from "../../shared/product";
import {RestApiService} from "../../shared/rest-api.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Helper} from "../../helper/helper";

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit{
  products? : Product[];
  loading: boolean = true;
  param?:string | null;

  constructor(private http: RestApiService, private router: Router, private route: ActivatedRoute) {
    route.params.subscribe((param) => {
      this.param = this.route.snapshot.paramMap.get('id');
      this.getProductByCategories();
    })
  }
  ngOnInit(): void {
  }

  getProductByCategories()
  {
    this.http.getProductsByCategory(this.param).subscribe((data) => {
      this.products = data;
      this.loading = false;
    });
  }

  protected readonly Helper = Helper;
}
