using System.Runtime.Serialization;

namespace Discord.Options
{
/// <summary>
/// A class representing the external link options for the site. This class cannot be inherited.
/// </summary>
public sealed class ExternalLinksOptions
{
    /// <summary>
    /// Gets or sets the URI of the API.
    /// </summary>
    public Uri? Api { get; set; }

    /// <summary>
    /// Gets or sets the URI of the CDN.
    /// </summary>
    public Uri? Cdn { get; set; }

    /// <summary>
    /// Gets or sets the URI of the skill.
    /// </summary>
    public Uri? Skill { get; set; }

        /// <summary>
        /// Gets or sets the options for the URIs to use for reports.
        /// </summary>
    public ReportOptions? Reports { get; set; }
}
}
