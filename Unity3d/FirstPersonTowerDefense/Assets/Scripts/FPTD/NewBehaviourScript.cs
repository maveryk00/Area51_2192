using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [System.Serializable]
    struct Pokemon {
        public string name;
        public int order;
        public int weight;
    }

    [SerializeField]
    Pokemon Ditto;

    public TextAsset json;

    // Start is called before the first frame update
    void Start() {

        Ditto = JsonUtility.FromJson<Pokemon>(json.text);
        Debug.Log(Ditto);
#if UNITY_EDITOR
        Debug.Log(JsonUtility.ToJson(Ditto, true));
#else
        Debug.Log(JsonUtility.ToJson(Ditto, false));
#endif
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
