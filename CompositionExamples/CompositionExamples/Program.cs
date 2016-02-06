using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionExamples
{
    class Program
    {
        static void Main(string[] args)
        {

            var fish = new Fish(new Animal(), new Swimmable());

            var animal = new Animal();
            var walk = new Walkable();
            var dog = new Dog(animal, walk);
            var type = dog.GetType();
            dog.Age = 12;
            dog.Walk(type);
            Console.WriteLine(dog.Age);
            fish.Swim(fish.GetType());

        }
    }

    public class Animal
    {
        public int Age { get; set; }

        public Animal()
        {
            Console.WriteLine("Animal is beeing initialized");
        }

        public void Sleep(Object obj)
        {
            Console.WriteLine("This object " + obj + " eats");
        }
        public void Eat() { }

    }
    public class Swimmable
    {
        public Swimmable()
        {
            Console.WriteLine("Swimmable is beeing initialized");
        }
        public void Swim(Object obj)
        {
            Console.WriteLine("This object" + obj + "  can swim");
        }
    }
    public class Walkable
    {
        public Walkable()
        {
            Console.WriteLine("Walkable is beeing initialized");
        }

        public void Walk(Object obj)
        {
            Console.WriteLine("This object " + obj.ToString() + " can walk");
        }
    }

    public class Dog
    {
        private Animal _animal;
        private Walkable _walkabel;


        public Dog(Animal animal, Walkable walkable)
        {
            _animal = animal;
            _walkabel = walkable;
          
        }

        public int Age
        {
            get { return _animal.Age; }
            set { _animal.Age = value; }
        }

        public void Walk(Object obj)
        {
            _walkabel.Walk(obj);
        }

        public void Eat()
        {
            _animal.Eat();
        }
    }

    public class Fish
    {
        private Animal _animal;
        private Swimmable _swimmable;
        public int Age => _animal.Age;

        public Fish(Animal animal, Swimmable swimmable)
        {
            _animal = animal;
            _swimmable = swimmable;
        }

        public void Swim(Object obj)
        {
            _swimmable.Swim(obj);
        }
    }


}
