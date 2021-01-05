namespace CafeBaazar.Models
{
    public class VerifySubscriptionPurchaseResult
    {
        public bool Successful { get; }

        public ErrorResult Error { get; }

        public SubscriptionPurchaseResult PurchaseResult { get; }

        public VerifySubscriptionPurchaseResult(SubscriptionPurchaseResult result)
        {
            Successful = true;
            Error = default;
            PurchaseResult = result;
        }

        public VerifySubscriptionPurchaseResult(ErrorResult error = default)
        {
            Successful = false;
            Error = error;
            PurchaseResult = default;
        }
    }
}
