namespace FileInteraction
{
    class Person
    {
        // fields - variables that are part of each instance of a class object.
        public string name;
        public double height;
        public int age;

        // Constructor - a method used to intialize instances of the class
        public Person( string PersonName = "Default", double PersonHeight = 40.0, int PersonAge = 21 )
        {
            this.name = PersonName;
            this.height = PersonHeight;
            this.age = PersonAge;
        }

        // public Person( string PersonName, double PersonHeight)
        // {
        //     this.name = PersonName;
        //     this.height = PersonHeight;
        //     this.age = 40;
        // }

        // public Person( string PersonName, int PersonAge)
        // {
        //     this.name = PersonName;
        //     this.height = 45.5;
        //     this.age = PersonAge;
        // }

        // public Person( double PersonHeight, int PersonAge)
        // {
        //     this.name = "default";
        //     this.height = PersonHeight;
        //     this.age = PersonAge;

        // }

        public void GrowUp()
        {
            this.age++;
        }

        public void Shrink()
        {
            this.height--;
        }
    }
}