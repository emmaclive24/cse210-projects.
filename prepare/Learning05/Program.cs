static void Main(string[] args)
{
    List<Shape> shapes = new List<Shape>();

    Square square = new Square("Red", 5);
    shapes.Add(square);

    Rectangle rectangle = new Rectangle("Blue", 4, 6);
    shapes.Add(rectangle);

    Circle circle = new Circle("Green", 3);
    shapes.Add(circle);

    foreach (Shape shape in shapes)
    {
        Console.WriteLine($"Color: {shape.Color}");
        Console.WriteLine($"Area: {shape.GetArea()}");
        Console.WriteLine();
    }
}
