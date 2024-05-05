FROM mcr.microsoft.com/dotnet/aspnet AS base
WORKDIR /app

RUN mkdir Files

FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /src
COPY ["fileServer.csproj", "/src"]
RUN dotnet restore "fileServer.csproj"
COPY . .
RUN dotnet build "fileServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "fileServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "fileServer.dll" ]