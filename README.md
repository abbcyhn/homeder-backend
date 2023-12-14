# Homeder Backend

## Backend Deployment

To deploy backend, follow the steps below:

### Clone the repository

```bash
git clone git@github.com:abbcyhn/homeder-backend.git
```

### Deploy the backend

Once you have cloned the repository and navigated to the project directory, open your command prompt (cmd) or terminal and execute the following commands:


```bash
docker build -t homeder-backend:latest .
```

```bash
docker run -d -p 8080:8080 --add-host=host.docker.internal:host-gateway --env-file prod_secrets.env --name homeder-backend homeder-backend:latest
```
