FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY LibraryApi.sln ./
COPY src/LibraryApi.DAL/LibraryApi.DAL.csproj src/LibraryApi.DAL/
COPY src/LibraryApi.BLL/LibraryApi.BLL.csproj src/LibraryApi.BLL/
COPY src/LibraryApi.API/LibraryApi.API.csproj src/LibraryApi.API/
RUN dotnet restore src/LibraryApi.API/LibraryApi.API.csproj
COPY src/ src/
RUN dotnet publish src/LibraryApi.API/LibraryApi.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "LibraryApi.API.dll"]
