using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplates
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Person> Personen { get; set; }

        private Person _ausewähltePerson;
        public Person AusgewähltePerson
        {
            get
            {
                return _ausewähltePerson;
            }
            set
            {
                _ausewähltePerson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AusgewähltePerson)));
            }
        }

        private int _index = 0;
        public int Index
        {
            get
            {
                return _index + 1;
            }
            set
            {
                _index = value - 1;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PersonFromIndex)));
            }
        }

        public Person PersonFromIndex
        {
            get
            {
                if (Index - 1 < 0 || Index - 1 > Personen.Count - 1)
                    return null;
                return Personen[Index - 1];
            }
        }

        public ViewModel()
        {
            Personen = new ObservableCollection<Person>();
            Personen.Add(new Person("Dieter Bohlen", 64, "https://aisrtl-a.akamaihd.net/themenarchiv/dieter-bohlen-bilder/460x0/dieter-bohlen-t5045.jpg", true));
            Personen.Add(new Person("Elon Musk", 47, "https://upload.wikimedia.org/wikipedia/commons/thumb/4/49/Elon_Musk_2015.jpg/220px-Elon_Musk_2015.jpg", false));
            AusgewähltePerson = Personen[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void WähleÄltestePersonAus()
        {
            AusgewähltePerson = Personen.OrderByDescending(p => p.Alter).First();
        }
    }
}