namespace TRY.Models
{
    public class BookingDetails
    {
        public int BookingId { get; set; }
        public int Id { get; set; } // This is the same as the BookingId
        public string UserName { get; set; }
        public string TrainName { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public double FinalPrice	 { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int UserId { get; set; }
        public int TrainId { get; set; }

         public BookingDetails()

        {

        }
    }
}


       
