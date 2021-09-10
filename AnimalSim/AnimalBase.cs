using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AnimalSim
{
    public abstract class AnimalBase
    {
        public AnimalBase(int energy, string name)
        {
            Energy = energy;
            Name = name;
            aType = this.GetType().Name;
        }
        public abstract void UseEnergy(ObservableCollection<AnimalBase> lv);
        public int Energy { get; set; }
        public string Name { get; set; }
        public string aType { get; set; }
    }
}
