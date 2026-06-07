import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { FilmClass } from './classes/film.class';

@Injectable({
  providedIn: 'root'
})
export class WebApiService {
  
  private apiUrl = 'http://localhost:5109/api/Filmy'; 

  
  constructor(private http: HttpClient) { }


  Get(): Observable<FilmClass[]> {
    return this.http.get<FilmClass[]>(`${this.apiUrl}/lista`);
  }

  GetByID(id: number): Observable<FilmClass> {
    return this.http.get<FilmClass>(`${this.apiUrl}/lista/${id}`);
  }

  
  public Post(tytul: string, cena: number, data: Date): Observable<boolean> {

    const body = {
      tytul: tytul,
      cena: cena,
      dataPremiery: data.toISOString().split('T')[0] 
    };

    
    return this.http.post(`${this.apiUrl}/formularz`, body).pipe(
      map(() => true)
    );
  }

  public Put(id: number, tytul: string, cena: number, data: Date): Observable<boolean> {
    const body = {
      id: id,
      tytul: tytul,
      cena: cena,
      dataPremiery: data.toISOString().split('T')[0]
    };

   
    return this.http.put(`${this.apiUrl}/formularz`, body).pipe(
      map(() => true)
    );
  }
}
