using System;
using System.Collections.Generic;

namespace Notes.Data.Models.2.0
{
    public partial class List
    {
        public List()
        {
            ListItems = new HashSet<ListItemList>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ListItemList> ListItemList { get; set; }
    }
}
