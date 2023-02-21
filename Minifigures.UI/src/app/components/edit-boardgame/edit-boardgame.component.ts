import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BoardGame } from 'src/app/models/boardgame';
import { BoardGameService } from 'src/app/services/boardgame.service';

@Component({
  selector: 'app-edit-boardgame',
  templateUrl: './edit-boardgame.component.html',
  styleUrls: ['./edit-boardgame.component.css']
})
export class EditBoardgameComponent implements OnInit {
  @Input() boardgame?: BoardGame;
  @Output() boardgameUpdated = new EventEmitter<BoardGame[]>();
  
  constructor(private boardGameService: BoardGameService) {}

  ngOnInit(): void {}

  createBoardGame(boardgame: BoardGame) {
    this.boardGameService
      .createBoardGame(boardgame)
      .subscribe((boardgames: BoardGame[]) => this.boardgameUpdated
        .emit(boardgames));
  }

  updateBoardGame(boardgame: BoardGame) {
    this.boardGameService
      .updateBoardGame(boardgame)
      .subscribe((boardgames: BoardGame[]) => this.boardgameUpdated
        .emit(boardgames));
  }

  deleteBoardGame(boardgame: BoardGame) {
    this.boardGameService
      .deleteBoardGame(boardgame)
      .subscribe((boardgames: BoardGame[]) => this.boardgameUpdated
        .emit(boardgames));
  }
}
