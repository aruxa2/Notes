using Microsoft.EntityFrameworkCore;
using Notes.Data.Interfaces;
using Notes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notes.Data.Repositories
{
    public class ListsRepository : Repository<Data.Models.List>, IListsRepository
    {
        private readonly NotesDbContext _notesContext;

        public ListsRepository(NotesDbContext notesContext)
            :base(notesContext)
        {
            _notesContext = notesContext;
        }

        public IEnumerable<List> GetListsPreviews()
        {
            var ret = _notesContext.Lists
                        .Include(f => f.ListItems)
                        .ToList();
            return ret;
        }

        public override List Get(int id)
        {
            return _notesContext.Lists
                  .Where(x => x.Id == id)
                  .Include(f => f.ListItems)
                  .FirstOrDefault();
        }
    }
}
