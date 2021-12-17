namespace REST.Models
{
  public class PaymentIntentCreateRequest  {
    public Occupation[] OccupationsToBuy { get; set; }

    // TODO: Please remove, this is only temporary
    public long Price { get; set; }
  }
}