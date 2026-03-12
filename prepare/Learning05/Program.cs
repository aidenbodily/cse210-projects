using System;

class Program
{
    static void Main(string[] args)
    {
        // polymorphism: same loop, different GetArea() for each shape type
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("red", 5));
        shapes.Add(new Rectangle("blue", 4, 6));
        shapes.Add(new Circle("green", 3));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine("Color: " + shape.GetColor() + ", Area: " + shape.GetArea());
        }
    }
}