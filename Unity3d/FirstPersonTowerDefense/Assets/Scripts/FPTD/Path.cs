using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Path : MonoBehaviour {
        public List<Node> nodes = new List<Node>();

        public Node start {
            get {
                return nodes[0];
            }
        }

        public Node finish {
            get {
                return nodes[nodes.Count - 1];
            }
        }

        public int nodesCount {
            get {
                return nodes.Count;
            }
        }

        // Start is called before the first frame update
        void Start() {
            foreach (Transform child in transform) {
                Node n = new Node();
                n.name = child.name;
                AddNode(n);
            }

            PrintNodes();
        }

        // Update is called once per frame
        void Update() {

        }

        void OnDrawGizmos() {
            if (transform.childCount < 2)
                return;

            for (int i = 1; i < transform.childCount; i++) {
                Gizmos.DrawLine(
                    transform.GetChild(i - 1).position,
                    transform.GetChild(i).position
                    );
            }
        }

        private void PrintNodes() {
            nodes.ForEach((node) => {
                Debug.Log(node.name);
            });
        }

        public void GenerateNodes() {
            Debug.Log("GenerateNodes");
            GameObject n = new GameObject(
                "Node " + transform.childCount);
            
            if (transform.childCount > 1) {
                n.transform.position =
                    transform.GetChild(
                        transform.childCount - 1).position;
            }

            n.transform.parent = transform;
        }

        public void AddNode(Node node) {
            nodes.Add(node);
        }

        public Vector3 GetPosition(Node from, Node to) {
            return Vector3.zero;
        }

        public float GetDistance(Node from, Node to) {
            return -1f;
        }
    }
}