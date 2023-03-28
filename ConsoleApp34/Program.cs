using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp34
{
    public interface Anim
    {
        bool Age { get; set; }
    }
    public abstract class Trava : Anim
    {
        public bool Age { get; set; }
        public double Ves { get; set; }
        public abstract double Eat_trava();
        public abstract string ToString();
    }
    public class Dika : Trava
    {
        public Dika()
        {
            Age = true;
            Ves = 0;
        }
        public Dika(double massa)
        {
            Ves = massa;
            Age = true;
        }
        public override double Eat_trava()
        {
            if (Ves < 0)
            {
                Age = false;
                return Ves;
            }
            return Ves += 10;
        }

        public override string ToString()
        {
            return $"Животное = {Age}    Масса = {Ves}";
        }
    }
    public class Bizon : Trava
    {
        public Bizon()
        {
            Age = true;
            Ves = 0;
        }
        public Bizon(double massa)
        {
            Ves = massa;
            Age = true;
        }
        public override double Eat_trava()
        {
            if (Ves < 0)
            {
                Age = false;
                return Ves;
            }
            return Ves += 10;
        }   
        public override string ToString()
        {
            return $"Бизон = {Age}    Масса =  {Ves}";
        }   
    }
    public abstract class Predator : Anim
    {
        public bool Age { get; set; }
        public bool Live { get; set; }
        public double Sila { get; set; }
        public abstract double Eat(Trava est_travy);
        public abstract string ToString();
    }
    public class Lev : Predator
    {
        public Lev()
        {
            Live = true;
            Sila = 0;
        }
        public Lev(double sila)
        {
            Sila = sila;
            Live = true;
        }
        public override double Eat(Trava est_trava)
        {
            if (Sila < 0)
            {
                Live = false;
                return Sila;
            }
            if (Sila > est_trava.Ves)
            {
                est_trava.Age = false;
                return Sila += 10;
            }
            if (Sila == est_trava.Ves)
            {
                return Sila;
            }
            return Sila -= 10;
        }
        public override string ToString()
        {
            return $"Лев = {Live}  Масса ={Sila}";
        }
    }
    public class Volk : Predator
    {
        public Volk()
        {
            Live = true;
            Sila = 0;
        }
        public Volk(double sila)
        {
            Sila = sila;
            Live = true;
        }
        public override double Eat(Trava trava)
        {
            if (Sila < 0)
            {
                Live = false;
                return Sila;
            }
            if (Sila > trava.Ves)
            {
                trava.Age = false;
                return Sila += 10;
            }
            if (Sila == trava.Ves)
            {
                return Sila;
            }
            return Sila -= 10;
        }
        public override string ToString()
        {
            return $" Волк = {Live} Масса = {Sila}";
        }
    }
    public abstract class Strana
    {
        public List<Trava> list_trava { get; set; }
        public List<Predator> list_predator { get; set; }
        public abstract void Creations_trava(Trava trava);
        public abstract void Creation_Predator(Predator predator);
    }
    public class Africa : Strana
    {
        public Africa()
        {
            list_trava = new List<Trava>();
            list_predator = new List<Predator>();
        }
        public override void Creations_trava(Trava herbivores)
        {
            list_trava.Add(herbivores);
        }
        public override void Creation_Predator(Predator predators)
        {
            list_predator.Add(predators);
        }
    }
    public class Sever_America : Strana
    {
        public override void Creations_trava(Trava herbivores)
        {
            list_trava.Add(herbivores);
        }
        public override void Creation_Predator(Predator predators)
        {
            list_predator.Add(predators);
        }
    }
    public class World_Animal
    {
        public void Show_Animal_trava(Strana strana)
        {
            for (int i = 0; i < strana.list_trava.Count; i++)
                Console.WriteLine(strana.list_trava[i].ToString());
        }
        public void Show_Animal_Rredator(Strana strana)
        {
            for (int i = 0; i < strana.list_predator.Count; i++)
                Console.WriteLine(strana.list_predator[i].ToString());
        }   
        public void Pitanie_trava(Strana strana)
        {
            for (int i = 0; i < strana.list_trava.Count; i++)
                strana.list_trava[i].Eat_trava();
        }
        public void Pitanie_Predator(Strana strana)
        {
            int j = 0;
            for (int i = 0; i < strana.list_predator.Count || j < strana.list_trava.Count; i++, j++)
                strana.list_predator[i].Eat(strana.list_trava[j]);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Africa africa = new Africa();
            Volk volk = new Volk(70);
            Lev lev = new Lev(100);
            africa.Creation_Predator(volk);
            africa.Creation_Predator(lev);
            World_Animal world = new World_Animal();
            world.Show_Animal_trava(africa);
            world.Show_Animal_Rredator(africa);
            world.Pitanie_Predator(africa);
            world.Show_Animal_trava(africa);
            world.Show_Animal_Rredator(africa);
        }
    }
}