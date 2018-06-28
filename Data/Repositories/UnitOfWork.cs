using Notes.Data.Interfaces;
using Notes.Data.Models;
using System;
using System.Collections.Generic;

namespace Notes.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NotesDbContext _notesContext;
        private readonly IListsRepository _listsRepository;
        private readonly IListItemsRepository _listItemsRepository;

        public UnitOfWork(NotesDbContext notesContext)
        {
            _notesContext = notesContext;
            _listsRepository = new ListsRepository(_notesContext);
            _listItemsRepository = new ListItemsRepository(_notesContext);
        }

        public IListsRepository ListsRepository => _listsRepository;

        public IListItemsRepository ListItemsRepository => _listItemsRepository;

        public void Save() => _notesContext.SaveChanges();

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _notesContext.Dispose();
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
