import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-boardgame',
  templateUrl: './add-boardgame.component.html',
})
export class AddBoardgameComponent {
  newGameForm: FormGroup = new FormGroup({
    title: new FormControl(null, Validators.required),
    authors: new FormControl(null, Validators.required),
    description: new FormControl(null, Validators.required),
    avgPlaytime: new FormControl(null, Validators.required),
    physicalMinis: new FormControl(null, Validators.required),
  });

  getTitle() {
    return this.newGameForm.get("title");
  }

  getAuthors() {
    return this.newGameForm.get("authors");
  }

  getDescription() {
    return this.newGameForm.get("description");
  }

  getAvgPlaytime() {
    return this.newGameForm.get("avgPlaytime");
  }

  getPhysicalMinis() {
    return this.newGameForm.get("physicalMinis");
  }
}
