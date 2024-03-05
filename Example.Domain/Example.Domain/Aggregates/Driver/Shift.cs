namespace Example.Domain.Aggregates.Driver
{
    public class Shift
    {
        public DateTime Start { get; }

        public State WorkingState { get; }

        public bool IsOnBreak { get; private set; }


        public Shift(DateTime start, State workingState)
        {
            Start = start;
            WorkingState = workingState;
        }


        public void GoOnBreak()
        {
            if (IsOnBreak)
                throw new InvalidOperationException("Driver is already on break.");

            IsOnBreak = true;
        }

        public void EndBreak()
        {
            if (!IsOnBreak)
                throw new InvalidOperationException("Driver is not on break.");

            IsOnBreak = false;
        }

    }

}
