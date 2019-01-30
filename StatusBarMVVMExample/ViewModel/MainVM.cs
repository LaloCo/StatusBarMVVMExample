using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StatusBarMVVMExample.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private int counter;

        public int Counter
        {
            get { return counter; }
            set
            {
                counter = value;
                OnPropertyChanged("Counter");
            }
        }

        public ICommand AddCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            AddCommand = new AddCommand(this);
        }

        public void AddCounter()
        {
            Counter++;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AddCommand : ICommand
    {
        public MainVM ViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public AddCommand(MainVM viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.AddCounter();
        }
    }
}
