import { Component, OnInit } from '@angular/core';
import { Character } from '../models/character';
import { CharacterService } from '../character.service';

@Component({
  selector: 'app-character-list',
  templateUrl: './character-list.component.html',
  styleUrls: ['./character-list.component.css']
})
export class CharacterListComponent implements OnInit {

  userCharacters: Character[];

  constructor(private api: CharacterService) { }

  ngOnInit() {
    this.api.getUserCharacters().subscribe( (res: Character[]) => {
      this.userCharacters = res;
    });
  }
}
