FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln ./
COPY REST/*.csproj REST/
COPY Models/*.csproj Models/
COPY BusinessLayer/*.csproj BusinessLayer/
COPY DataLayer/*.csproj DataLayer/

RUN cd REST && dotnet restore
COPY . .
RUN dotnet publish REST -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "REST.dll"]