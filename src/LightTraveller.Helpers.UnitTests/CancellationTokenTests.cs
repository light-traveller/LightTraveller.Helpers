namespace LightTraveller.Helpers.UnitTests;

public class CancellationTokenTests
{
    [Fact]
    public async void WhenCancelled_CheckThrow_Should_Throw()
    {
        var cts = new CancellationTokenSource();
        cts.Cancel();
        await Assert.ThrowsAsync<OperationCanceledException>(async () => await LongRunningProcess(cts.Token));

        static Task LongRunningProcess(CancellationToken cancellationToken = default)
        {
            for (var i =0; i < 3_000; i++)
            {
                cancellationToken.CheckThrow();
                Task.Delay(10, CancellationToken.None);
            }

            return Task.CompletedTask;
        }
    }
}
