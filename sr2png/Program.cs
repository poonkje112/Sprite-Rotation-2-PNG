using sr2png;

class Program
{
	public static void Main(string[] args)
	{
		// Get the source path
		string targetSprite = args[0];

		// Get the target path
		string outputSprite = args[1];

		// Get the rotation
		int rotation = int.Parse(args[2]);

		RotationGenerator.GenerateRotationSheet(targetSprite, outputSprite, rotation);
	}
}