using System;

namespace RekrutacjaAtineaRekurencyjnie
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
            int posterCount = 0;
            CheckRegion(buildings, 0, buildings.Length - 1, 0, ref posterCount);

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

        private static int CalculateRegionHeight(Building[] buildings, int fromIndex, int toIndex, int fromY)
        {
            int regionHeight = buildings[fromIndex].Height - fromY;

            for (int i = fromIndex + 1; i <= toIndex; i++)
            {
                Building current = buildings[i];
                if (current.Height < regionHeight + fromY)
                {
                    regionHeight = current.Height - fromY;
                }
            }

            return regionHeight;
        }


        private static void CheckRegion(Building[] buildings, int fromIndex, int toIndex, int fromY, ref int posterCount)
        {
            int regionHeight = CalculateRegionHeight(buildings, fromIndex, toIndex, fromY);
            int? branchFromIndex = null;

            for (int i = fromIndex; i <= toIndex; i++)
            {
                if (buildings[i].Height - fromY > regionHeight)
                {
                    if (branchFromIndex == null) branchFromIndex = i;
                }
                else if (branchFromIndex != null)
                {
                    CheckRegion(buildings, (int)branchFromIndex, i - 1, fromY + regionHeight, ref posterCount);
                    branchFromIndex = null;
                }
            }

            if (branchFromIndex != null)
            {
                CheckRegion(buildings, (int)branchFromIndex, toIndex, fromY + regionHeight, ref posterCount);
            }

            posterCount++;
        }
    }
}
