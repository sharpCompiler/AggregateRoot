namespace Example.Domain.Aggregates.Driver
{
    public class Car //Entity
    {
        public Guid Id { get; private set; }
        public string Plates { get; private set; }

		public Car( Guid id, string plates)
		{
			Plates = plates;
			Id = id;
		}
	}

}
