using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TestBackEndApi.Domain.Queries.Cep.Get;

namespace TestBackEndApi.Api.Controllers
{    
    [Route("api/cep")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CepController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Busca as informações formato JSON
        /// </summary>
        /// <remarks>
        /// Exemplo requisicao:
        ///
        ///     GetResponseJson 
        ///     {
        ///   		"cep": "",
        ///   		"logradouro": "",
        ///   		"complemento": "",
        ///   		"bairro": "",
        ///   		"localidade": "",
        ///   		"mensagens": [
        ///   		  {
        ///   		    "mensagem": ""
        ///   		  }
        ///   		]      
        ///     }
        ///
        /// </remarks>
        /// <param name="query"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="200">Retorna quando consegue obter o valor da api sem erros</response>
        /// <response code="400">Se o retorno for null</response>
        /// <response code="500">Se o paramentro da connsultar não for preenchido</response>      
        [HttpGet]
        [Route("/json")]
        public async Task<IActionResult> GetResponseJson([FromQuery] GetCepQuery query)
        {
            var response = await _mediator.Send(query);
            if (response == null) return NotFound();
            if (string.IsNullOrEmpty(response.Cep)) return BadRequest(response);
            return Ok(response);
        }

        /// <summary>
        /// Retorna as informações no formato XML
        /// </summary>
        /// <remarks>
        /// Exemplo requisicao:
        ///
        ///     GetResponseXml
        ///     {
        ///        <GetCepQueryResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
        ///             <Cep>25720-200</Cep>
        ///             <Logradouro>Rua Visconde de Taunay</Logradouro>
        ///             <Complemento />
        ///             <Bairro>Corrêas</Bairro>
        ///             <Localidade>Petrópolis - RJ</Localidade>
        ///             <Mensagens>
        ///                 <MensagemQueryResponse>
        ///                     <Mensagem>Sucesso</Mensagem>
        ///                 </MensagemQueryResponse>
        ///             </Mensagens>
        ///         </GetCepQueryResponse>
        ///     }
        ///
        /// </remarks>
        /// <param name="query"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="200">Retorna quando consegue obter o valor da api sem erros</response>
        /// <response code="404">Se o retorno for null</response>
        /// <response code="400">Se o paramentro da connsultar não for preenchido</response>
        [Produces("application/xml")]
        [HttpGet]
        [Route("/xml")]
        public async Task<IActionResult> GetResponseXml([FromQuery] GetCepQuery query)
        {
            var response = await _mediator.Send(query);
            if (response == null) return NotFound();
            if (string.IsNullOrEmpty(response.Cep)) return BadRequest(response);
            return Ok(response);
        }

    }
}
