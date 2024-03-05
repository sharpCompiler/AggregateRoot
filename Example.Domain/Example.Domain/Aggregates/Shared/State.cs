public class State
{
	public State(string stateInitials)
	{
		if(string.IsNullOrEmpty(stateInitials))
			throw new ArgumentNullException(nameof(stateInitials));

		if (stateInitials.Length != 2)
			throw new ArgumentException("State initials must be only two characters");

		StateInitials = stateInitials;
	}

	public string StateInitials { get; }

	public static implicit operator string(State source)
	{
		return source?.StateInitials ?? string.Empty;
	}

	public static implicit operator State(string stateInitials)
	{
		return new State(stateInitials);
	}
}
