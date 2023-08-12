namespace app.console.Entity;
internal class MyTask{
    public int Id { get; set;}
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public DateTime? FinalDate { get; set; }
    public bool Status { get; set; }

    override public string ToString()
    {
        return $"=== My Task ===\n"+
               $" ID :{this.Id}\n"+
               $" Date: {this.Date}\n"+
               $" Final Date{this.FinalDate}\n"+
               $" Description: {this.Description}\n"+
               $" Status: {(this.Status==true? "Open":"Closed")}\n";
    }
}
