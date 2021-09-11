using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AnimalSim.Animals
{
    public abstract class ElephantBase : AnimalBase
    {
        protected ElephantBase(int energy, string name) : base(energy, name)
        {
        }
        public abstract void EatPineapple();
    }
    public class Elephant : ElephantBase
    {
        public Elephant(int energy, string name) : base(energy, name){}
        public override void EatPineapple() => Energy += 50;
        public override void UseEnergy()
        {
            Energy -= 5;
            if (Energy <= 0)
            {
                AnimalHandler.RemoveAnimal(this);
            }
        }
    }
}
