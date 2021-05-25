using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {
        }

        // GET all action
        [HttpGet]public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        // GET by Id action

         [HttpGet("{id}")]
         public ActionResult<Pizza> Get(int id)
         {
             var pizza = PizzaService.Get(id);
             if(pizza == null)
                return NotFound();
             return pizza;
        }

        // POST action

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {            
           PizzaService.Add(pizza);
           return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
           if (id != pizza.Id)
              return BadRequest();
           var existingPizza = PizzaService.Get(id);
           if(existingPizza is null)
              return NotFound();

            PizzaService.Update(pizza);           
              return NoContent();
        }
        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             var pizza = PizzaService.Get(id);
             if (pizza is null)
                return NotFound();
            PizzaService.Delete(id);
                return NoContent();
        }



        //fuente de informacion https://docs.microsoft.com/es-es/learn/modules/build-web-api-aspnet-core/6-exercise-add-controller
        //fuente de informacion https://docs.microsoft.com/es-es/learn/modules/build-web-api-aspnet-core/7-crud

        /*
        Verbo de acción HTTP	Operación CRUD	Atributo de ASP.NET Core
                GET	                Lectura	          [HttpGet]
                POST	            Creación	      [HttpPost]
                PUT	                Actualización	  [HttpPut]
                DELETE	            Eliminación	      [HttpDelete]
        */
    }
}