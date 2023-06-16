import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {catchError, Observable, retry, throwError} from "rxjs";
import {Category} from "./category";
import {Product} from "./product";

@Injectable({
  providedIn: 'root'
})
export class RestApiService {

  apiURL = 'http://localhost:5014';

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Apikey' : 'DLbcr7AbuW6LUevY6u2eJJjdmhf6ib6Yyrkf'
    }),
  };

  getCategories(): Observable<Category[]> {
    return this.http
      .get<Category[]>(this.apiURL + '/api/categories', this.httpOptions)
      .pipe(retry(1), catchError(this.handleError));
  }

  searchData(param : string) : Observable<Product[]> {
    return this.http
      .get<Product[]>(this.apiURL + '/api/products?keyword='+ encodeURIComponent(param), this.httpOptions)
      .pipe(retry(1), catchError(this.handleError));
  }

  getProductsByCategory(categoryId: string | null | undefined, page: number = 1, limit: number = 6): Observable<Product[]>{
    return this.http
      .get<Product[]>(this.apiURL + '/api/products/category/'+ categoryId + `?page=${page}&limit=${limit}`, this.httpOptions)
      .pipe(retry(1), catchError(this.handleError));
  }

  getProductDetail(id: number | undefined): Observable<Product> {
    return this.http.get<Product>(this.apiURL + '/api/products/' + id, this.httpOptions)
      .pipe(retry(1), catchError(this.handleError));
  }

  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }
}
