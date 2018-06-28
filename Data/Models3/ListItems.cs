using System;
using System.Collections.Generic;

namespace Notes.Data.Models
{
    public partial class ListItem
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public int ItemId { get; set; }
        public int Order { get; set; }
        public bool Checked { get; set; }

        public Item Item { get; set; }
        public List List { get; set; }
    }
}
