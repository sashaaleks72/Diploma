FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Diploma.sln .
COPY ./*.csproj .

RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish Diploma.sln -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_URLS=http://*:44374
ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 44374

ENTRYPOINT ["dotnet", "Diploma.dll"]