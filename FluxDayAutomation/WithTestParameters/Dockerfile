FROM microsoft/dotnet:2.2-sdk-alpine
WORKDIR /app
COPY . .

ARG variable_name
RUN dotnet restore && dotnet test --filter TestCategory=$variable_name
