using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Microsoft.VisualBasic.FileIO;

if (!OperatingSystem.IsWindows())
{
    return;
}
string imgPath = @"C:\Users\35844\source\repos\ImgToASCII\testpic2.jpeg";
string grayScalePath = @"C:\Users\35844\source\repos\ImgToASCII\grayscale.txt";
char[] ASCIIGrayScale = Array.Empty<char>();

using (TextFieldParser tp = new(grayScalePath))
{
    while (!tp.EndOfData)
    {
        string? line = tp.ReadLine();
        if (line != null)
            ASCIIGrayScale = line.ToCharArray();
    }
}

Bitmap img = (Bitmap)Bitmap.FromFile(imgPath);
List<int> grayScale = new();

for (int i = 0; i < img.Width; i++)
{
    for(int j = 0; j < img.Height; j++)
    {
        var pixel = img.GetPixel(i, j);
        grayScale.Add((pixel.R + pixel.G + pixel.B) / 3);
    }
}




