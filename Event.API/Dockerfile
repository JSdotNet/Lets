FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 27433
EXPOSE 44398

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Event.API/Event.API.csproj", "Event.API/"]
RUN dotnet restore "Event.API/Event.API.csproj"
COPY . .
WORKDIR "/src/Event.API"
RUN dotnet build "Event.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Event.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Event.API.dll"]