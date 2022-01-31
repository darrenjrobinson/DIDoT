using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;

//the ing page Index2Model2 is prefered as it resets the value after execution 


namespace  AspNetCoreVerifiableCredentials.Pages
{
    public class Index2Model : PageModel
    {
        protected IMemoryCache _credentialCache;

        public Index2Model(IMemoryCache memoryCache)
        {
            _credentialCache = memoryCache;
        }

        public string Message { get; private set; } = "PageModel in C#";

        public JsonResult OnGet()
        {
            _credentialCache.TryGetValue("credentialData", out string buf);
            return new JsonResult(buf);
//            Message = buf;
        }
    }
}