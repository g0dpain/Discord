namespace Discord.Options
{
    public sealed class AuthenticationOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether authentication with the website is enabled.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the external sign-in providers for the site.
        /// </summary>
        public IDictionary<string, ExternalSignInOptions>? ExternalProviders { get; set; }

        ///// <summary>
        ///// Gets or sets the user store options.
        ///// </summary>
        //public UserStoreOptions? UserStore { get; set; }
    }

}
