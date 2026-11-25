# TwitterAPI
Proyecto realizado a partir de la capacitación que tuve en GLOBANT.
Desarrollo en .NET. Desarrollo de una aplicación web sencilla con .NET, Microsoft SQL Server. Testing 
de la API a través de Swagger. Documentación y presentación del proyecto en inglés.

## Configuración

El endpoint de noticias usa [NewsAPI](https://newsapi.org). La API key no se guarda en el repositorio;
se lee de la configuración `NewsApi:ApiKey`. Para desarrollo local:

```
cd Globant.Mentoring.Twitter
dotnet user-secrets init
dotnet user-secrets set "NewsApi:ApiKey" "<tu-api-key>"
```

También se puede definir con la variable de entorno `NewsApi__ApiKey`.
