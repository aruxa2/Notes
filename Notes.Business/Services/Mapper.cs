using Notes.Business.Models;
using System.Linq;

namespace Notes.Business.Services
{
    public static class Mapper
    {
        public static List Map(this Data.Models.List item)
        {
            if (item == null)
                return null;

            var list = new List
            {
                Id = item.Id,
                Name = item.Name
            };

            foreach (var listItem in item.ListItems)
            {
                list.ListItems.Add(listItem.Map());
            }

            return list;
        }

        public static ListItem Map(this Data.Models.ListItem listItem)
        {
            if (listItem == null) return null;

            return new ListItem
            {
                Id = listItem.Id,
                Name = listItem.Item.Name,
                Order = listItem.Order,
                Checked = listItem.Checked
            };
        }
    }



}