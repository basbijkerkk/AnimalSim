using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AnimalSim.Animals
{
    public abstract class ApeBase : AnimalBase
    {
        protected ApeBase(int energy, string name) : base(energy, name)
        {
        }
        public abstract void EatBanana();
    }
    public class Ape : ApeBase
    {
        public Ape(int energy, string name) : base(energy, name){}
        public override void EatBanana() => Energy += 10;
        public override void UseEnergy(ObservableCollection<AnimalBase> lv)
        {
            Energy -= 2;
            if (Energy <= 0)
            {
                lv.Remove(this);
            }
        }
    }
}
