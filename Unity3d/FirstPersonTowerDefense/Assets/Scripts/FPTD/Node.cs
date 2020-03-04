using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Node {
        public string name;
        public List<Node> exits;


        public Node() {
            name = "New Node";
            exits = new List<Node>();
        }

        public void AddExit(Node node) {
            exits.Add(node);
        }

        public void RemoveExit(Node node) {
            exits.Remove(node);
        }

        public Node GetRandomExit() {
            return exits[Random.Range(0, exits.Count)];
        }

    }
}