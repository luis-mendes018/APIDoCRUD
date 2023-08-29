using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using ClienteMVC.Context;
using ClienteMVC.Models;
using System.Threading.Tasks;
using System;

namespace ClienteMVC.Controllers
{
    [RoutePrefix("api/clientes")]
    public class ClientesController : ApiController
    {
        private readonly ClienteDbContext _dbContext = new ClienteDbContext();

        [HttpGet]
        [Route("")]
        public IEnumerable<Cliente> GetClientes()
        {
            return _dbContext.Clientes.ToList();
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetCliente(int id)
        {
            var cliente = _dbContext.Clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpGet]
        [Route("Search/{nome}")]
        public IHttpActionResult GetClientePorNome(string nome)
        {
            if (nome == null)
                return BadRequest("Nome Inválido");

            IList<Cliente> clientes = null;
            using (var cli = new ClienteDbContext())
            {
                clientes = cli.Clientes
                    .Where(c => c.Nome.ToLower().Contains(nome.ToLower()))
                    .ToList();
            }
            if (clientes.Count == 0)
            {
                return NotFound();
            }
            return Ok(clientes);
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cliente.Id }, cliente);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(cliente).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Clientes.Any(c => c.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteCliente(int id)
        {
            var cliente = _dbContext.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _dbContext.Clientes.Remove(cliente);
            _dbContext.SaveChanges();

            return Ok(cliente);
        }

        [HttpGet]
        [Route("CheckCPFExists")]
        public async Task<bool> CheckCPFExists(string cpf)
        {
            var existingCliente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
            return existingCliente != null;
        }

    }
}
