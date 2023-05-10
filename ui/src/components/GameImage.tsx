import React from "react";

export class GameImage extends React.Component {

  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    const imgUrl = '/Image/game/1'
    return (<img src={imgUrl} />);
  }
}
