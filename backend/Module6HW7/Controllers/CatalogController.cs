using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Module6HW7.Exceptions;
using Module6HW7.Interfaces;
using Module6HW7.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW7.Controllers
{
    [Route("api")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet("catalog-items")]
        public async Task<IActionResult> GetCatalogItems()
        {
            List<Catalog> catalogItems = null;

            try
            {
                catalogItems = await _catalogService.GetCatalogItems();
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return Ok(catalogItems);
        }
    }
}
