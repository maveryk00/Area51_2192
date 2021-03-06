﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Node {
        public string name;
        public List<Node> exits;

        private Vector3 _position;
        public Vector3 position {
            get {
                return _position;
            }
        }

        public Node(Vector3 position) {
            name = "New Node";
            exits = new List<Node>();
            _position = position;
        }

        public void AddExit(Node node) {
            exits.Add(node);
        }

        public void RemoveExit(Node node) {
            exits.Remove(node);
        }

        public Node GetRandomExit() {
            //int i = Random.Range(0, exits.Count);
            //if (exits.Count == 0)
            //    return null;
            //return exits[i];

            return exits.Count == 0 ? 
                null:
                exits[Random.Range(0, exits.Count)];
        }

    }
}