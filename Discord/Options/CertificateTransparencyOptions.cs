namespace Discord.Options
{
   /// <summary>
/// A class representing the options to use for the <c>Expect-CT</c>
/// HTTP response header. This class cannot be inherited.
/// </summary>
public sealed class CertificateTransparencyOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether to enforce certificate transparency.
    /// </summary>
    public bool Enforce { get; set; }

    /// <summary>
    /// Gets or sets the maximum period of time to cache the policy for.
    /// </summary>
    public TimeSpan MaxAge { get; set; }
}
}
