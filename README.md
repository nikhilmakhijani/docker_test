# Migration using Cloud Run Jobs

This repository contains the necessary files and instructions for performing a migration using Cloud Run jobs.

## Dockerfile

The migration process is executed using a Docker image. The following Dockerfile is used:

```Dockerfile
FROM migrate/migrate:v4.15.2

RUN apk update && apk add gettext
RUN wget https://storage.googleapis.com/cloud-sql-connectors/cloud-sql-proxy/v2.1.1/cloud-sql-proxy.linux.amd64 -O cloud-sql-proxy
RUN chmod +x cloud-sql-proxy

COPY ./migrations ./migrations
COPY ./entry.sh ./entry.sh 
COPY ./entry.sh.tpl ./entry.sh.tpl
RUN chmod +x ./entry.sh

ENTRYPOINT ["./entry.sh"]
'''
