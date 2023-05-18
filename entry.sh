#!/bin/sh

# Substitute environment variables in the entrypoint script
envsubst < /entry.template.sh > /entry.sh

# Make the entrypoint script executable
chmod +x /entry.sh

# Execute the migration command
/entry.sh
