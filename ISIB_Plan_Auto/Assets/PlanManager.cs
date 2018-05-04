using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Academy.HoloToolkit.Unity;

public class PlanManager : MonoBehaviour {
    public Material defaultMat;
    public GameObject selectedPlane;
    public GameObject menu;

    // Use this for initialization
    void Start () {
        defaultMat = Instantiate(defaultMat);
        //event quand les planes sont créés
        SurfaceMeshesToPlanes.Instance.MakePlanesComplete += SurfaceMeshesToPlanes_MakePlanesComplete;
    }
    private void SurfaceMeshesToPlanes_MakePlanesComplete(object source, System.EventArgs args)
    {
        
        GameObject.Find("SpatialMapping").SetActive(false);
        GameObject.Find("SpatialProcessing").SetActive(false);
        LoadDefaultMaterials();
    }
    public void LoadDefaultMaterials()
    {
        if (GameObject.Find("SurfacePlanes"))
        {
            foreach (Transform plane in GameObject.Find("SurfacePlanes").transform)
            {
                plane.gameObject.AddComponent<Planes>();
            }
        }
    }

    public void HandleLayers(string setName)
    {
        if (selectedPlane)
        {
            Renderer rd = selectedPlane.GetComponent<Renderer>();
            rd.material.SetTexture("_MainTex", Resources.Load(setName + "/text1") as Texture);
            rd.material.SetTexture("_BisTex", Resources.Load(setName + "/text2") as Texture);
            rd.material.SetTexture("_TrisTex", Resources.Load(setName + "/text3") as Texture);
            menu.SetActive(false);
            selectedPlane = null;
        }

    }

    private void OnDestroy()
    {
        if (SurfaceMeshesToPlanes.Instance != null)
        {
            SurfaceMeshesToPlanes.Instance.MakePlanesComplete -= SurfaceMeshesToPlanes_MakePlanesComplete;
        }
    }
}
