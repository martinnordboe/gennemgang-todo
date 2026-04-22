using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TodoApp.Models;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for EditToDoWindow.xaml
    /// </summary>
    public partial class EditToDoWindow : Window
    {
        TodoItem _todoItem;

        public EditToDoWindow(TodoItem todoItem)
        {
            InitializeComponent();
            _todoItem = todoItem;

            TextBoxTitle.Text = _todoItem.Title;
            DeadlineDatePicker.SelectedDate = DateTime.Parse(todoItem.Date.ToString());
        }

        private void EditToDoItemButton_Click(object sender, RoutedEventArgs e)
        {
            _todoItem.Title = TextBoxTitle.Text;

            DateTime? date = DeadlineDatePicker.SelectedDate;
            if (date != null)
            {
                _todoItem.Date = DateOnly.FromDateTime((DateTime)date);

                TextBoxTitle.Text = string.Empty;
                DeadlineDatePicker.SelectedDate = null;
                DeadlineDatePicker.Text = string.Empty;
                this.Close();
            }
        }
    }
}
