using Notes.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Data.Interfaces
{
    public interface IListItemsRepository : IRepository<ListItem>
    {
        IEnumerable<ListItem> GetListItemsStartingWith(int listId, string startsWith);
    }
}
