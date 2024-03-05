using Example.Domain.Aggregates.Shared;

namespace Example.Domain.Aggregates.Driver
{

    public class Driver : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Shift? ActiveShift { get; private set; }
        public List<Car> Cars { get; private set; } = new List<Car>();


        public Driver(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void StartShift(string carPlates, string workingState)
        {
            if (!Cars.Any(x => x.Plates == carPlates))
                throw new InvalidOperationException("Car is not associated with this driver.");

            if (ActiveShift != null)
                throw new InvalidOperationException("Driver is already on shift.");

            ActiveShift = new Shift(DateTime.Now, workingState);
        }

        public void EndShift()
        {
            if (ActiveShift == null)
                throw new InvalidOperationException("There is no active shift");

            if (ActiveShift.IsOnBreak)
                throw new InvalidOperationException("Driver is on break. End break first");

            ActiveShift = null;
        }


        public void AddCar(Car car)
        {
            if (car == null) 
                throw new ArgumentNullException(nameof(car));

            if(Cars.Any(x => x.Plates == car.Plates))
				throw new InvalidOperationException("Car already associated with driver");


			Cars.Add(car);
        }

        public void RemoveCar(string carPlates)
        {
			if (string.IsNullOrEmpty(carPlates))
				throw new ArgumentNullException(nameof(carPlates));

            var car = Cars.FirstOrDefault(x => x.Plates == carPlates);
            if (car == null)
				throw new InvalidOperationException("This car is not associated with driver");

            Cars.Remove(car);

		}
	}

}
