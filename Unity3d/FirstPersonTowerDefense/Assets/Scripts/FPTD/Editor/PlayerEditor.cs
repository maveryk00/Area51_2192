using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FPTD {
    [CustomEditor(typeof(Player))]
    public class PlayerEditor : Editor {
        Player myPlayer;

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            myPlayer = (Player)target;

            EditorGUILayout.Space(10f);
            EditorGUILayout.LabelField("Resources");
            if (myPlayer.resources != null) {
                int gold = myPlayer.resources.resourcesDictionary[Resources.Type.gold];
                EditorGUILayout.LabelField("Gold :" + gold.ToString());

                int metal = myPlayer.resources.resourcesDictionary[Resources.Type.metal];
                EditorGUILayout.LabelField("Metal :" + metal.ToString());
            }
        }
    }
}
