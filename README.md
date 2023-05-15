# GameIndex

Work in progress

- https://hub.docker.com/repository/docker/niemandr/game-index/general

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

- Refresh games when closing game information dialog
- Ability to search on receipt number
- Add flag for receipt scanned
- Support for console \ hardware purchase tracking
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
