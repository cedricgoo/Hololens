using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour {

    public GameObject plane;

    Texture2D myTexture;

    void OnSelect()
    {
        switch (name)
        {
            case("Layer1"): LoadPlan("plan1");
                break;
            case ("Layer2"):
                LoadPlan("plan2");
                break;
            case ("Layer3"):
                LoadPlan("plan3");
                break;
            default:
                break;
        }

    }


    void LoadPlan(string textureName)
    {

        // load texture from resource folder
        myTexture = Resources.Load(textureName) as Texture2D;
        Material material = new Material(Shader.Find("Diffuse"))
        {
            mainTexture = myTexture
        };
        plane.GetComponent<Renderer>().material = material;
    }
}
