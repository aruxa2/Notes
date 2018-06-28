using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Business.Models
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
        public int Order { get; set; }
    }
}
