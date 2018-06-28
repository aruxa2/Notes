using System;
using System.Collections.Generic;

namespace Notes.Data.Models
{
    public partial class Item
    {
        public Item()
        {
            ListItems = new HashSet<ListItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ListItem> ListItems { get; set; }
    }
}
