using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAlfaAPI.Controllers
{
    //[ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    //[ApiController]
    public class ValuesController : MainController  //  ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> ObterTodos()
        {
            var valores = new string[] { "value1", "value2" };

            if (valores.Length < 5000)
                return BadRequest(); // Podemos retornar action result aqui...

            return valores; // Retornar tipos diretos em IEnumerable
        }

        [HttpGet]
        public ActionResult ObterResultado()
        {
            var valores = new string[] { "value1", "value2" };

            if (valores.Length < 5000)
            {
                //return BadRequest(); // Podemos retornar action result aqui...
                CustomResponse();
            }

            //return Ok(valores); // Usar action result com tipos  sem ENumerable

            return CustomResponse(valores);
        }

        [HttpGet("obter-valores")]
        public IEnumerable<string> ObterValores()
        {
            var valores = new string[] { "value1", "value2" };

            if (valores.Length < 5000)
            {
                // return BadRequest(); Não se pode usar esse retorno quando usamos tipos sem Action Result
                return null;
            }

            return valores;
        }

        // GET api/Values/obter-por-id/5
        [HttpGet("obter-por-id/{id:int}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)  // Vem do body do request
        {
        }

        [HttpPost]
        //[ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ApiConventionMethod(typeof(DefaultApiConventions),nameof(DefaultApiConventions.Post))]
        public ActionResult Post(Product product) 
        {
            if (product.Id == 0) return BadRequest();

            return Ok(product); // => Não pode, pois gera código 200 e não 201
            //return CreatedAtAction("Post", product);  => Retorno 201
            //return CreatedAtAction(nameof(Post), product);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put([FromRoute] int id, [FromForm] Product product) //[FromRoute] fica implicito já o [FromForm] virá de um formulário
        {
        }

        // DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpDelete("{id}")]
        public void Delete([FromQuery]int id)
        {
        }
    }

    [ApiController]
    public abstract class MainController : ControllerBase
    { 
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            { 
                return Ok( new
                {
                    sucess = true,
                    data = result
                }); 
            }

            return BadRequest( new
            {
                sucess = false,
                errors = ObterErros()
            });
        }

        public bool OperacaoValida()
        {
            // Minhas validações fake
            return true;
        }

        protected string ObterErros()
        {
            return ""; 
        }

    
    }


    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


    }
}
