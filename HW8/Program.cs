IPart basement = new Basement();
List<IPart> walls = new List<IPart> { new Wall(), new Wall(), new Wall(), new Wall() };
IPart door = new Door();
List<IPart> windows = new List<IPart> { new Window(), new Window(), new Window(), new Window() };
IPart roof = new Roof();

IWorker worker1 = new Worker("John");
IWorker worker2 = new Worker("Jane");
TeamLeader teamLeader = new TeamLeader("Tom");

Team constructionTeam = new Team(new List<IWorker> { worker1, worker2, teamLeader });

List<IPart> constructionPlan = new List<IPart>
        {
            basement,
            walls[0], walls[1], walls[2], walls[3],
            door,
            windows[0], windows[1], windows[2], windows[3],
            roof
        };

constructionTeam.BuildHouse(constructionPlan, teamLeader);