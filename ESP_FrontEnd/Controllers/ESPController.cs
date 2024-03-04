using ESP_FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ESP_FrontEnd.Controllers
{
    public class ESPController : Controller
    {
        // REQ: https://developer.sepush.co.za/business/2.0/areas_search?text=athlone
        // Resp: ethekwini3-11a-athloneeast

        // REQ: https://developer.sepush.co.za/business/2.0/area?id=ethekwini3-11a-prospecthall
        // Resp:


        private static HttpClient espClient = new()
        {
            BaseAddress = new Uri("https://developer.sepush.co.za/business/2.0/"),
        };


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string search)
        {
            if (!espClient.DefaultRequestHeaders.Contains("token"))
            {
                espClient.DefaultRequestHeaders.Add("Token", Environment.GetEnvironmentVariable("ESP_Token"));
            }
            HttpResponseMessage response = await espClient.GetAsync("areas_search?text=" + search);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            AreasModel? deserialisedResponse = JsonSerializer.Deserialize<AreasModel>(jsonResponse);
            return View(deserialisedResponse);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (!espClient.DefaultRequestHeaders.Contains("token"))
            {
                espClient.DefaultRequestHeaders.Add("Token", Environment.GetEnvironmentVariable("ESP_Token"));
            }

            HttpResponseMessage response = await espClient.GetAsync("area?id=" + id);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            
            // Note: comment lines above and uncomment line below to save API requests
            // string jsonResponse = "{\r\n    \"events\": [\r\n        {\r\n            \"end\": \"2024-03-05T04:00:00+02:00\",\r\n            \"note\": \"Stage 2\",\r\n            \"start\": \"2024-03-05T02:00:00+02:00\"\r\n        }\r\n    ],\r\n    \"info\": {\r\n        \"name\": \"Prospect Hall (11A)\",\r\n        \"region\": \"eThekwini Municipality\"\r\n    },\r\n    \"schedule\": {\r\n        \"days\": [\r\n            {\r\n                \"date\": \"2024-03-04\",\r\n                \"name\": \"Monday\",\r\n                \"stages\": [\r\n                    [\r\n                        \"14:00-16:00\"\r\n                    ],\r\n                    [\r\n                        \"14:00-16:00\"\r\n                    ],\r\n                    [\r\n                        \"14:00-16:00\"\r\n                    ],\r\n                    [\r\n                        \"14:00-16:00\"\r\n                    ],\r\n                    [\r\n                        \"06:00-08:00\",\r\n                        \"14:00-16:00\"\r\n                    ],\r\n                    [\r\n                        \"06:00-08:00\",\r\n                        \"14:00-16:00\"\r\n                    ],\r\n                    [\r\n                        \"06:00-08:00\",\r\n                        \"14:00-16:00\"\r\n                    ],\r\n                    [\r\n                        \"06:00-08:00\",\r\n                        \"14:00-16:00\",\r\n                        \"22:00-00:00\"\r\n                    ]\r\n                ]\r\n            },\r\n            {\r\n                \"date\": \"2024-03-05\",\r\n                \"name\": \"Tuesday\",\r\n                \"stages\": [\r\n                    [\r\n                        \"02:00-04:00\"\r\n                    ],\r\n                    [\r\n                        \"02:00-04:00\"\r\n                    ],\r\n                    [\r\n                        \"02:00-04:00\",\r\n                        \"10:00-12:00\"\r\n                    ],\r\n                    [\r\n                        \"02:00-04:00\",\r\n                        \"10:00-12:00\"\r\n                    ],\r\n                    [\r\n                        \"02:00-04:00\",\r\n                        \"10:00-12:00\"\r\n                    ],\r\n                    [\r\n                        \"02:00-04:00\",\r\n                        \"10:00-12:00\"\r\n                    ],\r\n                    [\r\n                        \"02:00-04:00\",\r\n                        \"10:00-12:00\"\r\n                    ],\r\n                    [\r\n                        \"02:00-04:00\",\r\n                        \"10:00-12:00\",\r\n                        \"18:00-20:00\"\r\n                    ]\r\n                ]\r\n            },\r\n            {\r\n                \"date\": \"2024-03-06\",\r\n                \"name\": \"Wednesday\",\r\n                \"stages\": [\r\n                    [],\r\n                    [\r\n                        \"06:00-08:00\"\r\n                    ],\r\n                    [\r\n                        \"06:00-08:00\"\r\n                    ],\r\n                    [\r\n                        \"06:00-08:00\"\r\n                    ],\r\n                    [\r\n                        \"06:00-08:00\"\r\n                    ],\r\n                    [\r\n                        \"06:00-08:00\",\r\n                        \"14:00-16:00\"\r\n                    ],\r\n                    [\r\n                        \"06:00-08:00\",\r\n                        \"14:00-16:00\",\r\n                        \"22:00-00:00\"\r\n                    ],\r\n                    [\r\n                        \"06:00-08:00\",\r\n                        \"14:00-16:00\",\r\n                        \"22:00-00:00\"\r\n                    ]\r\n                ]\r\n            },\r\n            {\r\n                \"date\": \"2024-03-07\",\r\n                \"name\": \"Thursday\",\r\n                \"stages\": [\r\n                    [],\r\n                    [],\r\n                    [],\r\n                    [\r\n                        \"20:00-22:00\"\r\n                    ],\r\n                    [\r\n                        \"04:00-06:00\",\r\n                        \"20:00-22:00\"\r\n                    ],\r\n                    [\r\n                        \"04:00-06:00\",\r\n                        \"20:00-22:00\"\r\n                    ],\r\n                    [\r\n                        \"04:00-06:00\",\r\n                        \"20:00-22:00\"\r\n                    ],\r\n                    [\r\n                        \"04:00-06:00\",\r\n                        \"20:00-22:00\"\r\n                    ]\r\n                ]\r\n            },\r\n            {\r\n                \"date\": \"2024-03-08\",\r\n                \"name\": \"Friday\",\r\n                \"stages\": [\r\n                    [\r\n                        \"16:00-18:00\"\r\n                    ],\r\n                    [\r\n                        \"16:00-18:00\"\r\n                    ],\r\n                    [\r\n                        \"16:00-18:00\"\r\n                    ],\r\n                    [\r\n                        \"16:00-18:00\"\r\n                    ],\r\n                    [\r\n                        \"08:00-10:00\",\r\n                        \"16:00-18:00\"\r\n                    ],\r\n                    [\r\n                        \"00:00-02:00\",\r\n                        \"08:00-10:00\",\r\n                        \"16:00-18:00\"\r\n                    ],\r\n                    [\r\n                        \"00:00-02:00\",\r\n                        \"08:00-10:00\",\r\n                        \"16:00-18:00\"\r\n                    ],\r\n                    [\r\n                        \"00:00-02:00\",\r\n                        \"08:00-10:00\",\r\n                        \"16:00-18:00\"\r\n                    ]\r\n                ]\r\n            },\r\n            {\r\n                \"date\": \"2024-03-09\",\r\n                \"name\": \"Saturday\",\r\n                \"stages\": [\r\n                    [],\r\n                    [\r\n                        \"04:00-06:00\"\r\n                    ],\r\n                    [\r\n                        \"04:00-06:00\"\r\n                    ],\r\n                    [\r\n                        \"04:00-06:00\",\r\n                        \"12:00-14:00\"\r\n                    ],\r\n                    [\r\n                        \"04:00-06:00\",\r\n                        \"12:00-14:00\"\r\n                    ],\r\n                    [\r\n                        \"04:00-06:00\",\r\n                        \"12:00-14:00\"\r\n                    ],\r\n                    [\r\n                        \"04:00-06:00\",\r\n                        \"12:00-14:00\"\r\n                    ],\r\n                    [\r\n                        \"04:00-06:00\",\r\n                        \"12:00-14:00\"\r\n                    ]\r\n                ]\r\n            },\r\n            {\r\n                \"date\": \"2024-03-10\",\r\n                \"name\": \"Sunday\",\r\n                \"stages\": [\r\n                    [],\r\n                    [],\r\n                    [\r\n                        \"00:00-02:00\",\r\n                        \"18:00-20:00\"\r\n                    ],\r\n                    [\r\n                        \"00:00-02:00\",\r\n                        \"18:00-20:00\"\r\n                    ],\r\n                    [\r\n                        \"00:00-02:00\",\r\n                        \"18:00-20:00\"\r\n                    ],\r\n                    [\r\n                        \"00:00-02:00\",\r\n                        \"18:00-20:00\"\r\n                    ],\r\n                    [\r\n                        \"00:00-02:00\",\r\n                        \"18:00-20:00\"\r\n                    ],\r\n                    [\r\n                        \"00:00-02:00\",\r\n                        \"10:00-12:00\",\r\n                        \"18:00-20:00\"\r\n                    ]\r\n                ]\r\n            }\r\n        ],\r\n        \"source\": \"https://www.durban.gov.za/storage/Load%20Shedding%20Schedule%202022.pdf\"\r\n    }\r\n}";
            
            EspResponse? deserialisedResponse = JsonSerializer.Deserialize<EspResponse>(jsonResponse);
            return View(deserialisedResponse);
        }

    }
}
