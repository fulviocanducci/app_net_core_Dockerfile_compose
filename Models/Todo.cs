namespace app_net_docker.Models
{
    public class Todo
    {
        public Todo()
        {
        }

        public Todo(string description)
        {
            Description = description;
        }

        public Todo(int id, string description)
        {
            Id = id;
            Description = description;
        }
        public int Id { get; set; }
        public string Description { get; set; }
    }
}