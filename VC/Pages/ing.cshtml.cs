using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;

// Replacement page for ingredients page that resets the results after each run

namespace AspNetCoreVerifiableCredentials.Pages
{
    public class Index2Model2 : PageModel
    {
        protected IMemoryCache _credentialCache;

        public Index2Model2(IMemoryCache memoryCache)
        {
            _credentialCache = memoryCache;
        }

        public string Message { get; private set; } = "PageModel in C# with reset on refresh";

        public JsonResult OnGet()
        {
            _credentialCache.TryGetValue("credentialData", out string buf);

            //The following line removes the payload from the Global veriable  Credential
            _credentialCache.Remove("credentialData");

            return new JsonResult(buf);
        }
    }
}
