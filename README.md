# medgrupo.siscolar.poc

Sistema Escolar da Prefeitura 

git clone https://github.com/leoaidar/medgrupo.siscolar.poc.git

cd medgrupo.siscolar.poc/Medgrupo.Siscolar.Infra/

dotnet ef database update -c SiscolarDbContext  -s ../Medgrupo.Siscolar.Api/

cd .. / cd ..

cd medgrupo.siscolar.poc/Medgrupo.Siscolar.Api/

dotnet run

open the browser and type: 
  http://localhost:5011/swagger/index.html
  OR
  https://localhost:5010/swagger/index.html


curl --location --request POST 'http://localhost:5011/v1/schools' \
--header 'Content-Type: application/json' \
--data-raw '{
"Name": "Escola São Pedro da Aldeia",
"maxSchoolClass": 0,
"maxSchoolStudents": 0,
"schoolPrincipal": "Leonardo Aidar"
}'

