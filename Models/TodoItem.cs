using System.ComponentModel;

namespace TodoApp.Models
{
    public class TodoItem : INotifyPropertyChanged
    {   
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // fields - private og har derfor _ og camelCase
        // fields - public og har derfor PascalCase
        private string _title;
        public string Title { get => _title; set { _title = value; OnPropertyChanged(nameof(Title)); } }

        private bool _isDone;
        public bool IsDone { get => _isDone; set { _isDone = value; OnPropertyChanged(nameof(IsDone)); } }

        private DateOnly _date = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        public DateOnly Date { get => _date; set { _date = value; OnPropertyChanged(nameof(Date));  } }

        // Vi overloader - altså vi laver flere constructors, med forskellige parametre.
        // Det sikrer os at vi kan bruge constructors uden nødvendigvis at have alle informationerne på forhånd
        // Og en constructor uden parametre, sikrer at vi kan instantiere og sætte fields/properties bagefter, uden fejl pga. constructor brug.
        public TodoItem()
        {
            _title = string.Empty;
            _isDone = false;
        }

        public TodoItem(string title)
        {
            _title = title;
            _isDone = false;
        }

        public TodoItem(string title, DateOnly date)
        {
            _title = title;
            _isDone = false;
            _date = date;
        }

        public TodoItem(string title, bool isDone, DateOnly date)
        {
            _title = title;
            _isDone = isDone;
            _date = date;
        }

    }
}
