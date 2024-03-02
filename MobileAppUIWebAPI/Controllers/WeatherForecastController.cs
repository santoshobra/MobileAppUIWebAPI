using Microsoft.AspNetCore.Mvc;

namespace MobileAppUIWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UIController : ControllerBase
    {
        private readonly Dictionary<string, string> _configurations = new Dictionary<string, string>
        {
            { "config1", @"
                {
                  ""components"": [
                    {
                      ""type"": ""button"",
                      ""text"": ""Click me"",
                      ""color"": ""blue"",
                      ""size"": ""medium"",
                      ""action"": ""submit""
                    },
                    {
                      ""type"": ""textfield"",
                      ""placeholder"": ""Enter your name"",
                      ""required"": true
                    }
                  ]
                }" },
            { "config2", @"
                {
                  ""components"": [
                    {
                      ""type"": ""button"",
                      ""text"": ""Submit"",
                      ""color"": ""green"",
                      ""size"": ""small"",
                      ""action"": ""submit""
                    },
                    {
                      ""type"": ""textfield"",
                      ""placeholder"": ""Enter your email"",
                      ""required"": true
                    }
                  ]
                }" }
        };

        [HttpGet("configs")]
        public IActionResult GetConfigs()
        {
            return Ok(_configurations.Keys);
        }
        [HttpGet("config/{configName}")]
        public IActionResult GetConfig(string configName)
        {
            if (_configurations.TryGetValue(configName, out var configJson))
            {
                return Ok(configJson);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
