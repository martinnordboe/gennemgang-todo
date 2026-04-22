using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public interface ITodoRepository
    {
        ObservableCollection<TodoItem> GetAll();
        void SaveAll(ObservableCollection<TodoItem> todoItems);
    }
}
