
using System.Diagnostics;
using Aspire.Hosting.ApplicationModel;
using Microsoft.Extensions.Diagnostics.HealthChecks;

internal static class ResourceBuilderExtensions
{
    /// <summary>
    /// Add a command to the resource to navigate to the Swagger UI documentation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <returns>
    /// The resource builder
    // </returns>
    internal static IResourceBuilder<T> WithSwaggerUI<T>(this IResourceBuilder<T> builder)
        where T : IResourceWithEndpoints
    {
        return builder.WithOpenApiDocs("swagger-ui-docs", "Swagger API Documentation", "swagger");
    }

    /// <summary>
    /// Add a command to the resource to navigate to the Scalar API documentation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <returns>
    /// The resource builder
    // </returns>
    internal static IResourceBuilder<T> WithScalar<T>(this IResourceBuilder<T> builder)
        where T : IResourceWithEndpoints
    {
        return builder.WithOpenApiDocs("scalar-docs", "Scalar API Documentation", "scalar/v1");
    }

    /// <summary>
    /// Add a command to the resource to navigate to the ReDoc API documentation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <returns>
    /// The resource builder
    // </returns>
    internal static IResourceBuilder<T> WithReDoc<T>(this IResourceBuilder<T> builder)
        where T : IResourceWithEndpoints
    {
        return builder.WithOpenApiDocs("redoc-docs", "ReDoc API Documentation", "api-docs");
    }

    /// <summary>
    /// Add a command to the resource to navigate to the OpenAPI documentation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <param name="name"></param>
    /// <param name="displayName"></param>
    /// <param name="openApiUIPath"></param>
    /// <returns>
    /// The resource builder
    // </returns>
    private static IResourceBuilder<T> WithOpenApiDocs<T>(this IResourceBuilder<T> builder,
        string name,
        string displayName,
        string openApiUIPath)
    where T : IResourceWithEndpoints
    {
        return builder.WithCommand(
            name,
            displayName,
            executeCommand: async _ =>
            {
                try
                {
                    await Task.Run(() =>
                    {
                        // Base URL
                        var endPoint = builder.GetEndpoint("https");

                        var url = $"{endPoint.Url}/{openApiUIPath}";

                        Process.Start(new ProcessStartInfo(url)
                        {
                            UseShellExecute = true
                        });
                    });

                    return new ExecuteCommandResult
                    {
                        Success = true
                    };
                }
                catch (Exception ex)
                {
                    return new ExecuteCommandResult
                    {
                        Success = false,
                        ErrorMessage = ex.ToString()
                    };
                }
            },
            updateState: context => context.ResourceSnapshot.HealthStatus == HealthStatus.Healthy ?
                ResourceCommandState.Enabled : ResourceCommandState.Disabled,
            iconName: "DocumentLink",
            iconVariant: IconVariant.Filled
        );
    }
}