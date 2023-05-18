# GameIndex

Work in progress

- https://hub.docker.com/repository/docker/niemandr/game-index/general

```bash
cd .\ui\
npm run start
```

Open app using [http://localhost:5232/](http://localhost:5232/)

## Building

```bash
docker build . -t niemandr/game-index:latest
docker push niemandr/game-index:latest
```

## Configuration

### Docker

```text
image: niemandr/game-index
ports:
    - 80 : 5003 (TCP)
paths:
    - /app/appsettings.json | /mnt/user/Backups/app-data/game-index/appsettings.json
    - /data | /mnt/user/Backups/app-data/game-index/data/
```

## Development

### Task List

- Support for console \ hardware purchase tracking
- Auto calculate game coverage end date
- Add pre-owned flag to games table
- fix dates not loadng initially on the game order info screen
- Add receipts view
- Add receipts
  - REC-012
- Game Info Modal
  - Add links to store page
- Process return info
  - REC-005
  - REC-007
  - REC-015
  - REC-017
  - REC-018
  - REC-021
- Pre-order
  - REC-009
- Console Order
  - REC-012
- Missing
  - REC-022
- Data to correct
  - Online
    - 47038981
      - Add missing games
    - 46343488
      - Add missing game
    - 45839830
      - Add missing game
    - 45982437
      - add missing game
    - 45985192
      - add missing game