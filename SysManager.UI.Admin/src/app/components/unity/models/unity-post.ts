import { UnityView } from "./unity-view";

export class UnityPost {
  name: string;
  active: string;

  constructor(obj: UnityView) {
    this.name = obj.name;
    this.active = obj.active;
  }
}
