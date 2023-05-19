#!/bin/sh

./cloud-sql-proxy --private-ip engaged-hook-384215:us-central1:test &
sleep 15
migrate -path ${MIGRATION_PATH} -database postgres://${DB_USER}:${DB_PASS}@127.0.0.1:5432/${DB_NAME}?sslmode=disable up
sleep 5
