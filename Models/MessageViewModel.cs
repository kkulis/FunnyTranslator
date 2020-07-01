using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Translator.Models
{
    public class MessageViewModel
    {
        [JsonProperty(PropertyName = "translated")]
        public string Translated { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "translation")]
        public string Translation { get; set; }
    }
}