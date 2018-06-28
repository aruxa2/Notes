using System;
using System.Collections.Generic;

namespace Notes.Data.Models
{
    public partial class ListItemList
    {
        public int ListId { get; set; }
        public int ListItemId { get; set; }

        public Lists List { get; set; }
        public ListItems ListItem { get; set; }

        public bool Checked { get; set; }
        public int Order { get; set; }

    }
}
