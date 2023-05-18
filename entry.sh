#!/bin/sh

# Substitute environment variables in the entrypoint script
envsubst "\$MIGRATION_PATH" < /entry.template.sh > /entry.sh
envsubst "\$$DB_USER" < /entry.template.sh > /entry.sh
envsubst "\$$DB_PASS" < /entry.template.sh > /entry.sh
envsubst "\$$DB_HOST" < /entry.template.sh > /entry.sh
envsubst "\$$DB_NAME" < /entry.template.sh > /entry.sh

# Make the entrypoint script executable
chmod +x /entry.sh

# Execute the migration command
/entry.sh
