using System;
using System.Collections.Generic;
using System.Linq;

namespace HW8
{
    public interface IPart
    {
        void BuildThis();
        string ToString();
    }

    public interface IWorker
    {
        void Work(Dictionary<IPart, IWorker> plan);
    }

    public class Basemante : IPart
    {
        public string? Name { get; set; }
        public bool Built { get; set; }

        public Basemante(bool built, string? name)
        {
            Built = built;
            Name = name;
        }

        public Basemante() { Built = false; }

        public void BuildThis()
        {
            Built = true;
        }

        public override string ToString()
        {
            return $"Basemante - {Name}: Built={Built}";
        }
    }

    public class Walls : IPart
    {
        public string? Name { get; set; }
        public bool Built { get; set; }

        public Walls(bool built, string? name)
        {
            Built = built;
            Name = name;
        }

        public Walls() { Built = false; }

        public void BuildThis()
        {
            Built = true;
        }

        public override string ToString()
        {
            return $"Walls - {Name}: Built={Built}";
        }
    }

    public class Door : IPart
    {
        public string? Name { get; set; }
        public bool Built { get; set; }

        public Door(bool built, string? name)
        {
            Built = built;
            Name = name;
        }

        public Door() { Built = false; }

        public void BuildThis()
        {
            Built = true;
        }

        public override string ToString()
        {
            return $"Door - {Name}: Built={Built}";
        }
    }

    public class Windows : IPart
    {
        public string? Name { get; set; }
        public bool Built { get; set; }

        public Windows(bool built, string? name)
        {
            Built = built;
            Name = name;
        }

        public Windows() { Built = false; }

        public void BuildThis()
        {
            Built = true;
        }

        public override string ToString()
        {
            return $"Windows - {Name}: Built={Built}";
        }
    }

    public class Roof : IPart
    {
        public string? Name { get; set; }
        public bool Built { get; set; }

        public Roof(bool built, string? name)
        {
            Built = built;
            Name = name;
        }

        public Roof() { Built = false; }

        public void BuildThis()
        {
            Built = true;
        }

        public override string ToString()
        {
            return $"Roof - {Name}: Built={Built}";
        }
    }

    public class House
    {
        public Dictionary<IPart, IWorker>? Plan { get; set; }

        public House(Dictionary<IPart, IWorker>? plan)
        {
            Plan = plan;
        }

        public House() { }

        public override string ToString()
        {
            if (Plan == null || Plan.Count == 0)
            {
                return "Empty House Plan";
            }

            return "House Plan:\n" + string.Join("\n", Plan.Select(kv => kv.Key.ToString()));
        }
    }

    public class Worker : IWorker
    {
        public string? Name { get; set; }
        public string? SecondName { get; set; }

        public Worker(string? name, string? secondName)
        {
            Name = name;
            SecondName = secondName;
        }

        public void Work(Dictionary<IPart, IWorker>? plan)
        {
            if (plan != null && plan.Count > 0)
            {
                foreach (var kvp in plan)
                {
                    IPart part = kvp.Key;
                    part.BuildThis();
                }
                IPart firstPart = plan.Keys.FirstOrDefault();
                if (firstPart != null)
                {
                    plan[firstPart] = this;
                }
            }
        }

        public override string ToString()
        {
            return $"Worker - {Name} {SecondName}";
        }
    }

    public class TeamLeader : IWorker
    {
        public string? Name { get; set; }
        public string? SecondName { get; set; }

        public TeamLeader(string? name, string? secondName)
        {
            Name = name;
            SecondName = secondName;
        }

        public void Work(Dictionary<IPart, IWorker> plan)
        {
            Console.WriteLine("Team Leader's Plan:");

            foreach (var kvp in plan)
            {
                IPart part = kvp.Key;
                IWorker worker = kvp.Value;

                Console.WriteLine($"{part} (Built by {worker})");
            }
        }

        public override string ToString()
        {
            return $"TeamLeader - {Name} {SecondName}";
        }
    }
}
