# Documentation d'une api web

Dans ce dépot je vais ajouter le générateur de documentation à l'api web et je vais ajouter une commande dans le dashboard aspire pour accèder à cette documentation.

* [Ajouter la documentation dans un project web api](#ajouter-la-documentation-dans-un-project-web-api)
* [Ajouter une commande dans le dashboard aspire](#ajouter-une-commande-dans-le-dashboard-aspire)

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

## Ajouter une commande dans le dashboard aspire

Maintenant que nous avons un générateur de documentation pour notre api web.  Ça serait bien de pouvoir y accéder à partir du dashboard aspire.  

Pour ajouter et configurer la commande à notre api web on doit utiliser "WithCommand" dans dans le fichier program.cs du projet "AspireAppWebApiDoc.AppHost".

Pour garder notre ficier program.cs le plus propre possible.  L'ajout de la commande sera fait dans une méthode d'extension dans le fichier "Extension\".
