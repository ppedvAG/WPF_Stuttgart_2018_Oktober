using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplates
{
    public class Person : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        //Snippet: propfull
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                InvokePropertyChanged();
            }
        }

        private int _alter;
        public int Alter
        {
            get { return _alter; }
            set
            {
                _alter = value;
                InvokePropertyChanged(nameof(Volljährig));
                InvokePropertyChanged();
            }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                InvokePropertyChanged();
            }
        }

        private bool _behindert;
        public bool Behindert
        {
            get { return _behindert; }
            set
            {
                _behindert = value;
                InvokePropertyChanged();
            }
        }

        public bool Volljährig => Alter >= 18;

        //Snippet: ctor, Standard-Konstruktor ist notwendig damit auch per XAML Personen-Instanzen definiert
        //werden können
        public Person()
        {

        }

        public Person(string name, int alter, string imageUrl, bool behindert)
        {
            Name = name;
            Alter = alter;
            ImageUrl = imageUrl;
            Behindert = behindert;
        }

        private void InvokePropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
