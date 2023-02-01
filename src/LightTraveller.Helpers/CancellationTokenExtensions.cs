namespace LightTraveller.Helpers;

public static class CancellationTokenExtensions
{
    public static void CheckThrow(this CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();
    }
}
