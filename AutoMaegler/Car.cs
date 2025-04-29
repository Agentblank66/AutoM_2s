namespace AutoMaegler
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Car() { }
            
        public Car(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
