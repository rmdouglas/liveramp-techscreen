using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public enum Direction {
        Up, Down, Left, Right
    };
    public readonly struct Spiral
    {
        private static Dictionary<Direction, (int, int)> Steps = new Dictionary<Direction, (int, int)>()
        {
            {Direction.Up, (0, -1)},
            {Direction.Down, (0, 1)},
            {Direction.Left, (-1, 0)},
            {Direction.Right, (1, 0)},
        };
        private static Dictionary<Direction, Direction> NextDirection = new Dictionary<Direction, Direction>()
        {
            { Direction.Up, Direction.Right },
            { Direction.Down, Direction.Left },
            { Direction.Left, Direction.Up },
            { Direction.Right, Direction.Down },
        };
        private readonly HashSet<(int, int)> data;
        public readonly int Size;
        
        public bool IsSet(int x, int y) {
            return data.Contains((x, y));
        }
        
        public Spiral(int size)
        {
            this.Size = size;
            this.data = GenerateSpiral(Size);
        }
        
        private static HashSet<(int, int)> GenerateSpiral(int n)
        {
            var spiral = new HashSet<(int, int)>();

            var x = 0;
            var y = 0;
            var dir = Direction.Right;
            for(int i = n; i > 0; --i) {
                (x, y, dir) = GenerateArm(spiral, x, y, dir, i);
            }

            return spiral;
        }
        private static (int, int, Direction) GenerateArm(HashSet<(int, int)> spiral, int x, int y, Direction dir, int len) {
            if(len <= 0) return (x, y, dir);
            
            var (xstep, ystep) = Steps[dir];
            for(int i = 0; i < len; ++i)
            {
                spiral.Add((x, y));
                x += xstep;
                y += ystep;
            }
            return (x - xstep, y - ystep, NextDirection[dir]);
        }
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            for(var y = 0; y < Size; ++y) {
                for(var x = 0; x < Size; ++x) {
                    if(data.Contains( (x, y) ))
                        sb.Append('#');
                    else
                    sb.Append(' ');
                }
                sb.Append(System.Environment.NewLine);
            }
            return sb.ToString();
        }
    }
    public class Solution {


        public static void Main(string[] args) {

            for(int i = 1; i <= 10; ++i) {
                var spiral = new Spiral(i);
                Console.WriteLine(spiral);
                Console.WriteLine();
            }
        }
    }
}
