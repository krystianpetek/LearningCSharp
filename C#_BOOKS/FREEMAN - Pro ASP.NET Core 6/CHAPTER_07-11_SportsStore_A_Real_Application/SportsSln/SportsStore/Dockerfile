FROM mcr.microsoft.com/dotnet/aspnet:7.0

COPY /bin/Release/net7.0/publish/ SportsStore/

ENV ASPNETCORE_ENVIRONMENT Production
ENV Logging__Console__FormatterName=Simple

EXPOSE 7983
WORKDIR /SportsStore
ENTRYPOINT ["dotnet", "SportsStore.dll", "--urls=http://0.0.0.0:5267"]