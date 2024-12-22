﻿using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Aylana ma'lumotlari (x, y, r):
        List<Circle> circles = new List<Circle>
        {
            new Circle(0, 0, 5),
            new Circle(3, 0, 4),
            new Circle(10, 0, 2),
            new Circle(15, 5, 3)
        };

        // a) Uchta kesishuvchi aylana bormi?
        bool threeIntersecting = CheckThreeIntersectingCircles(circles);
        Console.WriteLine($"Uchta kesishuvchi aylana mavjudmi? {threeIntersecting}");


    }

    // Aylana sinfi
    public class Circle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }

        public Circle(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public bool Intersects(Circle other)
        {
            double distance = Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
            return distance < (Radius + other.Radius) && distance > Math.Abs(Radius - other.Radius);
        }
    }

    // a) Uchta kesishuvchi aylana mavjudligini tekshirish
    static bool CheckThreeIntersectingCircles(List<Circle> circles)
    {
        for (int i = 0; i < circles.Count; i++)
        {
            for (int j = i + 1; j < circles.Count; j++)
            {
                for (int k = j + 1; k < circles.Count; k++)
                {
                    if (circles[i].Intersects(circles[j]) && circles[j].Intersects(circles[k]) && circles[k].Intersects(circles[i]))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}