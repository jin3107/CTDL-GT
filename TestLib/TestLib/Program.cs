using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C5;
using MoreLinq;
using QuickGraph;
using MathNet;
using QuickGraph.Algorithms.Search;

namespace TestLib
{
    class Program
    {
        static void Main(string[] args)
        {
            // MoreLINQ
            var people = new[] { new { Name = "A", Age = 20 }, new { Name = "B", Age = 20 }, new { Name = "C", Age = 22 } };

            // Lọc phần tử duy nhất theo tuổi
            var distinct = people.DistinctBy(p => p.Age);
            Console.WriteLine(string.Join(", ", distinct.Select(p => p.Name))); // Output: A, C

            // Chia danh sách thành batch nhỏ (kích thước 2)
            var numbers = Enumerable.Range(1, 6);
            var batches = numbers.Batch(2);
            foreach (var batch in batches) Console.WriteLine(string.Join(", ", batch));

            // Tạo hoán vị (Permutation)
            var perm = new[] { 1, 2, 3 }.Permutations();
            foreach (var p in perm) Console.WriteLine(string.Join("", p));

            // C5
            // Min-Heap (Priority Queue)
            var pq = new IntervalHeap<int>();
            pq.Add(5);
            pq.Add(2);
            pq.Add(8);
            Console.WriteLine(pq.DeleteMin()); // Output: 2

            // TreeDictionary (SortedDictionary có thêm tính năng)
            var treeDict = new TreeDictionary<int, string>();
            treeDict.Add(3, "Three");
            treeDict.Add(1, "One");
            treeDict.Add(2, "Two");

            foreach (var item in treeDict) Console.WriteLine($"{item.Key}: {item.Value}");

            // QuickGraph
            // Tạo đồ thị có hướng
            var graph = new AdjacencyGraph<int, Edge<int>>();
            graph.AddVerticesAndEdge(new Edge<int>(1, 2));
            graph.AddVerticesAndEdge(new Edge<int>(1, 3));
            graph.AddVerticesAndEdge(new Edge<int>(2, 4));
            graph.AddVerticesAndEdge(new Edge<int>(3, 5));

            // Duyệt BFS
            var bfs = new BreadthFirstSearchAlgorithm<int, Edge<int>>(graph);
            bfs.TreeEdge += (e) => Console.WriteLine($"{e.Source} -> {e.Target}");
            bfs.Compute(1);
        }
    }
}
