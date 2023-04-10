FROM  mcr.microsoft.com/dotnet/aspnet:6.0


WORKDIR /src
COPY . .
RUN dotnet restore "Conley.SocialPlatform.Bugers.API/Conley.SocialPlatform.Bugers.API.csproj"
COPY . .
WORKDIR /src/Conley.SocialPlatform.Bugers.API
RUN dotnet publish "Conley.SocialPlatform.Bugers.API.csproj" -c Release -o /app

EXPOSE 8088
WORKDIR /app
COPY --from=publish /app .
CMD ["dotnet", "Conley.SocialPlatform.Bugers.API.dll"]

