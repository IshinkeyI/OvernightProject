public class Enums
{
	public enum Axes
	{
		X
	}

	public enum MovementType
	{
		AllDirections = 0,
		OnlyHorizontal,
		OnlyVertical
	}

	public enum Directions
	{
		Up,
		Right,
		Down,
		Left,
	}

	public enum Targets
	{
		None,
		ObjectThatCollided,
	}
}
