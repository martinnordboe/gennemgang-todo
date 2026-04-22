using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public class JsonTodoRepository : ITodoRepository
    {
        string _basePath = string.Empty;
        string _fileName = string.Empty;
        string _filePath = string.Empty;

        public JsonTodoRepository()
        {
            _basePath = Environment.CurrentDirectory;
            _fileName = "todoitems.json";
            _filePath = Path.Combine(_basePath, "Data", _fileName);
        }

        public ObservableCollection<TodoItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveAll(ObservableCollection<TodoItem> todoItems)
        {
            throw new NotImplementedException();
        }
    }
}
