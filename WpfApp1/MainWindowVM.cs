using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private string _label;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowVM()
        {
            Click = new SimpleCommand(this);
        }
        
        public string LabelText { 
            get { return _label; } 
            set 
            { 
                _label = value;
                this?.PropertyChanged(this, new PropertyChangedEventArgs("LabelText"));
            } 
        }

        public ICommand Click { get; private set; }
    }

    public class SimpleCommand : ICommand
    {
        public MainWindowVM MainWindowVM { get; }

        public event EventHandler? CanExecuteChanged;


        public SimpleCommand(MainWindowVM mainWindowVM)
        {
            MainWindowVM = mainWindowVM;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            MainWindowVM.LabelText = "new text here";
        }
    }
}
