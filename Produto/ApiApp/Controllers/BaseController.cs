using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, R> : ControllerBase where T:Base where R:BaseRepository<T>
    {
        R repo = Activator.CreateInstance<R>();

        [HttpGet]
        public ActionResult<List<T>> Get()
        {
            try
            {
                return repo.Read();
            }
            catch (MissingFieldException ex)
            {
                return StatusCode(404);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<T> Get(int id)
        {
            try
            {
                return repo.Read(id);
            }
            catch (MissingFieldException ex)
            {
                return StatusCode(404);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] T model)
        {
            try
            {
                repo.Create(model);
                return StatusCode(201);
            }catch (Exception ex)
            {
                return StatusCode(500);
            } 
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] T model)
        {
            try
            {
                repo.Update(model);
                return StatusCode(204);

            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            try
            {
                repo.Delete(id);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(500);
            }
        }
            
    }
}
