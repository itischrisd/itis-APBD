namespace KolokwiumCF.Models;

public class Sale
{
    public int IdSale { get; set; }
    public int IdClient { get; set; }
    public int IdSubscription { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual Client IdClientNav { get; set; } = null!;
    public virtual Subscription IdSubscriptionNav { get; set; } = null!;
}