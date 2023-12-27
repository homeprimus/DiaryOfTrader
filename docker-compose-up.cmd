rem
rem Размещение образов ASP.NET Core с помощью Docker по протоколу HTTPS
rem https://learn.microsoft.com/ru-ru/aspnet/core/security/docker-https?view=aspnetcore-8.0
rem
rem Developing ASP.NET Core Applications with Docker over HTTPS
rem https://github.com/dotnet/dotnet-docker/blob/main/samples/run-aspnetcore-https-development.md
rem

docker build -t diaryoftraderwebapi . -f Dockerfile.WinApi

dotnet dev-certs https -ep %USERPROFILE%/.aspnet/https/diaryoftraderwebapi.pfx -p !qazxsw2 rem = Certificates__Default__Password
dotnet dev-certs https --trust

docker pull diaryoftraderwebapi

docker compose --env-file configure.env up
