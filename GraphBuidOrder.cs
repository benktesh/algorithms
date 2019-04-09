using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class Project
    {
        private IList<Project> _children = new List<Project>();
        private IDictionary<String, Project> _map = new Dictionary<String, Project>();
        private int _dependencies = 0;

        public Project(String name)
        {
            Name = name;
        }

        public String Name { get; set; }

        public void AddNeighbor(Project node)
        {
            if (!_map.ContainsKey(node.Name))
            {
                _children.Add(node);
                _map.Add(node.Name, node);
                node.IncrementDependencies();
            }
        }

        public IList<Project> GetChildren()
        {
            return _children;
        }

        public void IncrementDependencies()
        {
            _dependencies++;
        }

        public void DerementDependencies()
        {
            _dependencies--;
        }

        public int GetNumberDependencies()
        {
            return _dependencies;
        }
    }
    class Graph
    {
        private IList<Project> nodes = new List<Project>();
        private IDictionary<String, Project> _map = new Dictionary<string, Project>();

        public Project GetOrCrateNode(String name)
        {
            if (!_map.ContainsKey(name))
            {
                Project node = new Project(name);
                nodes.Add(node);
                _map.Add(name, node);
            }
            return _map.ContainsKey(name) ? _map[name] : null;
        }

        public void AddEdge(String startName, String endName)
        {
            Project start = GetOrCrateNode(startName);
            Project end = GetOrCrateNode(endName);
            start.AddNeighbor(end);
        }

        public IList<Project> GetNodes()
        {
            return nodes;
        }
    }
    class GraphBuidOrder
    {
        public static Graph BuildGraph(String[] projects, String[][] dependencies)
        {
            Graph graph = new Graph();
            foreach (var project in projects)
            {
                graph.GetOrCrateNode(project);
            }
            foreach (var dependency in dependencies)
            {
                var first = dependency[0];
                var second = dependency[1];
                graph.AddEdge(first, second);
            }
            return graph;
        }

        public static Project[] FindBuildOrder(String[] projects, String[][] dependencies)
        {
            Graph graph = BuildGraph(projects, dependencies);
            return OrderProjects(graph.GetNodes());
        }

        public static Project[] OrderProjects(IList<Project> projects)
        {
            Project[] order = new Project[projects.Count];

            int endofList = AddNonDependent(order, projects, 0);
            int toBeProcessed = 0; 

            while(toBeProcessed < order.Length)
            {
                Project current = order[toBeProcessed];
                if(current == null)
                {
                    return null; 
                }

                IList<Project> children = current.GetChildren();
                foreach(var child in children)
                {
                    child.DerementDependencies();
                }

                endofList = AddNonDependent(order, children, endofList);
                toBeProcessed++;
            }

            return order;

        }

        public static int AddNonDependent(Project[] order, IList<Project> projects, int offSet)
        {
            foreach(var project in projects)
            {
                if(project.GetNumberDependencies() == 0)
                {
                    order[offSet] = project;
                    offSet++;
                }
            }
            return offSet;
        }

        public static void main(String[] args)
        {

            String[] projects = { "a", "b", "c", "d", "f",  "e" };// "g", "h", "i", "j" };

            String[][] dependencies = {
                new string[] {"a", "d"},
                new string[] {"f", "b"},
                new string[] {"b", "d"},
                new string[] {"f", "a"},
                new string[] {"d", "c"},
                //new string[] {"b", "d"},
                //new string[] {"e", "f"},
                //new string[] {"a", "f"},
                //new string[] {"h", "i"},
                //new string[] {"h", "j"},
                //new string[] {"i", "j"},
                //new string[] {"g", "j"}
            };

            Project[] buildOrder = FindBuildOrder(projects, dependencies);

            if (buildOrder == null)
            {

                Console.WriteLine("Circular Dependency.");
                return;

            }
            foreach (var item in buildOrder)
            {

                Console.WriteLine(item.Name);

            }
        }

    }
}
