import { Injectable } from '@angular/core';
import { BoardGame } from '../models/boardgame-details';

@Injectable({
  providedIn: 'root'
})
export class BoardgameDetailsService {

  constructor() { }

  public getBoardGamesDetails() : BoardGame[] {
    let boardgame = new BoardGame();
    boardgame.id = 1;
    boardgame.title = "Gloomhaven";
    boardgame.authors = "Isaac Childres";
    boardgame.description = "Kooperacyjna gra taktyczna, stworzona przez miłośnika ekonomicznych gier Euro, w której wspólnymi siłami przedzieramy się przez nieustannie ewoluujący świat fantasy, rozgrywając kampanię fabularną na przestrzeni wielu sesji.";
    boardgame.avgPlaytime = "60 - 120 minut";
    boardgame.physicalMinis = "18";

    return [boardgame];
  }
}
