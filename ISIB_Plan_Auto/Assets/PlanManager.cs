using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanManager : MonoBehaviour {
    Texture secondText;
    // Use this for initialization
    void Start () {
		secondText = Resources.Load("Lion") as Texture2D;
    }

    // Update is called once per frame
    void Update()
    {

        if(GameObject.Find("SurfacePlanes")){
            foreach (Transform plane in GameObject.Find("SurfacePlanes").transform)
            {
                plane.GetComponent<MeshRenderer>().material.EnableKeyword("_DETAIL_MULX2");
                plane.GetComponent<MeshRenderer>().material.SetTexture("_DetailAlbedoMap", secondText);
            }
        }
    }
}
