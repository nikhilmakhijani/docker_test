FROM node:12-alpine
RUN apk add --no-cache python2 g++ make
WORKDIR /app
COPY . .
RUN yarn install --production
CMD ["node", "src/index.js"]
EXPOSE 3000

The problem that you encountered was that both the development and production versions of your application were using the latest version of the Terraform module in the backend. This meant that any changes made to the module could potentially impact both versions of the application simultaneously, which could cause issues and make it difficult to troubleshoot problems.

To address this issue, you added versioning capabilities to the Terraform module. This involved assigning a unique identifier (such as a version number) to each version of the module, and then specifying which version of the module should be used by each version of the application.

By doing this, you were able to ensure that the development and production versions of the application could each use their own, separate version of the Terraform module. This made it much easier to manage changes and troubleshoot issues, because any changes made to the module would only impact one version of the application at a time.

The result of adding versioning capabilities to the Terraform module was a more stable and reliable application development process. By having separate versions of the module for each version of the application, you were able to make sure that changes were carefully controlled and tested before being rolled out to the entire system. This reduced the likelihood of errors or bugs, and made it easier to maintain the overall quality of the application over 