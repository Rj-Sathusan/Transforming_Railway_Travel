namespace TRY.Models
{
public class TrainBooking
{
    public int id { get; set; }
    public int user_id { get; set; }
    public bool? loyalty { get; set; }

    public string? time  { get; set; }
    public int train_id { get; set; }
    public decimal final_price { get; set; }
        public string? date { get; set; }
         public string?  Name { get; set; }
          public string?  train_name { get; set; }
          public string?  _from { get; set; }
           public string?  _to { get; set; }
        
                public user User { get; set; } // Add this navigation property

                public train_details train_details { get; set; } // Add this navigation property

        public TrainBooking()

        {

        }
}
}