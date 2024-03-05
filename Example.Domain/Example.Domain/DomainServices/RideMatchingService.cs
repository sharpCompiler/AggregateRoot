using Example.Domain.Aggregates.Driver;
using Example.Domain.Aggregates.Ride;

public class RideMatchingService
{
	public Ride CreateRide(Customer customer, Driver driver, Address pickupLocation, Address dropoffLocation)
	{
		if(driver.ActiveShift == null)
			throw new InvalidOperationException("Driver has no Active shift");

		if (pickupLocation.State != driver.ActiveShift.WorkingState)
			throw new InvalidOperationException("Driver and customer must be in the same state");

		var ride = new Ride(customer.Id, driver.Id, DateTime.Now, pickupLocation, dropoffLocation);
		return ride;
	}
}
