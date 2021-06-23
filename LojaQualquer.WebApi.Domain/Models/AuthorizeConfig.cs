using System;

namespace LojaQualquer.WebApi.Domain.Models
{
    public class AuthorizeConfig
    {
        public string Key { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public TimeSpan Duration { get; set; }
    }
}