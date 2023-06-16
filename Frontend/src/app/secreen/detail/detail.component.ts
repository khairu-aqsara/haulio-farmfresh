import {Component, OnInit} from '@angular/core';
import {RestApiService} from "../../shared/rest-api.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Product} from "../../shared/product";

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit{

  param?: number;
  product?: Product;
  loading :boolean = true;

  constructor(private http: RestApiService, private router: Router, private route: ActivatedRoute) {
    route.params.subscribe((param) => {
      this.param = parseInt(<string>this.route.snapshot.paramMap.get('id'));
      this.getProductDetail();
    })
  }
  ngOnInit(): void {

  }

  getProductDetail()
  {
    this.http.getProductDetail(this.param).subscribe((data) => {
      this.product = data;
      this.loading = false;
    })
  }

}
