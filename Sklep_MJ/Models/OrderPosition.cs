namespace Sklep_MJ.Models
{
    public class OrderPosition
    {
        public int OrderPositionId { get; set; }
        public int OrderId { get; set; }
        public int CourseId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

        public virtual Course course { get; set; }
        public virtual Order order { get; set; }

    }
}