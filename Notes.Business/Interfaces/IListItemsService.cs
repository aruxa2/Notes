using Notes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Business.Interfaces
{
    public interface IListItemsService
    {
        ListItem AddItemToList(int listId, string listItemName);
        IEnumerable<ListItem> GetListItemsSuggestions(int listId, string startsWith);
        ListItem RemoveItemFromList(int listId, string listItemName);

    }
}
