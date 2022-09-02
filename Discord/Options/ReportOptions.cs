namespace Discord.Options
{
   /// <summary>
/// A class representing the options for reports. This class cannot be inherited.
/// </summary>
public sealed class ReportOptions
{
    /// <summary>
    /// Gets or sets the URI to use for <c>Content-Security-Policy</c>.
    /// </summary>
    public Uri? ContentSecurityPolicy { get; set; }

    /// <summary>
    /// Gets or sets the URI to use for <c>Content-Security-Policy-Report-Only</c>.
    /// </summary>
    public Uri? ContentSecurityPolicyReportOnly { get; set; }

    /// <summary>
    /// Gets or sets the URI to use for <c>Expect-CT</c>.
    /// </summary>
    public Uri? ExpectCTEnforce { get; set; }

    /// <summary>
    /// Gets or sets the URI to use for <c>Expect-CT</c> when not enforced.
    /// </summary>
    public Uri? ExpectCTReportOnly { get; set; }

    /// <summary>
    /// Gets or sets the URI to use for <c>Expect-Staple</c>.
    /// </summary>
    public Uri? ExpectStaple { get; set; }
}

}
