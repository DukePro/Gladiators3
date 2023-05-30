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
        private const string MenuShowAllDescription = "6";
        private const string MenuBack = "0";
        private Arena _arena = new Arena();

        private Gladiator[] _gladiators = new Gladiator[]
            {
                new Fighter(),
                new Rouge(),
                new Knight(),
                new Cleric(),
                new Doppelganger(),
            };

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

            while (isBack == false)
            {
                Console.WriteLine("\nВыберете гладиатора:");
                Console.WriteLine(MenuGladiator1 + $" - {_gladiators[0].СharClass}");
                Console.WriteLine(MenuGladiator2 + $" - {_gladiators[1].СharClass}");
                Console.WriteLine(MenuGladiator3 + $" - {_gladiators[2].СharClass}");
                Console.WriteLine(MenuGladiator4 + $" - {_gladiators[3].СharClass}");
                Console.WriteLine(MenuGladiator5 + $" - {_gladiators[4].СharClass}");
                Console.WriteLine(MenuShowAllDescription + " - Показать описание гладиаторов");
                Console.WriteLine(MenuBack + " - Назад");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case MenuGladiator1:
                        _arena.AddGladiatorToArena(new Fighter());
                        break;

                    case MenuGladiator2:
                        _arena.AddGladiatorToArena(new Rouge());
                        break;

                    case MenuGladiator3:
                        _arena.AddGladiatorToArena(new Knight());
                        break;

                    case MenuGladiator4:
                        _arena.AddGladiatorToArena(new Cleric());
                        break;
                    case MenuGladiator5:
                        _arena.AddGladiatorToArena(new Doppelganger());
                        break;
                    case MenuShowAllDescription:
                        ShowAllGladiators();
                        break;

                    case MenuExit:
                        isBack = true;
                        break;
                }
            }
        }

        private void ShowAllGladiators()
        {
            Console.WriteLine("Список гладиаторов:");

            for (int i = 0; i < _gladiators.Length; i++)
            {
                Console.Write($"{_gladiators[i].СharClass} - "); _gladiators[i].ShowDescription();
                _gladiators[i].ShowShortСharacteristics();
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            }
        }
    }

    class Arena
    {
        private List<Gladiator> _fightingPair = new List<Gladiator>();

        public void AddGladiatorToArena(Gladiator gladiator)
        {
            if (_fightingPair.Count() <= 1)
            {
                _fightingPair.Add(gladiator);
                Console.WriteLine($"Выбран {gladiator.СharClass} {gladiator.Name}");

                if (_fightingPair.Count == 2)
                {
                    Console.WriteLine($"Идущие на смерть {_fightingPair[0].СharClass} {_fightingPair[0].Name} и {_fightingPair[1].СharClass} {_fightingPair[1].Name} приветствуют тебя!");
                }
            }
            else
            {
                Console.WriteLine("На арене уже 2 гладиатора, начните бой!");
            }
        }

        public void Fight()
        {
            if (_fightingPair.Count == 2)
            {
                Gladiator gladiator1 = new Gladiator();
                Gladiator gladiator2 = new Gladiator();

                if (_fightingPair[0].Initiative > _fightingPair[1].Initiative) //Определяем очерёдность сравивая инициативу
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
                    gladiator1.ShowStatus();
                    Console.Write(" | ");
                    gladiator2.ShowStatus();
                    Console.WriteLine();

                    gladiator2.TakeDamage(gladiator1.DealDamage());
                    gladiator1.TakeDamage(gladiator2.DealDamage());
                    Console.WriteLine("\n---------------------------------------------------------------------------------------");
                }

                DecideWin(gladiator1, gladiator2);
                _fightingPair.Clear();
            }
            else
            {
                Console.WriteLine("Для боя нужно 2 гладиатора");
            }
        }

        private void DecideWin(Gladiator gladiator1, Gladiator gladiator2)
        {
            if (gladiator1.Health > 0 && gladiator2.Health < 0)
            {
                Console.WriteLine($"Победил {gladiator1.СharClass} {gladiator1.Name}! {gladiator2.СharClass} {gladiator2.Name} - повержен!");
            }
            else if (gladiator2.Health > 0 && gladiator1.Health < 0)
            {
                Console.WriteLine($"Победил {gladiator2.СharClass} {gladiator2.Name}! {gladiator1.СharClass} {gladiator1.Name} - повержен!");
            }
            else
            {
                Console.WriteLine("Нет победителя, оба погибли.");
            }
        }
    }

    class Gladiator
    {
        private string[] _fantasyNames = new string[]
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

        protected int _maxHealth;
        protected int _armor;
        protected int _maxArmor;
        protected int _hitDamage;
        protected int _baseDamage = 15;
        protected static Random _random = new Random();

        public Gladiator()
        {
            Name = GetName();
            Health = 1000;
            _maxHealth = 1000;
            _armor = 30;
            _maxArmor = 60;
            _hitDamage = 100;
            Initiative = 0;
        }

        public string Name { get; protected set; }
        public string СharClass { get; protected set; }
        public int Initiative { get; protected set; }
        public int Health { get; protected set; }
        public string Description { get; protected set; }

        public virtual int DealDamage()
        {
            int alternateDamage = UseAttackAbility();

            double minDamageMod = 0.8;
            double maxDamageMod = 1.2;
            double damageMod = minDamageMod + (_random.NextDouble() * (maxDamageMod - minDamageMod));

            if (alternateDamage != 0)
            {
                int damage = alternateDamage;
                Console.Write($"{СharClass} {Name} Пытается нанести {damage} урона | ");
                return damage;
            }
            else
            {
                int damage = (int)(_hitDamage * damageMod);
                Console.Write($"{СharClass} {Name} Пытается нанести {damage} урона | ");
                return damage;
            }
        }

        public virtual void TakeDamage(int damage)
        {
            UseDefenceAbility();

            int reducedDamage = damage - _armor;

            if (reducedDamage < _baseDamage)
            {
                reducedDamage = _baseDamage;
            }
            else
            {
                Health -= reducedDamage;
            }

            Console.WriteLine($"{СharClass} {Name} получает {reducedDamage} урона");
        }

        public void ShowStatus()
        {
            Console.Write($"{СharClass} {Name} - Здоровье: {Health}, Броня: {_armor}");
        }

        public void ShowDescription()
        {
            Console.WriteLine(Description);
        }

        public void ShowСharacteristics()
        {
            Console.WriteLine($"Гладиатор - {Name}, Класс - {СharClass}, Урон - {_hitDamage}, Здоровье - {Health}, Макс здоровье - {_maxHealth}, Броня - {_armor}, Макс Броня - {_maxArmor}, Инициатива - {Initiative}");
        }

        public void ShowShortСharacteristics()
        {
            Console.WriteLine($"Урон - {_hitDamage} | Здоровье - {Health} | Макс здоровье - {_maxHealth} | Броня - {_armor} | Макс Броня - {_maxArmor} | Инициатива - {Initiative}");
        }

        protected virtual void UseDefenceAbility()
        {
        }

        protected virtual int UseAttackAbility()
        {
            return 0;
        }

        private string GetName()
        {
            string name = _fantasyNames[_random.Next(0, _fantasyNames.Length - 1)];
            return name;
        }
    }

    class Fighter : Gladiator
    {
        public Fighter()
        {
            СharClass = "Fighter";
            Description = "Сбалансированный боец со случайным начальным уроном, который останется постоянным, каждый удар";
            //_health = 1000;
            //_maxHealth = 1500;
            _hitDamage = _random.Next(100, 120);
            _armor = 20;
            //_maxArmor = 40;
            Initiative = 5;
        }

        public override int DealDamage()
        {
            Console.Write($"{СharClass} {Name} Пытается нанести {_hitDamage} урона | ");
            return _hitDamage;
        }
    }

    class Rouge : Gladiator
    {
        public Rouge()
        {
            СharClass = "Rouge";
            Description = "Вор. Боец с небольшим базовым уроном, но возможностью нанести критический удар или полностью уклониться от атаки";
            //_health = 1000;
            //_maxHealth = 1500;
            _hitDamage = 70;
            _armor = 5;
            //_maxArmor = 40;
            Initiative = 10;
        }

        public override void TakeDamage(int damage)
        {
            bool isDoged = IsDoge();
            int reducedDamage = damage - _armor;

            if (isDoged)
            {
                Console.WriteLine($"{СharClass} {Name} Уклонился от атаки!");
            }
            else
            {
                if (reducedDamage < _baseDamage)
                {
                    reducedDamage = _baseDamage;
                }
                else
                {
                    Health -= reducedDamage;
                }

                Console.WriteLine($"{СharClass} {Name} получает {reducedDamage} урона");
            }
        }

        protected override int UseAttackAbility()
        {
            return UseCriticalHit();
        }

        private int UseCriticalHit()
        {
            double critMultiplier = 3;
            int critChance = 25;
            int baseDamage = _hitDamage;

            if (_random.Next(0, 100) < critChance)
            {
                baseDamage = Convert.ToInt32(Math.Round(baseDamage * critMultiplier));
                Console.WriteLine($"{Name} наносит критический удар!");
            }

            return baseDamage;
        }

        private bool IsDoge()
        {
            int dogeChance = 20;
            bool isDoged = false;

            if (_random.Next(0, 100) < dogeChance)
            {
                isDoged = true;
            }
            else
            {
                isDoged = false;
            }

            return isDoged;
        }
    }

    class Knight : Gladiator
    {
        private int _shieldArmor;

        public Knight()
        {
            СharClass = "Knight";
            Description = "Рыцарь. Весь в броне и со щитом, которым может воспользоваться в любой момент и увеличить свою броню";
            //_health = 1000;
            //_maxHealth = 1500;
            //_hitDamage = 100;
            _armor = 30;
            _maxArmor = 80;
            Initiative = 1;
        }

        protected override void UseDefenceAbility()
        {
            if (_shieldArmor > 0)
            {
                _armor -= _shieldArmor;
            }

            _shieldArmor = RiseShield();

            if (_armor + _shieldArmor < _maxArmor)
            {
                _armor += _shieldArmor;
            }
            else
            {
                _armor = _maxArmor;

                Console.WriteLine("Броня максимальна!");
            }
        }

        private int RiseShield()
        {
            int getArmorChance = 30;
            int addArmor = 20;
            int extraArmor = 0;

            if (_random.Next(0, 100) < getArmorChance)
            {
                extraArmor += addArmor;
                Console.WriteLine($"{СharClass} {Name} Поднял щит, добавлено {extraArmor} брони!");
            }

            return extraArmor;
        }
    }

    class Cleric : Gladiator
    {
        public Cleric()
        {
            СharClass = "Cleric";
            Description = "Боевой храмовник. Может вылечить себя после удара";
            //_health = 1000;
            _maxHealth = 1300;
            //_hitDamage = 100;
            _armor = 30;
            //_maxArmor = 40;
            Initiative = 3;
        }

        protected override void UseDefenceAbility()
        {
            int healAmmount = Heal();

            if (Health + healAmmount > _maxHealth)
            {
                Health = _maxHealth;
            }
            else
            {
                Health += healAmmount;
            }
        }

        private int Heal()
        {
            int getHealthChance = 20;
            int addHealth = 50;
            int extraHealth = 0;

            if (_random.Next(0, 100) <= getHealthChance)
            {
                extraHealth += addHealth;
                Console.WriteLine($"{СharClass} {Name} восстанавливает: " + addHealth + " здоровья!");
            }

            return extraHealth;
        }
    }

    class Doppelganger : Gladiator
    {
        public Doppelganger()
        {
            СharClass = "Doppelganger";
            Description = "Странная раздвоенная сущность. Может, как нанести двойной урон, или разделить полученный между сущностями";
            //_health = 1000;
            //_maxHealth = 1500;
            _hitDamage = 60;
            _armor = 15;
            //_maxArmor = 40;
            Initiative = 7;
        }

        public override void TakeDamage(int damage)
        {
            int healthBeforeDamage = Health;
            damage = DevideDamage(damage);

            if (damage <= _armor)
            {
                Health -= DevideDamage(_baseDamage);
            }
            else
            {
                Health = Math.Max(0, Health - (damage - _armor));
            }

            Console.WriteLine($"{СharClass} {Name} Получает " + (healthBeforeDamage - Health) + " урона");
        }

        protected override int UseAttackAbility()
        {
            return DoubleHit();
        }

        private int DoubleHit()
        {
            int hitMultiplier = 2;
            int doubleHitChance = 50;
            int baseDamage = _hitDamage;

            if (_random.Next(0, 100) < doubleHitChance)
            {
                baseDamage = baseDamage * hitMultiplier;
                Console.WriteLine($"{СharClass} {Name} Наносит двойной удар!");
            }

            return baseDamage;
        }

        private int DevideDamage(int damage)
        {
            int devideDamageChance = 50;
            int devideDamageBy = 2;

            if (_random.Next(0, 100) <= devideDamageChance)
            {
                damage = damage / devideDamageBy;
                Console.WriteLine($"{СharClass} {Name} Разделяет урон между своими сущностями!");
            }

            return damage;
        }
    }
}