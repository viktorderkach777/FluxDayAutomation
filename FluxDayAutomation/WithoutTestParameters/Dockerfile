FROM microsoft/dotnet:sdk AS builder
WORKDIR /app
COPY . .

#RUN cd ./FluxDayAutomation
RUN dotnet restore && dotnet test

# run tests on docker build
#RUN dotnet test

# run tests on docker run
#ENTRYPOINT ["dotnet", "test"]
