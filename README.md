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
