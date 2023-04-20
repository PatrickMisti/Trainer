
export class Sets {

  id: number;
  weight: number;
  repetition: number;
  worksetId: number;

  constructor(id:number = 0, weight:number, repetition:number, worksetId: number = 0) {
    this.id = id;
    this.weight = weight;
    this.repetition = repetition;
    this.worksetId = worksetId;
  }
}
