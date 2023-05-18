#!/bin/sh

# Set the environment variables
export MIGRATION_PATH="$MIGRATION_PATH"
export DB_USER="$DB_USER"
export DB_PASS="$DB_PASS"
export DB_HOST="$DB_HOST"
export DB_NAME="$DB_NAME"

# Execute the migration command
migrate -path "$MIGRATION_PATH" -database "postgres://$DB_USER:$DB_PASS@$DB_HOST/$DB_NAME" up
