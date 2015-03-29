using System;
using System.Collections.Generic;
namespace AcademyEcosystem
{
    public class ExtendedEngine : Engine
    {
        protected new static readonly char[] separators = new char[] { ' ' };

        protected new List<Organism> allOrganisms;
        protected new List<Plant> plants;
        protected new List<Animal> animals;

        public ExtendedEngine()
        {
            this.allOrganisms = new List<Organism>();
            this.plants = new List<Plant>();
            this.animals = new List<Animal>();
        }
        public new void AddOrganism(Organism organism)
        {
            this.allOrganisms.Add(organism);

            var organismAsAnimal = organism as Animal;
            var organismAsPlant = organism as Plant;

            if (organismAsAnimal != null)
            {
                this.animals.Add(organismAsAnimal);
            }

            if (organismAsPlant != null)
            {
                this.plants.Add(organismAsPlant);
            }
        }

        protected override void ExecuteBirthCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "deer":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Deer(name, position));
                        break;
                    }
                case "wolf":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Wolf(name, position));
                        break;
                    }
                case "lion":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Lion(name, position));
                        break;
                    }
                case "boar":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Boar(name, position));
                        break;
                    }
                case "zombie":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Zombie(name, position));
                        break;
                    }
                case "tree":
                    {
                        Point position = Point.Parse(commandWords[2]);
                        this.AddOrganism(new Tree(position));
                        break;
                    }
                case "bush":
                    {
                        Point position = Point.Parse(commandWords[2]);
                        this.AddOrganism(new Bush(position));
                        break;
                    }
                case "grass":
                    {
                        Point position = Point.Parse(commandWords[2]);
                        this.AddOrganism(new Grass(position));
                        break;
                    }
            }
        }
        protected override void ExecuteAnimalCommand(string[] commandWords)
        {
            switch (commandWords[0])
            {
                case "go":
                    {
                        string name = commandWords[1];
                        Point destination = Point.Parse(commandWords[2]);
                        destination = HandleGo(name, destination);
                        break;
                    }
                case "sleep":
                    {
                        string name = commandWords[1];
                        int sleepTime = int.Parse(commandWords[2]);
                        HandleSleep(name, sleepTime);
                        break;
                    }
            }
        }
        private Point HandleGo(string name, Point destination)
        {
            Animal current = GetAnimalByName(name);

            if (current != null)
            {
                int travelTime = Point.GetManhattanDistance(current.Location, destination);
                this.UpdateAll(travelTime);
                current.GoTo(destination);

                HandleEncounters(current);
            }
            return destination;
        }

        private void HandleEncounters(Animal current)
        {
            List<Organism> allEncountered = new List<Organism>();
            foreach (var organism in this.allOrganisms)
            {
                if (organism.Location == current.Location && !(organism == current))
                {
                    allEncountered.Add(organism);
                }
            }

            var currentAsHerbivore = current as IHerbivore;
            if (currentAsHerbivore != null)
            {
                foreach (var encountered in allEncountered)
                {
                    int eatenQuantity = currentAsHerbivore.EatPlant(encountered as Plant);
                    if (eatenQuantity != 0)
                    {
                        Console.WriteLine("{0} ate {1} from {2}", current, eatenQuantity, encountered);
                    }
                }
            }

            allEncountered.RemoveAll(o => !o.IsAlive);

            var currentAsCarnivore = current as ICarnivore;
            if (currentAsCarnivore != null)
            {
                foreach (var encountered in allEncountered)
                {
                    int eatenQuantity = currentAsCarnivore.TryEatAnimal(encountered as Animal);
                    if (eatenQuantity != 0)
                    {
                        Console.WriteLine("{0} ate {1} from {2}", current, eatenQuantity, encountered);
                    }
                }
            }

            this.RemoveAndReportDead();
        }
        private void HandleSleep(string name, int sleepTime)
        {
            Animal current = GetAnimalByName(name);
            if (current != null)
            {
                current.Sleep(sleepTime);
            }
        }

        private Animal GetAnimalByName(string name)
        {
            Animal current = null;
            foreach (var animal in this.animals)
            {
                if (animal.Name == name)
                {
                    current = animal;
                    break;
                }
            }
            return current;
        }

        protected override void RemoveAndReportDead()
        {
            foreach (var organism in this.allOrganisms)
            {
                if (!organism.IsAlive)
                {
                    Console.WriteLine("{0} is dead ;(", organism);
                }
            }

            this.allOrganisms.RemoveAll(o => !o.IsAlive);
            this.plants.RemoveAll(o => !o.IsAlive);
            this.animals.RemoveAll(o => !o.IsAlive);
        }

        protected override void UpdateAll(int timeElapsed)
        {
            foreach (var organism in this.allOrganisms)
            {
                organism.Update(timeElapsed);
            }
        }
    }
}
