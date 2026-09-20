namespace IT_ELECTIVE_2_MIDTERM_PORTFOLIO_Billena_Dominic.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string Name { get; set; } = "";

        public string Message { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}