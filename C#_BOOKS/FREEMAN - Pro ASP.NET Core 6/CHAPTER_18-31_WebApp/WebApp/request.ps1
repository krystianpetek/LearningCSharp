Invoke-WebRequest https://localhost:7200/home/list | Select-Object -ExpandProperty RawContent

Invoke-RestMethod http://localhost:5000/controllers/form/body -Method POST -Body (@{
Name="Soccer Boots"; Price=89.99} | ConvertTo-Json) -ContentType "application/json"