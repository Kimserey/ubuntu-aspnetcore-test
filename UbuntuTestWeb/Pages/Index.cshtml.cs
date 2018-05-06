using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace UbuntuTestWeb.Pages
{
    public class IndexModel : PageModel
    {
        public async Task OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                var data = await client.GetStringAsync("http://localhost:5001/values");
                Values = JsonConvert.DeserializeObject<IEnumerable<string>>(data);
            }
        }

        public IEnumerable<string> Values { get; set; }
    }
}