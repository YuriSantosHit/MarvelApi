using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MarvelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(MarvelApiServices), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]

        public ActionResult<string> Get()
        {
            MarvelApiServices apiMarvel = new MarvelApiServices();
            string resultado = apiMarvel.BuscaDadosApiMarvel();
            return resultado;
        }
    }
}
