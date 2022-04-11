namespace DemoApp.BusinessLogic
{
    public class Device
    {
        // Fields
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Type { get; set; }
        public int OS { get; set; }

        // Constructors
        public Device() { }

        public Device(int ID, string Name, int Type, int OS)
        {
            this.ID = ID;
            this.Name = Name;
            this.Type = Type;
            this.OS = OS;
        }

        // Methods
    }
}