using Notes.Data.Models;
using System.Collections.Generic;

namespace Notes.Data.Interfaces
{
    public interface IListsRepository : IRepository<List>
    {
        IEnumerable<List> GetListsPreviews();
        //Lists GetListWithDetails(int id);
    }
}
