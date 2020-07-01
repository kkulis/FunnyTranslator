using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Translator.Models;
using Translator.Services;

namespace Translator.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ITranslatorService translatorService;

        public HomeController(ITranslatorService translatorService)
        {
            this.translatorService = translatorService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(MessageViewModel messageViewModel)
        {
            if (ModelState.IsValid)
            {
                var message = await translatorService.YodaTranslate(messageViewModel);
                ViewData["Message"] = message;
            }
            return View();
        }

    }
}