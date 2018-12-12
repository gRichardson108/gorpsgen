import { Component, OnInit } from '@angular/core';
import { CharacterService } from '../character.service';
import { ActivatedRoute } from '@angular/router';
import { Character } from '../models/character';
import { PrimaryStat } from '../models/primaryStat';

@Component({
  selector: 'app-character',
  templateUrl: './character.component.html',
  styleUrls: ['./character.component.css']
})
export class CharacterComponent implements OnInit {

  character: Character;
  id: string;
  primaryStats: PrimaryStat[];

  constructor(private api: CharacterService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('characterId');
    this.api.getCharacter(this.id).subscribe( (c: Character)  => {
      this.character = c;
      this.primaryStats = [
        { name : "STR", points : this.character.strength},
        { name : "DEX", points : this.character.dexterity},
        { name : "INT", points : this.character.intelligence},
        { name : "HT", points : this.character.health},
      ]
    });
  }

}
