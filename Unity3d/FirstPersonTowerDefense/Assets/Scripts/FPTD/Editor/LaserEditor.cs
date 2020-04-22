using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FPTD {
    [CustomEditor(typeof(Laser))]
    public class LaserEditor : Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            Laser myTarget = (Laser)target;

            if (myTarget.target == null)
                return;

            GUILayout.Label("Distance: "+ myTarget.distance);
            GUILayout.Label("End: " + myTarget.end);

        }
    }
}