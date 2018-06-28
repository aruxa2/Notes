using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IListsRepository ListsRepository { get; }

        IListItemsRepository ListItemsRepository { get; }

        void Save();
    }
}
