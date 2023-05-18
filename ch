# Stage 1: Build Go binary
FROM golang:1.19 AS build

WORKDIR /app

RUN go install github.com/GoogleCloudPlatform/cloud-run-proxy@main

# Stage 2: Create the final image with Nginx
FROM nginx:1.23.3

# Copy the Go binary from the build stage
COPY --from=build go/bin/cloud-run-proxy /usr/local/bin/cloud-run-proxy

# Copy your Nginx configuration and static files


# Expose the necessary ports
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
