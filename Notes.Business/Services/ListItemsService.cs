using Notes.Business.Interfaces;
using Notes.Business.Models;
using Notes.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notes.Business.Services
{
    public class ListItemsService : IListItemsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListItemsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ListItem AddItemToList(int listId, string listItemName)
        {
            var list = _unitOfWork.ListsRepository.Get(listId);

            if (list == null)
                return null;

            var listItem = list.ListItems.FirstOrDefault(li => li.Item.Name.ToLower() == listItemName && li.Checked);

            if (listItem != null)
            {
                listItem.Checked = false;
                return listItem.Map();
            }

            listItem = list.ListItems.FirstOrDefault(li => li.Item.Name.ToLower() == listItemName && li.Checked == false);

            //someone added it in the meanwhile 
            if (listItem != null)
            {
                return listItem.Map();
            }

            var item = new Data.Models.Item { Name = listItemName };

            var maxOrderNo = list.ListItems.Where(li => li.Checked == false).Max(li => li.Order);

            listItem = new Data.Models.ListItem { List = list, Item = item, Order = maxOrderNo + 1, Checked = false };
            list.ListItems.Add(listItem);

            _unitOfWork.Save();

            return listItem.Map();
        }

        public ListItem RemoveItemFromList(int listId, string listItemName)
        {
            //var list = _unitOfWork.ListsRepository.Get(listId);
            //if (list == null)
            //{
            //    return null;
            //}

            //var item = _unitOfWork.ItemsRepository.Where(i => i.Name == listItemName).FirstOrDefault();
            //if (item == null)
            //{
            //    return null;
            //}

            //var jonctureItem = list.ListItemList.Where(il => il.List == list && il.ListItem == item).SingleOrDefault();
            //if (jonctureItem == null)
            //    return null;

            //list.ListItemList.Remove(jonctureItem);
            //_unitOfWork.Save();

            //return item.Map();
            throw new Exception();
        }

        public IEnumerable<ListItem> GetListItemsSuggestions(int listId, string startsWith)
        {
            return _unitOfWork.ListItemsRepository
                .GetListItemsStartingWith(listId, startsWith)
                .Select(Mapper.Map);
        }

    }
}
