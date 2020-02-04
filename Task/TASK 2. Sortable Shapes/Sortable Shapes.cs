using System;

namespace TASK_2._Sortable_Shapes
{
    public class Shape : IComparable<Shape>
    {
        public double Area { get; set; }

        public int CompareTo(Shape other)
        {
            return this.Area.CompareTo(other.Area);
        }

    }

    public class Square : Shape
    {
        public Square(double side)
        {
            Area = side * side;
        }
    }

    public class CustomShape : Shape
    {
        public CustomShape(double area)
        {
            Area = area;
        }
    }

    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Area = (radius * radius) * Math.PI;
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            Area = width * height;
        }
    }

    public class Triangle : Shape
    {
        public Triangle(double Base, double height)
        {
            Area = (Base * height) / 2;
        }
    }
}
