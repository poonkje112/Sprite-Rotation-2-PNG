using System.Drawing;
using System.Drawing.Imaging;

namespace sr2png;

public class RotationGenerator
{
	/// <summary>
	/// Creates a sprite sheet for rotating a texture.
	/// </summary>
	/// <param name="srcPNG"></param>
	/// <param name="outputPNG"></param>
	public static void GenerateRotationSheet(string srcPNG, string outputPNG, int maxDegrees)
	{
		// Load the source image
		Bitmap src = new Bitmap(srcPNG);
		
		// Create the output image
		Bitmap output = new Bitmap(src.Width * maxDegrees, src.Height);
		
		// Copy and rotate the source image into the output image until we reach the max rotation degrees
		for (int i = 0; i < maxDegrees; i++)
		{
			// Rotate the source image by i degrees
			Bitmap rotated = RotateImage(src, i);
			
			// Copy the rotated image into the output image at width * i
			Graphics g = Graphics.FromImage(output);
			g.DrawImage(rotated, src.Width * i, 0);
			g.Dispose();
			
			// Clean up
			rotated.Dispose();
		}
		
		// Save the output image
		output.Save(outputPNG, ImageFormat.Png);
		
		// Clean up
		src.Dispose();
		output.Dispose();
	}

	private static Bitmap RotateImage(Bitmap src, int i)
	{
		// Create a new bitmap to hold the rotated image
		Bitmap rotated = new Bitmap(src.Width, src.Height);
		
		// Create a graphics object to do the rotation
		Graphics g = Graphics.FromImage(rotated);
		
		// Set the rotation point to the center of the image
		g.TranslateTransform((float)src.Width / 2, (float)src.Height / 2);
		
		// Rotate the image
		g.RotateTransform(i);
		
		// Draw the image onto the graphics object
		g.DrawImage(src, -src.Width / 2, -src.Height / 2);
		
		return rotated;
	}
}