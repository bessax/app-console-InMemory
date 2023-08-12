using app.console.Data;
using app.console.Entity;

Console.WriteLine("=== Project MyTask ===");
char? op='s';
do
{
    try
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("Select an option");
        Console.WriteLine("1 - Add a task");
        Console.WriteLine("2 -List tasks ");
        Console.WriteLine("3 -Exit ");
        op= Console.ReadLine()![0];
        switch(op)
        {
            case '1': CreateTask();
            break;
            case '2': LisTTask();
            break;
            case '3': Console.WriteLine("Closing program...");
            Console.WriteLine("Press any key for exit...");
            Console.ReadKey();
            break;
            default:Console.WriteLine("Option not implemented in the menu");
            break;
        }
    }
    catch (Exception exception)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"An exception happened: {exception.Message}");
       
    }
    finally{
         Console.ForegroundColor = ConsoleColor.White;
    }
    
   

} while(!op.Equals('3'));

static void LisTTask()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("===List task===");
     var appDbContext = new AppDbContext();
    List<MyTask> _list = appDbContext.Tasks!.ToList();   
    if (_list.Count==0)
    {
        Console.WriteLine("Query did not return data.");
        Console.WriteLine("\n"); 
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
        return;
    }
    foreach (var item in _list)
    {
        Console.WriteLine(item.ToString());
    }
   
    Console.WriteLine("Press any key to return to the menu...");
    Console.ReadKey();
}

static void CreateTask()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("===Register task===");
    var rd = new Random();
    var task = new MyTask();
    task.Id= rd.Next(1,999);
    task.Date = DateTime.Now;
    task.FinalDate=null;
    task.Status=true;
    Console.WriteLine($"Task ID: {task.Id}");
    Console.WriteLine($"Task Creation date: {task.Date}");
    Console.Write("Enter a description: ");
    task.Description = Console.ReadLine();

    var appDbContext = new AppDbContext();
    appDbContext.Tasks!.Add(task);
    appDbContext.SaveChanges();

    Console.WriteLine("\n");   
   
    Console.WriteLine("Press any key to return to the menu...");
    Console.ReadKey();
}