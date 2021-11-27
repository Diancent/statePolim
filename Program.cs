using System;
using System.Collections.Generic;

namespace laboratorna3_2OOP
{
    class State
    {
        private string formOfGovernment { get; set; }
        private float area { get; set; }
        private float population { get; set; }
        private string currency { get; set; }
        public State(string formOfGovernment, float area, float population, string currency)
        {
            this.formOfGovernment = formOfGovernment;
            this.area = area;
            this.population = population;
            this.currency = currency;
        }
        public string CheckInfoForSearch(string EnteredName)
        {
            if (formOfGovernment.ToLower().Equals(EnteredName.ToLower()))
            {
                return GetInfo();
            }
            return null;
        }
        public double AreaPerPopulation()
        {
            return area / population;
        }
        
        public virtual string GetInfo()
        {
            return $"Форма правління: {formOfGovernment}\nПопуляція: {population}\nВалюта: {currency}";
        }
    }
    class Republic : State
    {
        private string nameOfPresident { get; set; }
        public Republic(string formOfGovernment, float area, float population, string currency, string nameOfPresident) : base(formOfGovernment, area, population, currency)
        {
            this.nameOfPresident = nameOfPresident;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()}\nІм'я президента: {nameOfPresident}";
        }
    }
    class Monarchy : State
    {
        private string nameOfMonarch { get; set; }
        public Monarchy(string formOfGovernment, float area, float population, string currency, string nameOfMonarch) : base(formOfGovernment, area, population, currency)
        {
            this.nameOfMonarch = nameOfMonarch;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()}\nІм'я монарха: {nameOfMonarch}";
        }
    }
    class Kingdom : State
    {
        private string nameOfKing { get; set; }
        public Kingdom(string formOfGovernment, float area, float population, string currency, string nameOfKing) : base(formOfGovernment, area, population, currency)
        {
            this.nameOfKing = nameOfKing;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()}\nІм'я Короля: {nameOfKing}";
        }
    }
    class MainClass
    {
        static List<State> list = new List<State>();
        static void Test()
        {

            Republic republic = new Republic("Republic", 1232131, 300000, "UAH", "Maxim Kovalenko");
            Monarchy monarchy = new Monarchy("Monarchy", 43344334, 5000000, "UAH", "William 3");
            Kingdom kingdom = new Kingdom("Kingdom", 55555555, 6000000, "UAH", "Edward the Elder");
            list.Add(republic);
            list.Add(monarchy);
            list.Add(kingdom);
        }
        static void Menu()
        {
            Console.WriteLine("1. Вивести весь список країн");
            Console.WriteLine("2. Пошук по формі правління");
            Console.WriteLine("3. Розрахунок популяції на площу");
            Console.WriteLine("4. Вихід");
        }
        static void ShowAll()
        {
            //Console.Clear();
            foreach (var item in list)
            {
                if (item.GetType().Name.Equals("Republic"))
                {
                    Console.WriteLine((item as Republic).GetInfo() + "\n");
                }

                else if (item.GetType().Name.Equals("Monarchy"))
                {
                    Console.WriteLine((item as Monarchy).GetInfo() + "\n");
                }

                else if (item.GetType().Name.Equals("Kingdom"))
                {
                    Console.WriteLine((item as Kingdom).GetInfo() + "\n");
                }
            }
            Console.ReadKey();
            //Console.Clear();
        }
        static void Search()
        {
            Console.Clear();
            Console.WriteLine("Пошук: ");
            string EnteredValue = Console.ReadLine();
            Console.Clear();
            int q = 0;
            foreach (var item in list)
            {
                if (item.CheckInfoForSearch(EnteredValue) != null)
                {
                    q++;
                    Console.WriteLine($"Iндекс: {list.IndexOf(item)}\n{item.CheckInfoForSearch(EnteredValue)}\n");
                }
            }
            if (q == 0)
            {
                Console.WriteLine("Нічого не знайдено");
            }
            Console.ReadKey();
            Console.Clear();
        }
        public static void Calculate()
        {
            Console.Clear();
            Console.WriteLine("Виберiть номер країни: ");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Площа на одну людину: {list[index].AreaPerPopulation()}");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Main(string[] args)
        {
            bool w = true;
            while (w)
            {
                Test();
                Menu();
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        {
                            ShowAll();
                            break;
                        }

                    case 2:
                        {
                            Search();
                            break;
                        }
                    case 3:
                        {
                            Calculate();
                            break;
                        }
                    case 4:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
    }
}