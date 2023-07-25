#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TalentQuest.API/TalentQuest.API.csproj", "TalentQuest.API/"]
COPY ["TalentQuest.Services/TalentQuest.Services.csproj", "TalentQuest.Services/"]
COPY ["TalentQuest.Common/TalentQuest.Common.csproj", "TalentQuest.Common/"]
COPY ["TalentQuest.Data/TalentQuest.Data.csproj", "TalentQuest.Data/"]
RUN dotnet restore "TalentQuest.API/TalentQuest.API.csproj"
COPY . .
WORKDIR "/src/TalentQuest.API"
RUN dotnet build "TalentQuest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TalentQuest.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ConnectionStrings__TalentQuestContext=Server=db;Database=TalentQuestDb;User=sa;Password=Admin123*;TrustServerCertificate=true;
ENTRYPOINT ["dotnet", "TalentQuest.API.dll"]