#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AConsumer.WebApi/AConsumer.WebApi.csproj", "AConsumer.WebApi/"]
RUN dotnet restore "AConsumer.WebApi/AConsumer.WebApi.csproj"
COPY . .
WORKDIR "/src/AConsumer.WebApi"
RUN dotnet build "AConsumer.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AConsumer.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AConsumer.WebApi.dll"]