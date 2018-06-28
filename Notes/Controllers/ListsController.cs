using Microsoft.AspNetCore.Mvc;
using Notes.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Business.Interfaces;

namespace Notes.Controllers
{
    [Produces("application/json")]
    [Route("api/Lists")]
    public class ListsController : Controller
    {
        private readonly IListsService _listsService;

        public ListsController(IListsService listsService)
        {
            _listsService = listsService;
        }

        // GET: api/Lists
        [HttpGet]
        public IEnumerable<List> GetLists()
        {
            return _listsService.GetListsPreviews();
        }

        // GET: api/Lists/5
        [HttpGet("{id}")]
        public IActionResult GetList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var list = _listsService.GetList(id);

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }
 
        // POST: api/Lists
        [HttpPost]
        public IActionResult PostList([FromBody] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var list = _listsService.CreateList(name);

            return Ok(list);
        }

        // DELETE: api/Lists/5
        [HttpDelete("{id}")]
        public IActionResult DeleteList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var list = _listsService.Delete(id);
            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }
    }
}
