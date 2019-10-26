FROM microsoft/dotnet:sdk AS builder
WORKDIR /app
COPY . .

RUN dotnet restore

# run tests on docker build
RUN dotnet test

# run tests on docker run
ENTRYPOINT ["dotnet", "test"]