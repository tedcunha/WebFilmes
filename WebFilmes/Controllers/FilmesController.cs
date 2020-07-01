using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebFilmes.Business;
using WebFilmes.Data.VO;
using WebFilmes.Model;

namespace WebFilmes.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly ILogger<FilmesController> _logger;
        private readonly IFilmesBusiness _filmesBusiness;

        public FilmesController(ILogger<FilmesController> logger,
                                IFilmesBusiness filmesBusiness)
        {
            _logger = logger;
            _filmesBusiness = filmesBusiness;
        }

        [HttpGet("PesquisarFilmes")]
        public IActionResult PesquisarFilmes()
        {
            var retorno = _filmesBusiness.PesquisarFilmes();
            if (retorno == null)
            {
                return NotFound();
            }
            return Ok(retorno);
        }

        [HttpGet("PesquisarFilmesPorID/{Id}")]
        public IActionResult PesquisarFilmesPorID(long Id)
        {
            try
            {
                var retorno = _filmesBusiness.PesquisarFilmesPorID(Id);
                if (retorno == null)
                {
                    return NotFound();
                }
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("CadastrarFilmes")]
        public IActionResult CadastrarFilmes([FromBody] FilmesVO filmes)
        {
            try
            {
                if (filmes == null)
                {
                    return BadRequest();
                }
                return Ok(_filmesBusiness.CadastrarFilmes(filmes));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut("AlterarFilme")]
        public IActionResult AlterarFilme([FromBody] FilmesVO filmes)
        {
            try
            {
                if (filmes == null)
                {
                    return BadRequest();
                }
                return Ok(_filmesBusiness.AlteraFilme(filmes));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpDelete("DeletarFilme/{Id}")]
        public IActionResult DeletarFilme(long Id)
        {
            try
            {
                return Ok(_filmesBusiness.DeletarFilme(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
