using Microsoft.AspNetCore.Mvc;
using whs.api.manager.extensions;
using whs.api.manager.viewmodels;
using whs.api.manager.viewmodels.configuration;

namespace whs.api.manager.controllers;

[Route("api/[controller]")]
[ApiController]
public class ConfigurationController(
    IConfiguration configuration,
    ILogger<ConfigurationController> logger) : Controller
{
    private readonly IConfiguration _configuration = configuration;
    private readonly ILogger<ConfigurationController> _logger = logger;

    private const string LOG_PREFIX = nameof(ConfigurationController);

    [HttpGet()]
    [ProducesResponseType((typeof(ViewModelPortalConfiguration)), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPortalConfiguration()
    {
        _logger.LogInformation("{logPrefix}: Retrieving portal configuration", LOG_PREFIX);

        IConfigurationSection portalConfigurationSection = _configuration.GetRequiredSection("PortalConfiguration");

        ViewModelPortalConfiguration portalConfiguration = new ViewModelPortalConfiguration()
        {
            ApiOriginUrl = portalConfigurationSection.GetRequiredValue<string>("ApiOriginUrl"),
            DropDownPageSize = portalConfigurationSection.GetRequiredValue<int>("DropDownPageSize"),
            GridPageSize = portalConfigurationSection.GetRequiredValue<int>("GridPageSize")
        };

        return Ok(portalConfiguration);
    }
}
