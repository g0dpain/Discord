using Discord.Middleware;
using Discord.Options;
using Microsoft.Extensions.Options;

namespace Discord.Extensions
{
    /// <summary>
/// A class containing extension methods for the <see cref="IApplicationBuilder"/> interface. This class cannot be inherited.
/// </summary>
public static class IApplicationBuilderExtensions
{
    /// <summary>
    /// Adds the custom HTTP headers middleware to the pipeline.
    /// </summary>
    /// <param name="value">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
    /// <param name="environment">The current hosting environment.</param>
    /// <param name="config">The current configuration.</param>
    /// <param name="options">The current site options.</param>
    /// <returns>
    /// The value specified by <paramref name="value"/>.
    /// </returns>
    public static IApplicationBuilder UseCustomHttpHeaders(
        this IApplicationBuilder value,
        IWebHostEnvironment environment,
        IConfiguration config,
        IOptionsMonitor<SiteOptions> options)
    {
        return value.UseMiddleware<CustomHttpHeadersMiddleware>(environment, config, options);
    }

    /// <summary>
    /// Configures the application to use identity.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/> to configure.</param>
    /// <param name="options">The current site configuration.</param>
    public static void UseIdentity(this IApplicationBuilder app, SiteOptions options)
    {
        if (options?.Authentication?.IsEnabled == true)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}

}
