using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPTD {
    public class Path : MonoBehaviour {
        static public Path instance;
        static public Node startNode {
            get {
                return instance.start;
            }
        }

        static public Node finishNode {
            get {
                return instance.finish;
            }
        }

        static public Vector3 GetPositionAt(Node from, Node to, float t) {
            return instance.GetPosition(from, to, t);
        }



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

        #region Unity events
        void Awake() {
            instance = this;
            foreach (Transform child in transform) {
                Node n = new Node(child.position);
                n.name = child.name;
                AddNode(n);
            }

            for (int i = 1; i < nodes.Count; i++) {
                nodes[i - 1].AddExit(nodes[i]);
            }

            //PrintNodes();
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
        #endregion

        private void PrintNodes() {
            nodes.ForEach((node) => {
                Debug.Log(node.name + " " + node.exits.Count);
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

        public Vector3 GetPosition(Node from, Node to, float t) {
            return Vector3.Lerp(
                from.position, 
                to.position,
                t);
        }

        public float GetDistance(Node from, Node to) {
            return -1f;
        }
    }
}