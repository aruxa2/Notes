using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Business.Interfaces;
using Notes.Business.Models;

namespace Notes.Controllers
{
    [Produces("application/json")]
    [Route("api/ListItems")]
    public class ListItemsController : Controller
    {
        private readonly IListItemsService _listItemsService;

        public ListItemsController(IListItemsService listItemsService)
        {
            _listItemsService = listItemsService;
        }

        [HttpGet("{startsWith}")]
        public IEnumerable<ListItem> Get(string startsWith)
        {
            throw new Exception();
            //return _listItemsService.GetListItemsSuggestions(startsWith);
        }

        public IActionResult PostListItem([FromBody] ListItemParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var listItem = _listItemsService.AddItemToList(parameters.Id, parameters.ListItemName);

            if (listItem == null)
                return NotFound();

           return CreatedAtAction("PostListItem", new { id = listItem.Id }, listItem);
        }

        [HttpDelete("{listId}")]
        public IActionResult RemoveListItem(int listId, [FromQuery] string listItemName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var listItem = _listItemsService.RemoveItemFromList(listId, listItemName);

            if (listItem == null)
                return NotFound();

            return Ok(listItem);

        }
    }
}
