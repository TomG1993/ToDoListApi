namespace ToDoListApi.Models
{
    public class ToDoRecord
    {
        public ToDoRecord()
        {
            ID = Guid.NewGuid();    
        }
        public Guid ID { get; set; }
        public string Description { get; set; }

        public int Status { get; set; }
    }
}
