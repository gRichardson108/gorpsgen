import { Skill } from "./skill";

export class Character {
    id: string;
    strength: number;
    dexterity: number;
    intelligence: number;
    health: number;
    skills: Skill[];
}