using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using AnimalSim.Animals;

namespace AnimalSim
{
    public class AnimalHandler
    {
        public static ObservableCollection<AnimalBase> Animals = new ObservableCollection<AnimalBase>();
        DispatcherTimer UseEnergyTimer = new DispatcherTimer();

        private string AnimalSwitch = "ape";
        const int DefaultEnergy = 100;
        const int ApeEnergy = 60;

        public AnimalHandler()
        {
            UseEnergyTimer.Tick += ConsumeTick;
            UseEnergyTimer.Interval = TimeSpan.FromMilliseconds(500);
            UseEnergyTimer.Start();
        }
        public static void RemoveAnimal(AnimalBase anim)
        {
            if (Animals.Contains(anim))
                Animals.Remove(anim);
        }
        public void GenerateApe(string name)
        {
            if(!Animals.Contains(new Ape(ApeEnergy, name)))
                Animals.Add(new Ape(ApeEnergy, name));
        }
        public void GenerateElephant(string name)
        {
            if(!Animals.Contains(new Elephant(DefaultEnergy, name)))
                Animals.Add(new Elephant(DefaultEnergy, name));
        }
        public void GenerateLion(string name)
        {
            if(!Animals.Contains(new Lion(DefaultEnergy, name)))
                Animals.Add(new Lion(DefaultEnergy, name));
        }

        public async Task<bool> FeedAnimal(string anType)
        {
            foreach(dynamic Animal in Animals)
            {

                if (Animal.aType == anType.Split("'")[0] || anType == "Feed All")
                {
                    switch (Animal.aType.ToLower())
                    {
                        case "ape":
                            Animal.EatBanana();
                            break;
                        case "lion":
                            Animal.EatMeat();
                            break;
                        case "elephant":
                            Animal.EatPineapple();
                            break;
                    }
                    await Task.Delay(100);
                }
            }
            return true;
        }
        private void ConsumeTick(object sender, EventArgs e)
        {
            try
            {
                switch (AnimalSwitch)
                {
                    case "ape":
                        AnimalSwitch = "lion";
                        foreach (AnimalBase an in Animals)
                            if (an.aType == "Ape")
                                an.UseEnergy();
                        break;

                    case "lion":
                        AnimalSwitch = "elephant";
                        foreach (AnimalBase an in Animals)
                            if (an.aType == "Lion")
                                an.UseEnergy();
                        break;

                    case "elephant":
                        AnimalSwitch = "ape";
                        foreach (AnimalBase an in Animals)
                            if (an.aType == "Elephant")
                                an.UseEnergy();
                        break;
                }
            }
            catch (InvalidOperationException)
            {

            }
        }
    }

}
