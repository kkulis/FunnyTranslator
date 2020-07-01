using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Translator.Models;

namespace Translator.Services
{
    public interface ITranslatorService
    {
        Task<string> YodaTranslate(MessageViewModel messageViewModel);
    }
    public class TranslatorService : ITranslatorService
    {
        public string MessageTranslated { get; set; }

        public async Task<string> YodaTranslate(MessageViewModel messageViewModel)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://api.funtranslations.com/translate/");

            var uri = string.Format("https://api.funtranslations.com/translate/yoda.json?text={0}",
                                                      Uri.EscapeDataString(messageViewModel.Text));

            var response = await client.GetAsync(uri);

            var json = await response.Content.ReadAsStringAsync();

            var message = JsonConvert.DeserializeObject<Translation>(json);

            return message.Contents.Translated;

        }
    }
}