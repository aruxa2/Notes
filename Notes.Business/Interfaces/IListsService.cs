using Notes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Business.Interfaces
{
    public interface IListsService
    {
        IEnumerable<List> GetListsPreviews();
        List GetList(int id);
        List CreateList(string name);
        List Delete(int id);
    }
}
