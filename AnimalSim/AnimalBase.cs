using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AnimalSim
{
    public abstract class AnimalBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private int _Energy;
        public AnimalBase(int energy, string name)
        {
            Energy = energy;
            Name = name;
            aType = this.GetType().Name;
        }
        public int Energy 
        {
            get { return _Energy; }
            set { _Energy = value; PropertyChanged(this, new PropertyChangedEventArgs("Energy")); } 
        }
        public string Name { get; private set; }
        public string aType { get; private set; }

        public abstract void UseEnergy();
    }
}
