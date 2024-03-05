using Example.Domain.Aggregates.Shared;

public class Customer : IAggregateRoot
{
	public Guid Id { get; private set; }
	public string Name { get; private set; }

	public Address? Address { get; private set; }

	public Customer(string name)
	{
		Name = name;
	}

	public void UpdateAddress(Address address)
	{
		Address = address;
	}

}