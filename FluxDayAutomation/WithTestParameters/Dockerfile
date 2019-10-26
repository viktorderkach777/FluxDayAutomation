FROM microsoft/dotnet:sdk AS builder
WORKDIR /app
COPY . .

ARG some_variable_name
RUN dotnet restore 
RUN dotnet test --filter TestCategory=$some_variable_name
