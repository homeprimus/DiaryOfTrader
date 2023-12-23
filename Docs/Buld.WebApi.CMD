rem
rem Размещение образов ASP.NET Core с помощью Docker по протоколу HTTPS
rem https://learn.microsoft.com/ru-ru/aspnet/core/security/docker-https?view=aspnetcore-8.0
rem
rem Developing ASP.NET Core Applications with Docker over HTTPS
rem https://github.com/dotnet/dotnet-docker/blob/main/samples/run-aspnetcore-https-development.md
rem

cd ..
docker build -t diaryoftraderwebapi . -f Dockerfile.WinApi

dotnet dev-certs https -ep ${HOME}/.aspnet/https/diaryoftraderwebapi.pfx -p !qazxsw2
dotnet dev-certs https --trust

rem docker pull diaryoftraderwebapi
docker run --rm -it -d -p 32778:80 -p 32779:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=32779 -e ASPNETCORE_Kestrel__Certificates__Default__Password="!qazxsw2" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/diaryoftraderwebapi.pfx -v ${HOME}/.aspnet/https:/https/ --name DiaryOfTrader.WebApi diaryoftraderwebapi
