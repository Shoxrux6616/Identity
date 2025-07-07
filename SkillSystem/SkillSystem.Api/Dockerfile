# Use the official ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY SkillSystem.sln ./
COPY SkillSystem.Api/SkillSystem.Api.csproj SkillSystem.Api/
COPY SkillSystem.Bll/SkillSystem.Bll.csproj SkillSystem.Bll/
COPY SkillSystem.DataAccess/SkillSystem.DataAccess.csproj SkillSystem.DataAccess/
COPY SkillSystem.Repository/SkillSystem.Repository.csproj SkillSystem.Repository/

# Restore NuGet packages
RUN dotnet restore

# Copy the rest of the files and build the project
COPY . .
WORKDIR /src/SkillSystem.Api
RUN dotnet publish -c Release -o /app/publish

# Final stage: use SDK image (to allow dotnet ef commands)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SkillSystem.Api.dll"]
