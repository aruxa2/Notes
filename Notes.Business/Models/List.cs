using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Business.Models
{
    public class List
    {
        public List()
        {
            ListItems = new List<ListItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ListItem> ListItems { get; set; }
    }
}
