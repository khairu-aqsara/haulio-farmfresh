import {Component, OnInit} from '@angular/core';
import {RestApiService} from "../../shared/rest-api.service";
import {debounceTime, Observable, OperatorFunction, distinctUntilChanged, tap, switchMap, catchError, of} from "rxjs";
import {Router} from "@angular/router";
import {Helper} from "../../helper/helper";
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  model?: any;
  searching = false;
  searchFailed = false;

  constructor(public restApi: RestApiService, private route: Router ) {
  }
  ngOnInit(): void {
  }

  selectedItem(event: any)
  {
    const id = event.item.id;
    const slug = Helper.slugify(event.item.name);
    this.route.navigate(['/product',id, slug]);
  }

  search: OperatorFunction<string, any> = (text$: Observable<string>) =>
    text$.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      tap(() => (this.searching = true)),
      switchMap((term) => term.length > 3 ?
        this.restApi.searchData(term).pipe(
          tap(() => (this.searchFailed = false)),
          catchError(() => {
            this.searchFailed = true;
            return of([]);
          }),
        )
        : []
      ),
      tap(() => this.searching = false)
    );

  resultFormatBandListValue(value: any) {
    return value.name;
  }

  inputFormatBandListValue(value: any)   {
    if(value.length > 3) {
      if (value.name)
        return value.name
      return value;
    }
  }
}
