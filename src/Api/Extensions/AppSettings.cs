﻿namespace Api.Extensions
{
    public class AppSettings
    {
        public string? Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string? Emissor { get; set; }
        public string? ValidaEm { get; set; }
    }
}
