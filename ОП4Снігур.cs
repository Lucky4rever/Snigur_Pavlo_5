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

        var algebra = new Algebra();
        algebra.AddGeometricFigure(square);
        algebra.AddGeometricFigure(circle);
        algebra.AddGeometricFigure(line);

        var square2 = new Square(10, Color.Aqua);
        var square3 = new Square(1, Color.Aqua);
        algebra.AddGeometricFigure(square2);
        algebra.AddGeometricFigure(square3);

        Console.WriteLine($"Сумарна площа квадратiв: {algebra.GetOverallAreaByType("Квадрат")} кв од.");
    }
}

public class Algebra
{
    public List<GeometricFigure> GeometricFigures { get; set; }

    public Algebra()
    {
        GeometricFigures = new List<GeometricFigure>();
    }

    public double GetOverallAreaByType(string type)
    {
        return GeometricFigures
            .Where(gf => gf.Type == type)
            .Select(gf => gf.GetArea())
            .Sum();
    }

    public void AddGeometricFigure(GeometricFigure geometricFigure)
    {
        GeometricFigures.Add(geometricFigure);
        Console.WriteLine($"Додано фiгуру {geometricFigure}.");
    }
}

public abstract class GeometricFigure
{
    public string Type { get; set; }
    public Color Color { get; set; }
    public abstract double GetArea();
    public GeometricFigure(Color color)
    {
        Color = color;
    }
}

public class Square : GeometricFigure
{
    public double LinesLength { get; set; }
    
    public override double GetArea() => Math.Pow(LinesLength, 2);
    
    public Square(double linesLength, Color color) : base(color)
    {
        Type = "Квадрат";
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

    public override double GetArea() => Math.PI * Math.Pow(R, 2);
    
    public Circle(double radius, Color color) : base(color)
    {
        Type = "Коло";
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
    public override double GetArea() => Length;

    public Line(double length, Color color) : base(color)
    {
        Type = "Пряма";
        Length = length;
    }
    
    
    public override string ToString()
    {
        return $"Лiнiя, довжина {Length} од. Колiр {Color.Name}";
    }
}