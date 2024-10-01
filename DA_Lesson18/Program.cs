using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
//add workers
var developer1 = new Developer ("Ivan", "DEV", DateTime.Parse("27-09-2022"),1234.5m, "java");
var developer2 = new Developer("Ivan", "DEV123", DateTime.Parse("01-01-2020"), 5000.0m, "C#");
var developer3 = new Developer("Bob", "DEV", DateTime.Parse("01-12-2019"), 7000.0m, "java");
var qatester1 = new QAtester("Marta", "QA", DateTime.Parse("05-12-2019"), 700.0m, true);
var qatester2 = new QAtester("Oleg", "QA", DateTime.Parse("05-09-2024"), 3200.0m, false);

//Create list of all workers
List<Worker> workers = new List<Worker>
{
developer1, developer2, developer3, qatester1, qatester2
};

bool running = true;


while (running)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Show names and position of all available workers");
    Console.WriteLine("2. Show presentation of all workers");
    Console.WriteLine("3. Find and display worker by name");
    Console.WriteLine("4. Exit");
    Console.Write("\nChoose an option: ");

    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine($"The list of workers:");
            foreach (var worker in workers)
            {
                worker.Print();
            }
            break;
        case "2":
            foreach (var worker in workers)
            {
                worker.PresentYourself();
            }
            break;
        case "3":
            {
                Console.Write("Enter the worker's ID: ");
                var workerID = int.Parse (Console.ReadLine());
                var selectedWorker = workers.Find(w => w.id == workerID);
                if (selectedWorker != null)
                {
                    Console.WriteLine($"Worker found: {selectedWorker.name} - {selectedWorker.position}");
                }
                else
                {
                    Console.WriteLine("Worker not found.");
                }
                break;

            }
            break;
        case "4":
            running = false;
            Console.WriteLine("Exiting program.");
            break;
    }
}


abstract class Worker
{
    private static int idCounter = 1; // Counter 
    public int id { get; private set; } // Unique ID for each worker
    public string name { get; set; }
    public string position { get; set; }
    public DateTime startOfEmployment { get; set; }
    public decimal salary { get; set; }

    public Worker(string name, string position, DateTime startOfEmployment, decimal salary)
    {
        this.id = idCounter++; // Assign a unique ID and increment the counter
        this.name = name;
        this.position = position;
        this.startOfEmployment = startOfEmployment;
        this.salary = salary;
    }

    public virtual void Print()
    {
        Console.WriteLine($"- ID: {id}, Name: {name}, Position: {position}, Salary: {salary}");
    }
    public void PresentYourself()
    {
        Console.WriteLine($"My name is {name}. I have the next position: {position}");
    }
}

class Developer : Worker
{
    public string language { get; set; }
    public Developer (string name, string position, DateTime startOfEmployment, decimal salary, string language)
        : base (name, position, startOfEmployment, salary)
    {  
        this.language = language; 
    }
    public override void Print()
    {
        Console.WriteLine($"- ID: {id}, Name: {name}, Position: {position}, Salary: {salary},Language: {language}");
    }
}

class QAtester : Worker
{
    public bool isAutomation { get; set; }
    public QAtester(string name, string position, DateTime startOfEmployment, decimal salary, bool isAutomation)
        : base(name, position, startOfEmployment, salary)
    {
        this.isAutomation = isAutomation;
    }
}
