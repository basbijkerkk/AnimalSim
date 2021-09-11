using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AnimalSim.Animals
{
    public abstract class LionBase : AnimalBase
    {
        protected LionBase(int energy, string name) : base(energy, name)
        {
        }
        public abstract void EatMeat();
    }
    public class Lion : LionBase
    {
        public Lion(int energy, string name) : base(energy, name){}
        public override void EatMeat() => Energy += 25;
        public override void UseEnergy()
        {
            Energy -= 10;
            if(Energy <= 0)
            {
                AnimalHandler.RemoveAnimal(this);
            }
        }
    }
}
