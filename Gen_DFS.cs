using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room
{
    public partial class DFS : Form
    {
        public class Map
        {
            private bool[,] maze; 
            private List<Point> path = new List<Point>(); 
            private Stack<Point> stack = new Stack<Point>(); 
            private HashSet<Point> visited = new HashSet<Point>(); 

            public Map(bool[,] generatedMaze)
            {
                maze = generatedMaze;
            }
            public List<Point> FindPathWithDFS(Point start, Point end)
            {
                stack.Push(start); 
                visited.Add(start);

                while (stack.Count > 0) 
                {
                    var current = stack.Peek(); 
                    path.Add(current); 
                    if (current == end) 
                        break;
                    List<Point> neighbors = GetUnvisitedNeighbors(current);
                    if (neighbors.Count > 0)
                    {
                        Point next = neighbors[0]; 
                        stack.Push(next); 
                        visited.Add(next); 
                    }
                    else
                    {
                        stack.Pop(); 
                        path.Remove(current); 
                    }
                }
                return path;
            }
            private List<Point> GetUnvisitedNeighbors(Point current)
            {
                var neighbors = new List<Point>();
                var directions = new List<Point> { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1) };

                foreach (var dir in directions)
                {
                    Point neighbor = new Point(current.X + dir.X, current.Y + dir.Y);
                    if (IsInBounds(neighbor) && !maze[neighbor.X, neighbor.Y] && !visited.Contains(neighbor)) 
                    {
                        neighbors.Add(neighbor);
                    }
                }
                return neighbors;
            }

            private bool IsInBounds(Point p)
            {
                return p.X >= 0 && p.X < maze.GetLength(0) && p.Y >= 0 && p.Y < maze.GetLength(1);
            }
        }
    }
}
