namespace TRY.Models
{
public class TrainBooking
{
    public int id { get; set; }
    public int user_id { get; set; }
    public bool loyalty { get; set; }
    public int train_id { get; set; }
    public decimal final_price { get; set; }
        public string? date { get; set; }
    public TrainBooking()

        {

        }
}
}