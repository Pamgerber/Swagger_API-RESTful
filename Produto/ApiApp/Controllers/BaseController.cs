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
        public List<T> Get()
        {
            return repo.Read();
        }

        [HttpGet("{id}")]
        public T Get(int id)
        {
            return repo.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] T model)
        {
            repo.Create(model);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] T model)
        {
            repo.Update(model);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Delete(id);
        }
            
    }
}
