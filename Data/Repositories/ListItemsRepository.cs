using Notes.Data.Interfaces;
using Notes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notes.Data.Repositories
{
    public class ListItemsRepository : Repository<Data.Models.ListItem>, IListItemsRepository
    {
        private readonly NotesDbContext _notesContext;
                            
        public ListItemsRepository(NotesDbContext notesContext)
            :base(notesContext)
        {
            _notesContext = notesContext;
        }

        public IEnumerable<ListItem> GetListItemsStartingWith(int listId, string startsWith)
        {
            var list = _notesContext.Lists.FirstOrDefault(l => l.Id == listId);
            var listItems = list.ListItems.Where(i => i.Item.Name.StartsWith(startsWith));

            return listItems.ToList();
        }
    }
}
