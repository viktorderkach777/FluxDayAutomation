FROM microsoft/dotnet:2.2-sdk-alpine
WORKDIR /app
COPY . .
COPY /home/viktorderkach7viktorderkach777/.nuget/ /root/.nuget/
RUN dotnet restore && dotnet test
