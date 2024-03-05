using Example.Domain.Aggregates.Shared;

namespace Example.Domain.Aggregates.Ride
{
    public class Ride : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid DriverId { get; private set; }
        public Address From { get; private set; }
        public Address To { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
        public bool IsCancelled { get; private set; }

        public Ride(Guid customerId, Guid driverId, DateTime startTime, Address From, Address To)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            DriverId = driverId;
            StartTime = startTime;
            this.From = From;
            this.To = To;
            IsCancelled = false;
        }

        public void CancelRide()
        {
            if (IsCancelled)
                throw new InvalidOperationException("Ride is already canceled.");
            if (EndTime.HasValue)
                throw new InvalidOperationException("Ride has already ended.");

            IsCancelled = true;
        }

        public void EndRide()
        {
            if (EndTime.HasValue)
                throw new InvalidOperationException("Ride has already ended.");
            if (IsCancelled)
                throw new InvalidOperationException("Ride is canceled and cannot be ended.");

            EndTime = DateTime.UtcNow;
        }
    }

}

