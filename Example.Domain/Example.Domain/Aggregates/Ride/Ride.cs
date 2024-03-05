using Example.Domain.Aggregates.Shared;

namespace Example.Domain.Aggregates.Ride
{
    public class Ride : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid DriverId { get; private set; }
        public Address PickUpLocation { get; private set; }
        public Address DropoffLocation { get; private set; }
        public DateTime? CustomerPickedUpTime { get; private set; }
        public DateTime? CustomerDroppedOffTime { get; private set; }
        public bool IsCancelled { get; private set; }

        public Ride(Guid customerId, Guid driverId, Address pickUpLocation, Address dropoffLocation)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            DriverId = driverId;
			PickUpLocation = pickUpLocation;
			DropoffLocation = dropoffLocation;
            IsCancelled = false;
        }

        public void CancelRide()
        {
            if (IsCancelled)
                throw new InvalidOperationException("Ride is already canceled.");

            if (CustomerPickedUpTime.HasValue)
                throw new InvalidOperationException("Ride has already started and can not be picked up.");

			if (CustomerDroppedOffTime.HasValue)
				throw new InvalidOperationException("Ride is complete and therefore can not be canceled.");

			IsCancelled = true;
        }

		public void PicedUpCustomer()
		{
			if (CustomerPickedUpTime.HasValue)
				throw new InvalidOperationException("Customer already picked up.");

			if (IsCancelled)
				throw new InvalidOperationException("Ride is canceled and customer will not be picked up.");

			CustomerPickedUpTime = DateTime.Now;
		}

		public void DroppedOffCustomer()
        {
            if (CustomerDroppedOffTime.HasValue)
                throw new InvalidOperationException("Customer has already been dropped off.");
            if (IsCancelled)
                throw new InvalidOperationException("Ride is canceled and cannot be ended.");

			CustomerDroppedOffTime = DateTime.Now;
        }
    }

}

