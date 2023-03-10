import { Component } from '@angular/core';
import { BoardGame } from './models/boardgame';
import { BoardGameService } from './services/boardgame.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Minifigures.UI';
  boardGames: BoardGame[] = [];
  boardgameToEdit?: BoardGame;

  constructor(private boardGameService: BoardGameService) {}

  ngOnInit() : void{
    this.boardGameService.getBoardGames().subscribe((result: BoardGame[]) => (this.boardGames = result));
  }

  updateBoardGameList(boardGames: BoardGame[]) {
    return this.boardGames = boardGames;
  }

  initNewBoardGame() {
    return this.boardgameToEdit = new BoardGame();
  }

  editBoardGame(boardgame: BoardGame) {
    return this.boardgameToEdit = boardgame;
  }
}
