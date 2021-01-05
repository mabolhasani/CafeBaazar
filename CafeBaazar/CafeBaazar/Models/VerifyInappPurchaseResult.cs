namespace CafeBaazar.Models
{
    public class VerifyInappPurchaseResult
    {
        public bool Successful { get; }

        public ErrorResult Error { get; }

        public InappPurchaseResult PurchaseResult { get; }

        public VerifyInappPurchaseResult(InappPurchaseResult result)
        {
            Successful = true;
            Error = default;
            PurchaseResult = result;
        }

        public VerifyInappPurchaseResult(ErrorResult error = default)
        {
            Successful = false;
            Error = error;
            PurchaseResult = default;
        }
    }
}
