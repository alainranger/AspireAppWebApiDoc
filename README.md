# Documentation d'une api web

## Ajouter la documentation dans un project web api

Depuis .Net 9 [Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore?tab=readme-ov-file#swashbuckleaspnetcoreswaggerui) à été remplacé par OpenAPI dans le template d'un projet webapi.  Heureusement on peut le remettre en seulement quelques lignes de codes.  Je vais aussi explorer 2 autres libraire de documentation de d'api web, [RedDoc](https://github.com/domaindrivendev/Swashbuckle.AspNetCore?tab=readme-ov-file#swashbuckleaspnetcoreredoc) et [Scalar](https://scalar.com).

## Étapes pour ajouter la documentation à notre api web

1. Ajouter les packages nuget.
1. Ajouter les services de documentation dans program.cs

### Ajouter les packages nuget

1. Pour Swagger on a besoin d'ajouter le package "Swashbuckle.AspNetCore.SwaggerUI"

    ```bash
    dotnet add package Swashbuckle.AspNetCore.SwaggerUI
    ```

1. Pour ReDoc on a besoin d'ajouter le package "Swashbuckle.AspNetCore.ReDoc"

    ```bash
    dotnet add package Swashbuckle.AspNetCore.ReDoc
    ```

1. Pour ReDoc on a besoin d'ajouter le package "Scalar.AspNetCore"

    ```bash
    dotnet add package Scalar.AspNetCore
    ```

### Configurer le service de documentation dans program.cs

1. Pour Swagger

    ```bash
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "AspireAppWebApiDoc.ApiService v1");
    });
    ```

    La documentation est accessible par l'url [BaseURL]/swagger

1. Pour ReDoc

    ```bash
    app.UseReDoc(options =>
    {
        options.SpecUrl("/openapi/v1.json");
    });
    ```

    La documentation est accessible par l'url [BaseURL]/api-docs

1. Pour Scalar

    ```bash
    app.MapScalarApiReference();
    ```

    La documentation est accessible par l'url [BaseURL]/scalar
