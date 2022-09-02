namespace Discord.Options
{
   public sealed class ExternalSignInOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether the provider is enabled.
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary>
    /// Gets or sets the client Id for the provider.
    /// </summary>
    public string? ClientId { get; set; }

    /// <summary>
    /// Gets or sets the client secret for the provider.
    /// </summary>
    public string? ClientSecret { get; set; }
}
}
