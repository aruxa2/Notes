using Notes.Business.Interfaces;
using Notes.Business.Models;
using Notes.Data;
using Notes.Data.Interfaces;
using Notes.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notes.Business.Services
{
    public class ListsService : IListsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //TODO preview should be parameterized
        public IEnumerable<List> GetListsPreviews()
        {
            return _unitOfWork.ListsRepository
                .GetListsPreviews()
                .Select(Mapper.Map);
        }

        public List CreateList(string name)
        {
            var list = new Data.Models.List
            {
                Name = name
            };

            _unitOfWork.ListsRepository.Add(list);
            _unitOfWork.Save();
            return list.Map();
        }

        public List GetList(int id)
        {
            var dataList = _unitOfWork.ListsRepository.Get(id);

            var list = dataList.Map();

            return list;
        }

        public List Delete(int id)
        {
            var dataList = _unitOfWork.ListsRepository.Get(id);
            var list = dataList.Map();
            if (dataList == null)
                return null;
            dataList.ListItems.Clear();
            _unitOfWork.ListsRepository.Remove(dataList);
            _unitOfWork.Save();
            return list;
        }
    }



}