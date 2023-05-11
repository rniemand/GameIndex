import React from "react";

interface GameListEntryProps { }

interface GameListEntryState { }

export class GameListEntry extends React.Component<GameListEntryProps, GameListEntryState> {
  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    return (<div>
      Game List Entry
    </div>);
  }
}
