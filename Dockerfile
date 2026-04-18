FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY FPTU_PRN222_SE1811_ASM02_SE180198_VinhHNT.sln .
COPY CKFS_Management.Entities.VinhHNT/*.csproj ./CKFS_Management.Entities.VinhHNT/
COPY CKFS_Management.Repositories.VinhHNT/*.csproj ./CKFS_Management.Repositories.VinhHNT/
COPY CKFS_Management.Services.VinhHNT/*.csproj ./CKFS_Management.Services.VinhHNT/
COPY CKFS_Management.RazorwebApp.VinhHNT/*.csproj ./CKFS_Management.RazorwebApp.VinhHNT/

RUN dotnet restore FPTU_PRN222_SE1811_ASM02_SE180198_VinhHNT.sln

COPY CKFS_Management.Entities.VinhHNT/ ./CKFS_Management.Entities.VinhHNT/
COPY CKFS_Management.Repositories.VinhHNT/ ./CKFS_Management.Repositories.VinhHNT/
COPY CKFS_Management.Services.VinhHNT/ ./CKFS_Management.Services.VinhHNT/
COPY CKFS_Management.RazorwebApp.VinhHNT/ ./CKFS_Management.RazorwebApp.VinhHNT/

RUN dotnet publish CKFS_Management.RazorwebApp.VinhHNT/CKFS_Management.RazorwebApp.VinhHNT.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "CKFS_Management.RazorwebApp.VinhHNT.dll"]
