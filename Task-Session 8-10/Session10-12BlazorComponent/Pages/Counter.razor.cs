namespace Session10Blazor.Pages
{
    public partial class Counter
    {

        private void IncrementCount()
        {
            CounterState.Count++;
        }
    }

    public class CounterState
    {
        public int Count { get; set; }
    }
}