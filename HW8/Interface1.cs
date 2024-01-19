using System;
using System.Collections.Generic;

public interface IPart
{
    void Build();
    bool IsBuilt { get; }
}

public interface IWorker
{
    string Name { get; }
    void Work(IPart part);
}

public class Basement : IPart
{
    public bool IsBuilt { get; private set; }

    public void Build()
    {
        Console.WriteLine("Building the basement");
        IsBuilt = true;
    }
}

public class Wall : IPart
{
    public bool IsBuilt { get; private set; }

    public void Build()
    {
        Console.WriteLine("Building a wall");
        IsBuilt = true;
    }
}

public class Door : IPart
{
    public bool IsBuilt { get; private set; }

    public void Build()
    {
        Console.WriteLine("Installing the door");
        IsBuilt = true;
    }
}

public class Window : IPart
{
    public bool IsBuilt { get; private set; }

    public void Build()
    {
        Console.WriteLine("Installing a window");
        IsBuilt = true;
    }
}

public class Roof : IPart
{
    public bool IsBuilt { get; private set; }

    public void Build()
    {
        Console.WriteLine("Building the roof");
        IsBuilt = true;
    }
}

public class Worker : IWorker
{
    public string Name { get; }

    public Worker(string name)
    {
        Name = name;
    }

    public void Work(IPart part)
    {
        if (!part.IsBuilt)
        {
            part.Build();
            Console.WriteLine($"{Name} built {part.GetType().Name}");
        }
        else
        {
            Console.WriteLine($"{Name} found {part.GetType().Name} already built");
        }
    }
}

public class TeamLeader : IWorker
{
    public string Name { get; }

    public TeamLeader(string name)
    {
        Name = name;
    }

    public void Work(IPart part)
    {
        Console.WriteLine($"{Name} supervising the construction");
    }

    public void Report(List<IPart> parts)
    {
        Console.WriteLine($"Team Leader's Report:");
        foreach (var part in parts)
        {
            Console.WriteLine($"{part.GetType().Name}: {(part.IsBuilt ? "Built" : "Not built")}");
        }
    }
}

public class Team
{
    private List<IWorker> workers;

    public Team(List<IWorker> workers)
    {
        this.workers = workers;
    }

    public void BuildHouse(List<IPart> parts, TeamLeader teamLeader)
    {
        foreach (var part in parts)
        {
            IWorker currentWorker = workers[new Random().Next(workers.Count)];
            currentWorker.Work(part);
        }

        teamLeader.Report(parts);
    }
}
