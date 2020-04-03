using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FPTD {
    [CustomEditor(typeof(WaveLoader))]
    public class WaveLoaderEditor : Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            WaveLoader myTarget = (WaveLoader)target;

            if (GUILayout.Button("Load JSON"))
                myTarget.LoadJson();
        }
    }
}