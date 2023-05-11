import { BasicGameInfoDto } from "../api";

export default interface ISearchableGame {
  searchString: string;
  game: BasicGameInfoDto;
}
