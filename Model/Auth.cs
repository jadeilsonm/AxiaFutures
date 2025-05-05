﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AxiaFutures.Model
{
    internal class Auth
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; } = String.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = String.Empty;
    }
}
