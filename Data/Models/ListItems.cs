using System;
using System.Collections.Generic;

namespace Notes.Data.Models
{
    public partial class ListItems
    {
        public ListItems()
        {
            ListItemList = new HashSet<ListItemList>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
       
        public ICollection<ListItemList> ListItemList { get; set; }
    }
}
