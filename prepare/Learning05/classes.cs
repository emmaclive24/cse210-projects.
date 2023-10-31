public abstract class Shape
{
    public string Color { get; set; }

    public Shape(string color)
    {
        Color = color;
    }

    public abstract double GetArea();
}

public class Square : Shape
{
    private double Side { get; set; }

    public Square(string color, double side) : base(color)
    {
        Side = side;
    }

    public override double GetArea()
    {
        return Side * Side;
    }
}

public class Rectangle : Shape
{
    private double Length { get; set; }
    private double Width { get; set; }

    public Rectangle(string color, double length, double width) : base(color)
    {
        Length = length;
        Width = width;
    }

    public override double GetArea()
    {
        return Length * Width;
    }
}

public class Circle : Shape
{
    private double Radius { get; set; }

    public Circle(string color, double radius) : base(color)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}
