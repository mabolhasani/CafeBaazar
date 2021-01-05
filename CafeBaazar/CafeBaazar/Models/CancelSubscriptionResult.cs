namespace CafeBaazar.Models
{
    public class CancelSubscriptionResult
    {
        public bool Successful { get; }

        public ErrorResult Error { get; }

        public CancelSubscriptionResult()
        {
            Successful = true;
            Error = default;
        }

        public CancelSubscriptionResult(ErrorResult error = default)
        {
            Successful = false;
            Error = error;
        }
    }
}
