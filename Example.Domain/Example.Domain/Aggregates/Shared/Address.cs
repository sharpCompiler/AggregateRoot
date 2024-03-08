public record Address

{
	public Address(string street, string city, State state, string zipCode)
	{
		if (string.IsNullOrWhiteSpace(street))
			throw new ArgumentNullException($"{nameof(street)} can not be null");

		if (string.IsNullOrWhiteSpace(city))
			throw new ArgumentNullException($"{nameof(city)} can not be null");

		if (string.IsNullOrWhiteSpace(state))
			throw new ArgumentNullException($"{nameof(state)} can not be null");

		if (string.IsNullOrWhiteSpace(zipCode))
			throw new ArgumentNullException($"{nameof(zipCode)} can not be null");

		Street = street;
		City = city;
		State = state;
		ZipCode = zipCode;
	}

	public string Street { get; }
	public string City { get; }
	public State State { get; }
	public string ZipCode { get; }
}