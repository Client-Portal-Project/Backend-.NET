namespace Models
{
  public class PaymentIntentCreateRequest  {
    public Occupation[] ?OccupationsToBuy { get; set; }

    // Please remove, this is only temporary
    public long Price { get; set; }
  }
}