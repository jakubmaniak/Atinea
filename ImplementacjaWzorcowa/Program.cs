using System;
using System.Collections.Generic;

namespace RekrutacjaAtinea
{
    class Program
    {
        internal class Building
        {
            public int Width { get; private set; }
            public int Height { get; private set; }

            public Building(int width, int height)
            {
                Width = width;
                Height = height;
            }
        }

        static void Main(string[] args)
        {
            Building[] buildings = ReadInput();
            int posterCount = CalculatePosterCount(buildings);

            Console.WriteLine(posterCount);
        }

        private static Building[] ReadInput()
        {
            int n = int.Parse(Console.ReadLine());
            Building[] buildings = new Building[n];

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split(' ');
                buildings[i] = new Building(int.Parse(parts[0]), int.Parse(parts[1]));
            }

            return buildings;
        }

        private static int CalculatePosterCount(Building[] buildings)
        {
            int posterCount = 0;
            Stack<int> stack = new Stack<int>();

            foreach (Building building in buildings)
            {
                while (stack.Count != 0 && stack.Peek() > building.Height)
                {
                    stack.Pop();
                }

                if (stack.Count == 0 || stack.Peek() < building.Height)
                {
                    stack.Push(building.Height);
                    posterCount++;
                }
            }

            return posterCount;
        }
    }
}
