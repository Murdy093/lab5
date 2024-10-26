using System;
using System.Collections.Generic;

public class MyGraph<T>
{
    private Dictionary<T, List<T>> adjList; 

    public MyGraph()
    {
        adjList = new Dictionary<T, List<T>>();
    }

    public void AddVertex(T vertex)
    {
        if (!adjList.ContainsKey(vertex))
        {
            adjList[vertex] = new List<T>();
        }
    }

    public void AddEdge(T from, T to)
    {
        if (!adjList.ContainsKey(from))
        {
            AddVertex(from);
        }

        if (!adjList.ContainsKey(to))
        {
            AddVertex(to);
        }

        adjList[from].Add(to);
    }

    private void DFSUtil(T vertex, HashSet<T> visited)
    {
        visited.Add(vertex);
        Console.WriteLine(vertex); 

        
        foreach (T neighbor in adjList[vertex])
        {
            if (!visited.Contains(neighbor))
            {
                DFSUtil(neighbor, visited);
            }
        }
    }
    public void DFS(T startVertex)
    {
        HashSet<T> visited = new HashSet<T>(); 
        DFSUtil(startVertex, visited);
    }
}


public class Program
{
    public static void Main()
    {
        MyGraph<int> graph = new MyGraph<int>();

        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 0);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 3);

        Console.WriteLine("DFS починаючи з вершини 2:");
        graph.DFS(2);
        Console.ReadKey();
    }
}
