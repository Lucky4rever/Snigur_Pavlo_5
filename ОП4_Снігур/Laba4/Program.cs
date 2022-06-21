using System.Drawing;

namespace Laba4;

public static class Program
{
    public static void Main()
    {
        var square = new Square(5, Color.Aqua);
        Console.WriteLine(square);
        Console.WriteLine(square.LinesLength);
        Console.WriteLine(square.GetArea());

        var circle = new Circle(7, Color.Coral);
        Console.WriteLine(circle);
        Console.WriteLine(circle.R);
        Console.WriteLine(circle.GetArea());

        var line = new Line(10, Color.Plum);
        Console.WriteLine(line);
        Console.WriteLine(line.Length);
    }
}

public abstract class GeometricFigure
{
    public Color Color { get; set; }
    
    public GeometricFigure(Color color)
    {
        Color = color;
    }
}

public class Square : GeometricFigure
{
    public double LinesLength { get; set; }
    
    public double GetArea() => Math.Pow(LinesLength, 2);
    
    public Square(double linesLength, Color color) : base(color)
    {
        LinesLength = linesLength;
    }

    public override string ToString()
    {
        return $"Квадрат, площа {GetArea()} кв. од. Колiр {Color.Name}";
    }
}

public class Circle : GeometricFigure
{
    public double R { get; set; }

    public double GetArea() => Math.PI * Math.Pow(R, 2);
    
    public Circle(double radius, Color color) : base(color)
    {
        R = radius;
    }

    public override string ToString()
    {
        return $"Круг, площа {GetArea()} кв. од. Колiр {Color.Name}";
    }
}

public class Line : GeometricFigure
{
    public double Length { get; set; }
    
    public Line(double length, Color color) : base(color)
    {
        Length = length;
    }
    
    
    public override string ToString()
    {
        return $"Лiнiя, довжина {Length} од. Колiр {Color.Name}";
    }
}