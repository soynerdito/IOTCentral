FROM node:10.13.0-alpine as node
WORKDIR /app
COPY package*.json ./
RUN npm install --progress=true --loglevel=silent
RUN npm run build

FROM microsoft/dotnet:2.2-sdk-alpine AS builder
WORKDIR /source
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -r linux-musl-x64 -o /app

FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=builder /app .
COPY --from=node /app/build ./wwwroot
ENTRYPOINT ["./IOTCentral"]