﻿using Microsoft.AspNetCore.Authentication;

namespace Discord.Options
{
public sealed class SiteOptions
{
    ///// <summary>
    ///// Gets or sets the Alexa options for the site.
    ///// </summary>
    //public AlexaOptions? Alexa { get; set; }

    ///// <summary>
    ///// Gets or sets the analytics options for the site.
    ///// </summary>
    //public AnalyticsOptions? Analytics { get; set; }

    ///// <summary>
    ///// Gets or sets the options for the API.
    ///// </summary>
    //public ApiOptions? Api { get; set; }

    /// <summary>
    /// Gets or sets the authentication options.
    /// </summary>
    public AuthenticationOptions? Authentication { get; set; }

        /// <summary>
        /// Gets or sets the certificate transparency options to use.
        /// </summary>
        public CertificateTransparencyOptions? CertificateTransparency { get; set; }

        /// <summary>
        /// Gets or sets the Content Security Policy origins for the site.
        /// </summary>
        public IDictionary<string, IList<string>>? ContentSecurityPolicyOrigins { get; set; }

        /// <summary>
        /// Gets or setsht the external link options for the site.
        /// </summary>
        public ExternalLinksOptions? ExternalLinks { get; set; }

        ///// <summary>
        ///// Gets or sets the metadata options for the site.
        ///// </summary>
        //public MetadataOptions? Metadata { get; set; }

        ///// <summary>
        ///// Gets or sets the options for the TfL API integration.
        ///// </summary>
        //public TflOptions? Tfl { get; set; }
    }

}
