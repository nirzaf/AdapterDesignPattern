using System;
using System.Collections.Generic;
using MoreLinq.Extensions;

namespace AdapterDesignPattern;

public class Demo
{
    private static readonly List<VectorObject> vectorObjects = new()
    {
        new VectorRectangle(1, 1, 10, 10),
        new VectorRectangle(3, 3, 6, 6)
    };

    // the interface we have
    public static void DrawPoint(Point p)
    {
        Console.Write(".");
    }

    private static void Main()
    {
        Draw();
        Draw();
    }

    private static void Draw()
    {
        foreach (var vo in vectorObjects)
        {
            foreach (var line in vo)
            {
                var adapter = new LineToPointAdapter(line);
                adapter.ForEach(DrawPoint);
            }
        }
    }
}