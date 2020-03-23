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


        public TextAsset json;
        public jsonPath myPath;

        [System.Serializable]
        public struct exits {
            public List<int> nodes;
        }

        [System.Serializable]
        public struct jsonPath {
            public Vector3[] nodes;
            public List<exits> exits;
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


            for (int i = 0; i < myPath.nodes.Length; i++) {
                for (int j = 0; j < myPath.exits[i].nodes.Count; j++) {
                    nodes[i].AddExit(nodes[myPath.exits[i].nodes[j]]);
                }
            }



            //PrintNodes();
        }

        // Update is called once per frame
        void Update() {

        }

        void OnDrawGizmos() {
            if (transform.childCount < 2)
                return;

            for (int i = 0; i < myPath.nodes.Length; i++) {
                for (int j = 0; j < myPath.exits[i].nodes.Count; j++) {
                    Gizmos.DrawLine(
                        transform.GetChild(i).position,
                        transform.GetChild(myPath.exits[i].nodes[j]).position
                        );
                }
            }

        }
        #endregion

        private void PrintNodes() {
            nodes.ForEach((node) => {
                Debug.Log(node.name + " " + node.exits.Count);
            });
        }

        public void LoadJson() {
            myPath = JsonUtility.FromJson<jsonPath>(json.text);

            for (int i = 0; i < myPath.nodes.Length; i++) {
                for (int j = 0; j < myPath.exits[i].nodes.Count; j++) {
                    Debug.Log("from: " + transform.GetChild(i).name + " to: " + transform.GetChild(myPath.exits[i].nodes[j]).name);
                }
            }
        }

        public void DeleteAllNodes() {
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++) {
                Debug.Log(transform.GetChild(0).name);
                DestroyImmediate(transform.GetChild(0).gameObject);
            }

            nodes.Clear();
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