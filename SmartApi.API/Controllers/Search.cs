using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartApi.Core;
using SmartApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Search : ControllerBase
    {
        private IService _service;

        public Search(IService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult Test(string searchQuery)
        {
            try
            {
                var apartmentSearch = _service.SearchApartment(searchQuery);

                var managementSearch = _service.SearchManagement(searchQuery);

                var result = new SearchResult {Properties=apartmentSearch,Managements=managementSearch };

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
