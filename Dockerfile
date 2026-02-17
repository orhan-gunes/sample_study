#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SampleStudy.Application/SampleStudy.Application.csproj", "SampleStudy.Application/"]
COPY ["SampleStudy.Domain/SampleStudy.Domain.csproj", "SampleStudy.Domain/"]
COPY ["SampleStudy.InfraStructure/SampleStudy.InfraStructure.csproj", "SampleStudy.InfraStructure/"]
COPY ["SampleStudy.Api/SampleStudy.Api.csproj", "SampleStudy.Api/"]

RUN dotnet restore "SampleStudy.Api/SampleStudy.Api.csproj"
COPY . .
WORKDIR "/src/SampleStudy.Api"
RUN dotnet build "SampleStudy.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SampleStudy.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleStudy.Api.dll"]