# medgrupo.siscolar.poc

Sistema Escolar da Prefeitura 

***Requirements***
Angular CLI: 10.0.0
Node: 12+
Angular: 10.0.1
Node v12+
Dotnet Core v3.1

SqlServer set differrent password in appsettings.Development.json | appsettings.Development.json
  "ConnectionStrings": {
    "SiscolarDbConnection":"..."
  }

git clone https://github.com/leoaidar/medgrupo.siscolar.poc.git

cd medgrupo.siscolar.poc/Medgrupo.Siscolar.Infra/

dotnet ef database update -c SiscolarDbContext  -s ../Medgrupo.Siscolar.Api/

cd medgrupo.siscolar.poc/Medgrupo.Siscolar.Api/

dotnet run

open the browser and type: 
  http://localhost:5000/swagger/index.html
  http://localhost:5011/swagger/index.html
  OR
  https://localhost:5001/swagger/index.html
  https://localhost:5010/swagger/index.html


Run Angular Hotsite

cd medgrupo.siscolar.poc/Presentation/angular-siscolar-medgrupo/

npm install

ng serve

open the browser and type: 
  http://localhost:4200
  

:)
