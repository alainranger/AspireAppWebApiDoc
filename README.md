# Documentation d'une api web

[English version](#english-version)

Dans ce dépot je vais ajouter le générateur de documentation à l'api web et je vais ajouter une commande dans le dashboard aspire pour accèder à cette documentation.

* [Ajouter la documentation dans un project web api](#ajouter-la-documentation-dans-un-project-web-api)
* [Ajouter une commande dans le dashboard aspire](#ajouter-une-commande-dans-le-dashboard-aspire)

## Ajouter la documentation dans un project web api

Depuis .Net 9 [Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore?tab=readme-ov-file#swashbuckleaspnetcoreswaggerui) à été remplacé par OpenAPI dans le template d'un projet webapi.  Heureusement on peut le remettre en seulement quelques lignes de codes.  Je vais aussi explorer 2 autres libraire de documentation de d'api web, [RedDoc](https://github.com/domaindrivendev/Swashbuckle.AspNetCore?tab=readme-ov-file#swashbuckleaspnetcoreredoc) et [Scalar](https://scalar.com).

## Étapes pour ajouter la documentation à notre api web

1. [Ajouter les packages nuget](#ajouter-les-packages-nuget).
1. [Configurer le service de documentation](#configurer-le-service-de-documentation).

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

### Configurer le service de documentation

Modifier [program.cs](AspireAppWebApiDoc.ApiService/Program.cs)

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

Pour garder notre ficier program.cs le plus propre possible.  L'ajout de la commande sera fait dans une méthode d'extension dans le fichier "[Extension\ResourceBuilderExtensions.cs](AspireAppWebApiDoc.AppHost/Extensions/ResourceBuilderExtensions.cs)".

## English version

In this repository I will add the documentation generator to the web api and I will add a command in the aspire dashboard to access this documentation.

* [Add the documentation in a web api project](#add-the-documentation-in-a-web-api-project)
* [Add a command in the aspire dashboard](#add-a-command-in-the-aspire-dashboard)

## Add the documentation in a web api project

Since .Net 9 [Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore?tab=readme-ov-file#swashbuckleaspnetcoreswaggerui) has been replaced by OpenAPI in the template of a webapi project. Fortunately we can put it back in just a few lines of code. I will also explore 2 other web api documentation libraries, [RedDoc](https://github.com/domaindrivendev/Swashbuckle.AspNetCore?tab=readme-ov-file#swashbuckleaspnetcoreredoc) and [Scalar](https://scalar.com).

## Steps to add the documentation to our web api

1. [Add the nuget packages](#add-the-nuget-packages).
1. [Configure the documentation service](#configure-the-documentation-service).

### Add the nuget packages

1. For Swagger we need to add the package "Swashbuckle.AspNetCore.SwaggerUI"

    ```bash
    dotnet add package Swashbuckle.AspNetCore.SwaggerUI
    ```

1. For ReDoc we need to add the package "Swashbuckle.AspNetCore.ReDoc"

    ```bash
    dotnet add package Swashbuckle.AspNetCore.ReDoc
    ```

1. For ReDoc we need to add the package "Scalar.AspNetCore"

    ```bash
    dotnet add package Scalar.AspNetCore
    ```

### Configure the documentation service

Modify [program.cs](AspireAppWebApiDoc.ApiService/Program.cs)

1. For Swagger

    ```bash
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "AspireAppWebApiDoc.ApiService v1");
    });
    ```

    The documentation is accessible by the url [BaseURL]/swagger

1. For ReDoc

    ```bash
    app.UseReDoc(options =>
    {
        options.SpecUrl("/openapi/v1.json");
    });
    ```

    The documentation is accessible by the url [BaseURL]/api-docs

1. For Scalar

    ```bash
    app.MapScalarApiReference();
    ```

    The documentation is accessible by the url [BaseURL]/scalar

## Add a command in the aspire dashboard

Now that we have a documentation generator for our web api. It would be nice to be able to access it from the aspire dashboard.

To add and configure the command to our web api we must use "WithCommand" in the [program.cs](AspireAppWebApiDoc.AppHost/program.cs) file of the "AspireAppWebApiDoc.AppHost" project.

To keep our [program.cs](AspireAppWebApiDoc.AppHost/program.cs) file as clean as possible. Adding the command will be done in an extension method in the "[Extension\ResourceBuilderExtensions.cs](AspireAppWebApiDoc.AppHost/Extensions/ResourceBuilderExtensions.cs)" file.
