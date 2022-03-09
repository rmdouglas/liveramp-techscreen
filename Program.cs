using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution {

        public enum Direction {
            Up, Down, Left, Right
        };

        private static (int, int, Direction) GenerateArm(List<List<bool>> spiral, int x, int y, Direction dir, int len) {
            if(len <= 0) return (x, y, dir);

            switch(dir)
            {
                case Direction.Up:
                    for(int i = 0; i < len; ++i) {
                        spiral[y][x] = true;
                        y--;
                    }
                    return (x, y+1, Direction.Right);
                case Direction.Down:
                    for(int i = 0; i < len; ++i) {
                        spiral[y][x] = true;
                        y++;
                    }
                    return (x, y-1, Direction.Left);
                case Direction.Left:
                    for(int i = 0; i < len; ++i) {
                        spiral[y][x] = true;
                        x--;
                    }
                    return (x+1, y, Direction.Up);
                case Direction.Right:
                    for(int i = 0; i < len; ++i) {
                        spiral[y][x] = true;
                        x++;
                    }
                    return (x-1, y, Direction.Down);
            }
            return (x, y, dir);
        }

        private static List<List<bool>> GenerateSpiral(int n)
        {
            var spiral = new List<List<bool>>();

            for(int i = 0; i < n; ++i) {
                spiral.Add(new List<bool>());
                for(int j = 0; j < n; ++j) {
                    spiral[i].Add(false);
                }
            }

            var x = 0;
            var y = 0;
            var dir = Direction.Right;
            for(int i = n; i > 0; --i) {
                (x, y, dir) = GenerateArm(spiral, x, y, dir, i);
            }

            return spiral;
        }

        public static void PrintSpiral(List<List<bool>> spiral) {
            foreach(var row in spiral) {
                foreach(var item in row) {
                    Console.Write(item ? "#" : " ");
                }
                Console.WriteLine();
            }
        }

        public static void Main(string[] args) {

            for(int i = 1; i <= 7; ++i) {
                var spiral = GenerateSpiral(i);
                PrintSpiral(spiral);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
