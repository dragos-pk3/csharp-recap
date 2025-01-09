using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task2
{


    class Player
    {
        private string _name = string.Empty;
        private int _level;
        private int _max_health;
        private int _current_health;
        private int _power;


        public Player(string name, int power)
        {
            Name = name;
            Power = power;
            _level = 1;

        }

        public string Name
        {
            get { return _name; }
            set
            {
                string cleanName = Regex.Replace(value, @"[^a-zA-Z]", "");

                if (!string.IsNullOrEmpty(cleanName))
                {
                    _name = char.ToUpper(cleanName[0]) + cleanName.Substring(1).ToLower();
                }
                else
                {
                    _name = "Nameless";
                }
            }
        }

        public int Power
        {
            get { return _power; }
            set
            {
                if (value >= 10000)
                {
                    _power = 1;
                }
                else if (value < 10000 && value >= 9000)
                {
                    _power = 10;
                }
                else
                {
                    _power = 5;
                }
                InitializeHealth();
            }
        }

        private void InitializeHealth()
        {
            _max_health = _power * 10;
            _current_health = _max_health;

        }

        public void TakeDamage(int damage)
        {
            _current_health -= damage;
            if (_current_health <= 0)
            {
                _current_health = 0;
            }
        }

        public Dictionary<string, object> PlayerStats()
        {
            return new Dictionary<string, object>
            {
                { "Name", _name },
                { "Level", _level },
                { "Power", _power },
                { "MaxHealth", _max_health },
                { "CurrentHealth", _current_health }
            };
        }

        public void ReadStats(Dictionary<string, object> stats){
            foreach (var stat in stats)
            {
                Console.WriteLine($"{stat.Key}: {stat.Value}");
            }
        }
    }
}