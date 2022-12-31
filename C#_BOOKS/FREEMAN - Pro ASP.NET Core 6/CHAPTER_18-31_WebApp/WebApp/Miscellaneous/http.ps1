nvoke-RestMethod https://localhost:7200/api/products -Method Post -Body (@{Name="Swimming Googles";Price=12.80;CategoryId=1;SupplierId=1} | ConvertTo-Json) -ContentType "application/json"

Invoke-WebRequest http://localhost:5000/api/products/1000 | Select-Object StatusCode