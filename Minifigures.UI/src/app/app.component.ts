import { Component } from '@angular/core';
import { BoardGame } from './models/boardgame-details';
import { BoardgameDetailsService } from './services/boardgame-details.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Minifigures.UI';
  boardgames: BoardGame[] = [];

  constructor(private boardGameService: BoardgameDetailsService) {}

  ngOnInit() : void{
    this.boardgames = this.boardGameService.getBoardGamesDetails();
    console.log(this.boardgames);
  }
}
