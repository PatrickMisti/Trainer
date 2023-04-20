export class Routine {
  id: number;
  worksets: Workset[];
  date: Date;

  constructor(id: number = 0, worksets: Workset[], date: Date) {
    this.id = id;
    this.worksets = worksets ?? [];
    this.date = date;
  }

}
