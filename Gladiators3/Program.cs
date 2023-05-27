﻿using System;
using System.Xml.Linq;

namespace Gladiators
{
    class Programm
    {
        static void Main()
        {
            Menu menu = new Menu();
            menu.ShowMainMenu();
        }
    }

    class Menu
    {
        private const string MenuChooseGladiators = "1";
        private const string MenuFight = "2";
        private const string MenuExit = "0";
        private const string MenuGladiator1 = "1";
        private const string MenuGladiator2 = "2";
        private const string MenuGladiator3 = "3";
        private const string MenuGladiator4 = "4";
        private const string MenuGladiator5 = "5";
        private const string MenuBack = "0";
        private Arena _arena = new Arena();
        private Fighter _fighter = new Fighter();

        public void ShowMainMenu()
        {
            bool isExit = false;
            string userInput;

            while (isExit == false)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine(MenuChooseGladiators + " - Выбор гладиаторов");
                Console.WriteLine(MenuFight + " - Бой!");
                Console.WriteLine(MenuExit + " - Выход");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case MenuChooseGladiators:
                        ShowFightersMenu();
                        break;

                    case MenuFight:
                        _arena.Fight();
                        break;

                    case MenuExit:
                        isExit = true;
                        break;
                }
            }
        }

        public void ShowFightersMenu()
        {
            bool isBack = false;
            string userInput;

            Gladiator[] gladiators = new Gladiator[]
            {
                new Fighter(),
                //new Rouge(),
                //new Knight(),
                //new Cleric(),
                //new Doppelganger(),
            };

            while (isBack == false)
            {
                Console.WriteLine("Список гладиаторов:");

                //ShowAllGladiators();

                Console.WriteLine("\nВыберете гладиатора:");
                Console.WriteLine(MenuGladiator1 + " - " + _fighter.СharClass); // Косяк. Выбирается один и тот же гладиатор.
                //Console.WriteLine(MenuGladiator2 + " - " + _rouge.Name);
                //Console.WriteLine(MenuGladiator3 + " - " + _knight.Name);
                //Console.WriteLine(MenuGladiator4 + " - " + _cleric.Name);
                //Console.WriteLine(MenuGladiator5 + " - " + _doppelganger.Name);
                Console.WriteLine(MenuBack + " - Назад");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case MenuGladiator1:
                        Console.WriteLine("Выбран " + _fighter.Name);
                        _arena.AddGladiatorToArena(new Fighter());
                        break;

                    case MenuGladiator2:
                        //Console.WriteLine("Выбран " + _rouge.Name);
                        //AddGladiatorToArena(new Rouge());
                        break;

                    case MenuGladiator3:
                        //Console.WriteLine("Выбран " + _knight.Name);
                        //AddGladiatorToArena(new Knight());
                        break;

                    case MenuGladiator4:
                        //Console.WriteLine("Выбран " + _cleric.Name);
                        //AddGladiatorToArena(new Cleric());
                        break;
                    case MenuGladiator5:
                        //Console.WriteLine("Выбран " + _doppelganger.Name);
                        //AddGladiatorToArena(new Doppelganger());
                        break;

                    case MenuExit:
                        isBack = true;
                        break;
                }

                //if (_arena.Gladiators.Count == 2)
                //{
                //    Console.WriteLine($"Идущие на смерть {_arena.Gladiators[0].Name} и {_arena.Gladiators[1].Name} приветствуют тебя!");
                //    isBack = true;
                //}
            }
        }

        //private void ShowAllGladiators()
        //{
        //    _fighter.ShowStats();
        //    Console.WriteLine("Сбалансированный боец со случайным начальным уроном, который останется постоянным, каждый удар.");
        //    _rouge.ShowStats();
        //    Console.WriteLine("Вор - боец с небольшим базовым уроном, но возможностью нанести критический удар или полностью уклониться от атаки.");
        //    _knight.ShowStats();
        //    Console.WriteLine("Рыцарь. Весь в броне и со щитом, которым может воспользоваться в любой момент и увеличить свою броню.");
        //    _cleric.ShowStats();
        //    Console.WriteLine("Боевой храмовник. Может вылечить себя после удара.");
        //    _doppelganger.ShowStats();
        //    Console.WriteLine("Странная раздвоенная сущность. Может, как нанести двойной урон, так и разделить полученный между сущностями.");
        //}

        //private void AddGladiatorToArena(Gladiator gladiator)
        //{
        //    _arena.Gladiators.Add(gladiator);
        //}
    }

    class Arena
    {
        private List<Gladiator> _fightingPair = new List<Gladiator>();

        public void AddGladiatorToArena(Gladiator gladiator)
        {
            if (_fightingPair.Count() <= 1)
            {
                _fightingPair.Add(gladiator);
            }
            else
            {
                Console.WriteLine("На арене уже 2 гладиатора");
            }
        }

        public void Fight() //Бой не начинается...
        {
            Gladiator gladiator1 = new Gladiator();
            Gladiator gladiator2 = new Gladiator();

            if (_fightingPair[0].Initiative > _fightingPair[1].Initiative)
            {
                gladiator1 = _fightingPair[0];
                gladiator2 = _fightingPair[1];
            }
            else
            {
                gladiator2 = _fightingPair[0];
                gladiator1 = _fightingPair[1];
            }

            while (gladiator1.Health > 0 && gladiator2.Health > 0)
            {
                gladiator2.TakeDamage(gladiator1.DealDamage());
                gladiator1.TakeDamage(gladiator2.DealDamage());
            }

            if (gladiator1.Health > 0 && gladiator2.Health < 0)
            {
                Console.WriteLine($"Победил {gladiator1.СharClass} {gladiator1.Name}! {gladiator2.СharClass} {gladiator2.Name} - повержен!");
            }
        }


    }

    //class Baraks
    //{
    //    private Names _names = new Names();

    //}

    class Names
    {
        string[] fantasyNames = new string[]
        {
    "Aethelind",
    "Brynhildr",
    "Caelan",
    "Delphinia",
    "Eldric",
    "Faldir",
    "Galadria",
    "Hadriel",
    "Ithilwen",
    "Jareth",
    "Kaelyn",
    "Lysander",
    "Morgana",
    "Niamh",
    "Orion",
    "Persephone",
    "Quillan",
    "Rhiannon",
    "Seraphina",
    "Thaddeus",
    "Ursula",
    "Vespera",
    "Wyndham",
    "Xanthia",
    "Yvaine",
    "Zephyr",
    "Arabelle",
    "Bastian",
    "Celestia",
    "Dorian"
        };

       public string GetName()
        {
            Random random = new Random();
            string name = fantasyNames[random.Next(0, fantasyNames.Length - 1)];
            return name;
        }
    }

    class Gladiator
    {
        private Names _names = new Names();
        
        
        
        protected int _maxHealth;
        protected int _armor;
        protected int _maxArmor;
        protected int _hitDamage;
        protected int _baseDamage = 15;
        

        public Gladiator()
        {
            Name = _names.GetName();
            Health = 1000;
            _maxHealth = 1200;
            _armor = 30;
            _maxArmor = 60;
            _hitDamage = 100;
            Initiative = 0;
        }

        //public Gladiator(string type, string description, int health, int maxHealth, int armor, int maxArmor, int hitDamage, int initiative)
        //{
        //    _name = _names.GetName();
        //    Type = type;
        //    Description = description;
        //    _health = health;
        //    _maxHealth = maxHealth;
        //    _armor = armor;
        //    _maxArmor = maxArmor;
        //    _hitDamage = hitDamage;
        //    _initiative = initiative;
        //}

        public string Name { get; protected set; }
        public string СharClass { get; protected set; }
        public int Initiative { get; protected set; }
        public int Health { get; protected set; }
        public string Description { get; protected set; }
        protected static Random _random = new Random();

        public virtual int DealDamage()
        {
            double minDamageMod = 0.8;
            double maxDamageMod = 1.2;
            double damageMod = minDamageMod + (_random.NextDouble() * (maxDamageMod - minDamageMod));
            int damage = (int)(_hitDamage * damageMod);

            return damage;
        }

        public virtual void TakeDamage(int damage)
        {
            int reducedDamage = damage - _armor;

            if (reducedDamage < _baseDamage)
            {
                reducedDamage = _baseDamage;
            }
            else
            {
                Health -= reducedDamage;
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Гладиатор - {Name}, Здоровье - {Health}, Броня - {_armor}");
        }

        public void ShowDescription()
        {
            Console.WriteLine(Description);
        }

        public void ShowСharacteristics()
        {
            Console.WriteLine($"Гладиатор - {Name}, Класс - {СharClass}, Урон - {_hitDamage}, Здоровье - {Health}, Макс здоровье - {_maxHealth}, Броня - {_armor}, Макс Броня - {_maxArmor}, Инициатива - {Initiative}");
        }

    }

    class Fighter : Gladiator
    {
        public Fighter()
        {
            СharClass = "Fighter";
            Description = "Сбалансированный боец со случайным начальным уроном, который останется постоянным, каждый удар.";
            //_health = 1000;
            //_maxHealth = 1500;
            _hitDamage = _random.Next(90, 130);
            _armor = 20;
            //_maxArmor = 40;
            Initiative = 3;
        }

        //public Fighter(string type, string description, int health, int maxHealth, int armor, int maxArmor, int hitDamage, int initiative)
        //    : base(type, description, health, maxHealth, armor, maxArmor, hitDamage, initiative)
        //{
        //    _type = "Fighter";
        //    Description = "Сбалансированный боец со случайным начальным уроном, который останется постоянным, каждый удар.";
        //    _health = 1000;
        //    _maxHealth = 1500;
        //    _hitDamage = _random.Next(90, 130);
        //    _armor = 20;
        //    _maxArmor = 40;
        //    _initiative = 3;
        //}

        public override int DealDamage()
        {
            return _hitDamage;
        }
    }

    //class Rouge : Gladiator
    //{

    //}

    //class Knight : Gladiator
    //{

    //}

    //class Cleric : Gladiator
    //{

    //}

    //class Doppelganger : Gladiator
    //{

    //}
}