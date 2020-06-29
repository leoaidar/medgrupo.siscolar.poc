# medgrupo.siscolar.poc

Sistema Escolar da Prefeitura 

***Requirements***
Angular CLI: 10.0.0
Node: 12+
Angular: 10.0.1
Node v12+
Dotnet Core v3.1
SqlServer set differrent password in webconfig

git clone https://github.com/leoaidar/medgrupo.siscolar.poc.git

cd medgrupo.siscolar.poc/Medgrupo.Siscolar.Infra/

dotnet ef database update -c SiscolarDbContext  -s ../Medgrupo.Siscolar.Api/

cd medgrupo.siscolar.poc/Medgrupo.Siscolar.Api/

dotnet run

open the browser and type: 
  http://localhost:5011/swagger/index.html
  OR
  https://localhost:5010/swagger/index.html


Run Anglular App

cd medgrupo.siscolar.poc/Presentation/angular-siscolar-medgrupo/

ng serve

open the browser and type: 
  http://localhost:4200
  

:)
