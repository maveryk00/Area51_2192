using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FPTD {
    [CustomEditor(typeof(Path))]
    public class PathEditor : Editor {
        Path myPath;

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            myPath = (Path)target;


            if (GUILayout.Button("Load json"))
                myPath.LoadJson();
        }
    }
}