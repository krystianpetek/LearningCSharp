nvoke-RestMethod https://localhost:7200/api/products -Method Post -Body (@{Name="Swimming Googles";Price=12.80;CategoryId=1;SupplierId=1} | ConvertTo-Json) -ContentType "application/json"

Invoke-WebRequest https://localhost:7200/api/products/1000 | Select-Object StatusCode

Invoke-WebRequest https://localhost:7200/api/content/string | select @{n='Content-Type';e={$_.Headers."Content-Type"}}, Content, StatusCode

Invoke-WebRequest https://localhost:7200/api/content/object | select @{n='Content-Type';e={$_.Headers."Content-Type"}}, Content, StatusCode

invoke-webrequest https://localhost:7200/api/content/object -Headers @{Accept="img/png"} | select @{n='Content-Type';e={$_.Headers."Content-Type"}}, Content, StatusCode

invoke-webrequest https://localhost:7200/api/content/object -Headers @{Accept="application/xml"} | select @{n='Content-Type';e={$_.Headers."Content-Type"}}, Content, StatusCode

invoke-webrequest https://localhost:7200/api/content/object -Headers @{Accept="application/xml,*/*;q=0.8"} | select @{n='Content-Type';e={$_.Headers."Content-Type"}}, Content, StatusCode

Invoke-RestMethod https://localhost:7200/api/content/object -Method POST -Body (@{Name="Swimming Googles";Price=12.75;CategoryId=1;SupplierId=1} | ConvertTo-Json) -ContentType "application/json"

Invoke-RestMethod https://localhost:7200/api/content -Method POST -Body "<ProductBindingTarget xmlns=`"http://schemas.datacontract.org/2004/07/WebApp.Models`"><CategoryId>1</CategoryId><Name>Kayak</Name><Price>275.00</Price><SupplierId>1</SupplierId></ProductBindingTarget>" -ContentType "application/xml"


Invoke-RestMethod https://localhost:7200/api/content/ -Method POST -Body (@{Name="Swimming Googles";Price=12.75;CategoryId=1;SupplierId=1} | ConvertTo-Json) -ContentType "application/json"

Invoke-RestMethod https://localhost:7200/api/content -Method POST -Body "<ProductBindingTarget xmlns=`"http://schemas.datacontract.org/2004/07/WebApp.Models`"><CategoryId>1</CategoryId><Name>Kayak</Name><Price>275.00</Price><SupplierId>1</SupplierId></ProductBindingTarget>" -ContentType "application/xml"