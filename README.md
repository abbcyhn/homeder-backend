### Build docker image

`! All commands should be executed from the root of the solution !`
```shell
docker build -t homeder-backend-webapi:latest -f WebAPI/Dockerfile .
```

### Run container
```shell
docker run -d -p 8080:80 --name hmdr-be-webapi homeder-backend-webapi:latest
```