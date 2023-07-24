namespace TRY.Models
{
    public class train_details
    {
        public int id { get; set; }
        public string? train_name { get; set; }
        public string? _from { get; set; }
        public string? _to { get; set; }
        public string? time01 { get; set; }
        public string? time02 { get; set; }
        public decimal price { get; set; }

        public train_details()

        {

        }
    }
}
