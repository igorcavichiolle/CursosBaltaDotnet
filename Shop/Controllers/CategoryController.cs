using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    //Nosso controllador SEMPRE herda de ControllerBase
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<List<Category>>> Get(
            [FromServices] DataContext context
        )
        {
            var categories = await context.Categories.AsNoTracking().ToListAsync();
            return Ok(categories);
        }

        //Restringindo apenas int como parametro 
        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Category>> GetById(
            int id,
            [FromServices] DataContext context
            )
        {
            var categories = await context.Categories.AsNoTracking()
                                                     .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(categories);
        }

        //FromBody explicita para o método que os dados estao no corpo da requisição
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<List<Category>>> Post(
            [FromBody] Category model,
            [FromServices] DataContext context
            )
        {
            //Validando o nosso modelo e retornando as mensagens do DataAnnotations 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //Adicionando a nossa categoria no datacontext(Em memoria)
                context.Categories.Add(model);
                //Persiste as informações no banco de dados virtual(Commita)
                await context.SaveChangesAsync();

                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel criar a categoria" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<List<Category>>> Put(
            int id,
            [FromBody] Category model,
            [FromServices] DataContext context)
        {
            //Verifica se o Id informado é o mesmo do modelo
            if (id != model.Id)
                return NotFound(new { message = "Categoria não encontrada" });

            //Verifica os campos do model
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //Setando o nosso modelo modificado no contexto, possibilitando persistir as alterações
                context.Entry<Category>(model).State = EntityState.Modified;
                //Persiste as informações no banco de dados virtual(Commita)
                await context.SaveChangesAsync();

                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro ja foi atualizado" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel atualizar a categoria" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<List<Category>>> Delete(
            int id,
            [FromServices] DataContext context)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound(new { message = "Categoria não encontrada" });

            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return Ok(new { message = "Categoria removida com sucesso" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}