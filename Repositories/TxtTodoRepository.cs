using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.IO;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public class TxtTodoRepository : ITodoRepository
    {
        string _basePath = string.Empty;
        string _fileName = string.Empty;
        string _filePath = string.Empty;

        public TxtTodoRepository()
        {
            _basePath = Environment.CurrentDirectory;
            _fileName = "todoitems.txt";
            _filePath = Path.Combine(_basePath, "Data", _fileName);
        }

        public ObservableCollection<TodoItem> GetAll()
        {
            ObservableCollection<TodoItem> todoItems = new ObservableCollection<TodoItem>();

            string[] lines = File.ReadAllLines(_filePath);
            for(int i = 0; i < lines.Length; i++)
            {
                string[] elements = lines[i].Split(',');
                
                TodoItem todoItem = new TodoItem();
                todoItem.Title = elements[0];
                todoItem.IsDone = bool.Parse(elements[1]);
                todoItem.Date = DateOnly.Parse(elements[2]);

                todoItems.Add(todoItem);
            }
            return todoItems;
        }

        public void SaveAll(ObservableCollection<TodoItem> todoItems)
        {
            List<string> listofStrings = new List<string>();
            for(int i = 0; i < todoItems.Count; i++)
            {
                string title = todoItems[i].Title;
                string isDone = todoItems[i].IsDone.ToString();
                string date = todoItems[i].Date.ToString();

                string full = $"{title},{isDone},{date}";
                listofStrings.Add(full);
            }

            File.WriteAllLines(_filePath, listofStrings);
        }

    }
}
