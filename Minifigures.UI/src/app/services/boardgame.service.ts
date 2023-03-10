import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BoardGame } from '../models/boardgame';

@Injectable({
  providedIn: 'root'
})
export class BoardGameService {

  private url = "BoardGame";
  constructor(private http: HttpClient) { }

  public getBoardGames() : Observable<BoardGame[]> {
    return this.http.get<BoardGame[]>(`${environment.apiUrl}/${this.url}`);
  }

  public createBoardGame(boardgame: BoardGame) : Observable<BoardGame[]> {
    return this.http.post<BoardGame[]>(`${environment.apiUrl}/${this.url}`, boardgame);
  }

  public updateBoardGame(boardgame: BoardGame) : Observable<BoardGame[]> {
    return this.http.put<BoardGame[]>(`${environment.apiUrl}/${this.url}`, boardgame);
  }

  public deleteBoardGame(boardgame: BoardGame) : Observable<BoardGame[]> {
    return this.http.delete<BoardGame[]>(`${environment.apiUrl}/${this.url}/${boardgame.id}`);
  }
}
