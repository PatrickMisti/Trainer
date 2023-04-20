
export class Workset {
  id: number;
  name: string;
  sets: Sets[];
  routineId: number;

  constructor(id: number = 0, name: string, sets: Sets[], routineId: number) {
    this.id = id;
    this.name = name;
    this.sets = sets;
    this.routineId = routineId;
  }
}
