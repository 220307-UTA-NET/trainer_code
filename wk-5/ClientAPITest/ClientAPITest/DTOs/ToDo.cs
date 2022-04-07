namespace ClientAPITest.DTOs
{
    // DTOs  (Data Transfer Objects) 
    // aren't meant to model a behavior
    // just the values of an object


    //When we start to use a client application to communicate with a server,
    // the Server cannot use Console.Read or Console.Write, so all User Interaction 
    // must come through the Console Application (the client application).

    public class ToDo
    {
        // Fields
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }
}
