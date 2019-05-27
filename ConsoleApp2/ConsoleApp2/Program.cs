using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(new WoodWordFactory());
            client.RunFoofChain();
            client = new Client(new SeaWordFactory());
            client.RunFoofChain();
        }
    }

    public abstract class Plant
    {
        public abstract void Grow();
    }

    public abstract class Harbiwore
    {
        public abstract void EatPlant(Plant plant);
    }

    public abstract class Predator
    {
        public abstract void EatHarbiwore(Harbiwore harbiwore);
    }


    public class Grass : Plant
    {
        public override void Grow()
        {
            Console.WriteLine("Растет трава");
        }
    }
    public class Seaweed : Plant
    {
        public override void Grow()
        {
            Console.WriteLine("Растет водорость");
        }
    }



    public class Rabbit : Harbiwore
    {
        public override void EatPlant(Plant plant)
        {
            Console.WriteLine($"Кроллк ест {plant.GetType().Name}");
        }
    }

    public class Fish : Harbiwore
    {
        public override void EatPlant(Plant plant)
        {
            Console.WriteLine($"Рыба ест {plant.GetType().Name}");
        }
    }



    public class Wolf : Predator
    {
        public override void EatHarbiwore(Harbiwore harbiwore)
        {
            Console.WriteLine($"Волк ест {harbiwore.GetType().Name}");
        }
    }

    public class Shark : Predator
    {
        public override void EatHarbiwore(Harbiwore harbiwore)
        {
            Console.WriteLine($"Акула ест {harbiwore.GetType().Name}");
        }
    }






    public abstract class WordFactory
    {
        abstract public Plant CreatePlant();
        abstract public Harbiwore CreateHarbiwore();
        abstract public Predator CreatePredator();
    }


    public class WoodWordFactory : WordFactory
    {
        public override Harbiwore CreateHarbiwore()
        {
            return new Rabbit();
        }

        public override Plant CreatePlant()
        {
            return new Grass();
        }

        public override Predator CreatePredator()
        {
            return new Wolf();
        }
    }


    public class SeaWordFactory : WordFactory
    {
        public override Harbiwore CreateHarbiwore()
        {
            return new Fish();
        }

        public override Plant CreatePlant()
        {
            return new Seaweed();
        }

        public override Predator CreatePredator()
        {
            return new Shark();
        }
    }


    public class Client
    {
        private Plant plant;
        private Harbiwore harbiwore;
        private Predator predator;
        public Client(WordFactory wf)
        {
            plant = wf.CreatePlant();
            harbiwore = wf.CreateHarbiwore();
            predator = wf.CreatePredator();

        }

        public void RunFoofChain()
        {
            plant.Grow();
            harbiwore.EatPlant(plant);
            predator.EatHarbiwore(harbiwore);
        }

    }
}