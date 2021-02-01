using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Dynamic;

public class CustomTree
{
    public class Node
    {
        public string keyword;
        protected string path;
        public bool complete_path;
        public Dictionary<string, Node> children;

        public Node left, right;

        public Node(string keyword)
        {
            this.keyword = keyword;
            this.children = new Dictionary<string, Node>();
            this.left = null;
            this.right = null;
        }
    }

    Node root = new Node("/");
    static List<string> tree_itens = new List<string>();

    Node getNode(string path) {
        Dictionary<string, Node> currentMapNode = root.children;
        Node trieNode = null;
        string[] path_itens = path.Split('/');

        for (uint i = 0; i < path_itens.Length; i++){
            string word = path_itens[i];
            if (currentMapNode.ContainsKey(word))
            {
                trieNode = currentMapNode[word];
                currentMapNode = trieNode.children;
            }
            else
            {
                return null;
            }
        }
            return trieNode;
    }

    public string[] createTree(string path)
    {
        string[] itens = path.Split('/');
        foreach (var item in itens)
        {
            insert(item);
        }
        return itens;
    }

    public void insert(string path)
    {
        Dictionary<string, Node> currentMapNode = root.children;
        Node trieNode = null;
        string[] path_itens = path.Split('/');

        for (uint i = 0; i < path_itens.Length; i++)
        {
            string word = path_itens[i];
            if (currentMapNode.ContainsKey(word))
            {
                trieNode = currentMapNode[word];
            } else
            {
                trieNode = new Node(word);
                currentMapNode.Add(word,trieNode);
            }
            currentMapNode = trieNode.children;

            if (i == path_itens.Length - 1)
            {
                trieNode.complete_path = true;
            }
        }
    }

    public void insertDual(string path)
    {
        Dictionary<string, Node> currentMapNode = root.children;
        Node trieNode = null;
        string[] dual = path.Split('|');

        if (dual.Length == 2)
        {
            insertMany(path);
        }
        else
        {
            throw new ArgumentException("Invalid input");
        }
    }

    public void insertCombinational(string path)
    {
        insertMany(path, true);
    }

    public void insertMany(string path, bool is_combinational = false)
    {
        Dictionary<string, Node> currentMapNode = root.children;
        int idx = path.LastIndexOf('/');
        string str = "";
        string head_path = path.Substring(0, idx);
        string words = path.Substring(idx + 1);
        string[] many = words.Split('|');
        for (int i = 0; i < many.Length; i++)
        {
            str += head_path + "/" + many[i] + "/";
            insert(str);
            str = "";
        }

        if (is_combinational)
        {
            List<string> combinational_paths = Combinational(many);
            foreach (string c_path in combinational_paths)
            {
                str += head_path + "/" + c_path + "/";
                insert(str);
                str = "";
            }
        }
    }

    public List<string> Combinational(string[] words)
    {
        List<string> response = new List<string>();
        string str_all = "";
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = i + 1; j < words.Length; j++)
            {
                string str = words[i] + "-" + words[j];
                response.Add(str);
            }
            if (i + 1 == words.Length)
            {
                str_all += words[i];
            }
            else
            {
                str_all += words[i] + "-";
            }
        }
        if (words.Length > 2)
        {
            response.Add(str_all);
        }
        return response;
    }

    public bool contains(string word) {
            Node trieNode = getNode(word);
            return (trieNode != null && trieNode.complete_path);
    }

    List<string> path;
    List<string> str_paths;

    public List<string> getPaths()
    {
        path = new List<string>();
        str_paths = new List<string>();
        return getPaths(root);
    }

    public List<string> getPaths(Node node)
    {
        Dictionary<string, Node> currentMapNode = node.children;
        foreach (KeyValuePair<string, Node> kvp in currentMapNode)
        {
            if (kvp.Value.children.Count != 0)
            {
                path.Add(kvp.Key);
                getPaths(kvp.Value);
                if (kvp.Value.complete_path != null)
                {
                    if (contains(listToString(path)))
                    {
                        str_paths.Add(listToString(path));
                    }
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
        return str_paths;
    }

    string listToString(List<string> list)
    {
        string str = "";
        foreach (string item in list)
        {
            str += item + "/";
        }
        return str;
    }
}
