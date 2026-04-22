using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using TodoApp.Models;
using TodoApp.Repositories;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<TodoItem> _todoItems; 

        ITodoRepository _todoRepository;

        public MainWindow()
        {
            InitializeComponent();
            _todoItems = new ObservableCollection<TodoItem>();

            TodoItem todo = new TodoItem("Vask tøj");
            TodoItem todo1 = new TodoItem("Kør til undervisning", true, DateOnly.FromDateTime(DateTime.Now));
            TodoItem todo2 = new TodoItem();
            todo2.Title = "Forbered gennemgang";
            todo2.IsDone = true;

            Debug.WriteLine(todo.Date.ToString());

            _todoItems.Add(todo);
            _todoItems.Add(todo1);
            _todoItems.Add(todo2);




            _todoRepository = new TxtTodoRepository();
            _todoRepository.SaveAll(_todoItems);

            _todoItems = _todoRepository.GetAll();

            for(int i = 0; i < _todoItems.Count; i++)
            {
                Debug.WriteLine(_todoItems[i].Title);
            }

            TodoList.ItemsSource = _todoItems;
        }

        private void CheckBoxDone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            TodoItem todoItemSendtMedFraCheckBox = (TodoItem)checkBox.DataContext;

            todoItemSendtMedFraCheckBox.IsDone = true;
        }

        private void CheckBoxDone_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            TodoItem todoItemSendtMedFraCheckBox = (TodoItem)checkBox.DataContext;

            todoItemSendtMedFraCheckBox.IsDone = false;
        }

        private void AddNewTodoButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewTodoWindow window = new AddNewTodoWindow(_todoItems);
            bool? result = window.ShowDialog();
            _todoRepository.SaveAll(_todoItems);
        }

        private void EditToDoButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TodoItem todo = (TodoItem)button.DataContext;
            Debug.WriteLine($"{todo.Title}");

            EditToDoWindow window = new EditToDoWindow(todo);
            window.ShowDialog();

            _todoRepository.SaveAll(_todoItems);
        }

        private void DeleteToDoButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TodoItem todo = (TodoItem)button.DataContext;

            _todoItems.Remove(todo);
            _todoRepository.SaveAll(_todoItems);
        }
    }
}