import { Component, Inject, inject, OnInit } from '@angular/core';
import { GET_DATA_TOKEN } from '../tokens/get-data.token';
import { FilmClass } from '../classes/film.class';
import { Observable } from 'rxjs';

@Component({
  selector: 'taiib2-filmy',
  standalone: false,
  templateUrl: './filmy.component.html',
  styles: ``
})
export class FilmyComponent implements OnInit {
  data$!: Observable<FilmClass[]>;

  constructor(@Inject(GET_DATA_TOKEN) private dataService: any) {}

  ngOnInit(): void {
    this.data$ = this.dataService.Get();
  }
}
