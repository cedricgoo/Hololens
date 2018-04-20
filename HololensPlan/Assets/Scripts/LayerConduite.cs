using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerConduite : MonoBehaviour {

    public GameObject wall;

    void OnSelect()
    {
        wall.GetComponent<MeshRenderer>().material.color = new Color32(255,255,255,44);
    }
}
