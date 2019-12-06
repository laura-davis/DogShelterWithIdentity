# DogShelter

sudo docker run -e 'ACCEPT_EULA=Y' \
-e 'SA_PASSWORD=P@ssw0rd!' \
-p 1433:1433 \
--name sql1 \
-d microsoft/mssql-server-linux:2017-latest
