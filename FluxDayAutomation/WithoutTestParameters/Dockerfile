FROM microsoft/dotnet:2.2-sdk-alpine
WORKDIR /app
COPY . .
RUN dotnet restore && dotnet test
