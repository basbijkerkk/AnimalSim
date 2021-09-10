using System;
using System.Collections.ObjectModel;
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
        public ObservableCollection<AnimalBase> Animals = new ObservableCollection<AnimalBase>();
        DispatcherTimer UseEnergyTimer = new DispatcherTimer();

        private ListView listView;
        private string Animal = "ape";
        const int DefaultEnergy = 100;
        const int ApeEnergy = 60;

        public AnimalHandler(ListView listv)
        {
            listView = listv;
            UseEnergyTimer.Tick += ConsumeTick;
            UseEnergyTimer.Interval = TimeSpan.FromMilliseconds(50);
            UseEnergyTimer.Start();
        }

        private void ConsumeTick(object sender, EventArgs e)
        {
            try
            {
                switch (Animal)
                {
                    case "ape":
                        Animal = "lion";
                        foreach (AnimalBase an in Animals)
                        {
                            if (an.aType == "Ape")
                            {
                                an.UseEnergy(Animals);
                            }
                        }
                        break;
                    case "lion":
                        Animal = "elephant";
                        foreach (AnimalBase an in Animals)
                        {
                            if (an.aType == "Lion")
                            {
                                an.UseEnergy(Animals);
                            }
                        }
                        break;
                    case "elephant":
                        Animal = "ape";
                        foreach (AnimalBase an in Animals)
                        {
                            if (an.aType == "Elephant")
                            {
                                an.UseEnergy(Animals);
                            }
                        }
                        break;
                }
            }
            catch (InvalidOperationException exc)
            {

            }
            finally
            {
                listView.Items.Refresh();
            }
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
                    listView.Items.Refresh();
                    await Task.Delay(100);
                }
            }
            return true;
        }
    }

}
