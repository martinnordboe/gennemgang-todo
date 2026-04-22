using System.Collections.ObjectModel;
using System.Windows;
using TodoApp.Models;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for AddNewTodoWindow.xaml
    /// </summary>
    public partial class AddNewTodoWindow : Window
    {
        // prívate field
        ObservableCollection<TodoItem> _todoItems;

        public AddNewTodoWindow(ObservableCollection<TodoItem> todoItems)
        {
            InitializeComponent();
            _todoItems = todoItems;
        }

        private void AddToDoItemButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime? date = DeadlineDatePicker.SelectedDate;
            if(date != null)
            {
                TodoItem todo = new TodoItem(TextBoxTitle.Text, DateOnly.FromDateTime((DateTime)date));

                _todoItems.Add(todo);

                TextBoxTitle.Text = string.Empty;
                DeadlineDatePicker.SelectedDate = null;
                DeadlineDatePicker.Text = string.Empty;
                this.Close();
            }

        }
    }
}
