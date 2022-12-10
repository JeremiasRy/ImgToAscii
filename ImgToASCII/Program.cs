using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Microsoft.VisualBasic.FileIO;

if (!OperatingSystem.IsWindows())
{
    return;
}
string imgPath = @"C:\Users\35844\source\repos\ImgToASCII\untamo.png";
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
List<string> grayScale = new();
float grayScaleMultiplier = (float)(ASCIIGrayScale.Length - 1) / 255;
float heightToWidthRatio = (float)img.Height / (float)img.Width;

for (int i = 0; i < img.Height; i++)
{
    string line = "";
    int count = 0;
    for(int j = 0; j < img.Width; j++)
    {
        if (count % 2 == 0)
        {
            var pixel = img.GetPixel(j, i);
            int index = (int)Math.Round(grayScaleMultiplier * (float)((pixel.R + pixel.G + pixel.B) / 3));
            line += ASCIIGrayScale[(int)index];
        }
        count++;
        
    }
    grayScale.Add(line);
}

if (!File.Exists(@"C:\testdata\ASCIIpic.txt"))
{
    using (StreamWriter sw = File.CreateText(@"C:\testdata\ASCIIpic.txt"))
    {
        int count = 0;
        foreach (var line in grayScale)
        {
            if (count % 6 == 0)
            {
                sw.WriteLine(line);
            }
            count++;
        }
    }
} else
{
    using (StreamWriter sw = new(@"C:\testdata\ASCIIpic.txt"))
    {
        int count = 0;
        foreach (var line in grayScale)
        {
            if (count % 6 == 0)
            {
                sw.WriteLine(line);
            }
            count++;

        }
    }
}




