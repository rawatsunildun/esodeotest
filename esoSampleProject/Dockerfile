##See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
##Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
##For more information, please see https://aka.ms/containercompat
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["esoSampleProject/esoSampleProject.csproj", "esoSampleProject/"]
#RUN dotnet restore "esoSampleProject/esoSampleProject.csproj"
#COPY . .
#WORKDIR "/src/esoSampleProject"
#RUN dotnet build "esoSampleProject.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "esoSampleProject.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "esoSampleProject.dll"]


FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build

EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /app
COPY --from=build /app/published-app /app
ENTRYPOINT [ "dotnet", "/app/esoSampleProject.dll" ]