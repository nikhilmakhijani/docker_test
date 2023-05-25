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

## Workflow

We have set up a workflow that automatically creates a new Docker image whenever there is a change in the migration folder. This ensures that the latest migration scripts are always included in the image used for the migration.

The workflow performs the following steps:

- Detects changes in the migration folder.
- Builds a new Docker image using the updated migration folder.
- Publishes the new Docker image to a container registry, such as Google Container Registry.
- Triggers the Cloud Run job to use the newly created Docker image for the migration.

To configure and set up this workflow, refer to the documentation of your chosen version control system or CI/CD platform.


# Database Migrations with Migrate and Docker

This repository provides a Dockerfile and migration scripts for running database migrations using the `migrate` tool. The `migrate` tool allows you to manage and apply database schema changes easily.

## Prerequisites

- Docker: Make sure you have Docker installed and running on your machine.
- Google Cloud SDK: Install the Google Cloud SDK on your local machine and authenticate with your Google Cloud account.

## Getting Started

1. Clone this repository to your local machine:

   ```bash
   git clone <repository-url>

