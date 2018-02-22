using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanManager : MonoBehaviour {

    public GameObject plane;

    Texture2D myTexture;
    public Transform OtherObjectA; // First object of pair
    public Transform OtherObjectB; // Second object of pair
    public Transform OtherObjectC; // Second object of pair

    private bool scalingOngoing = false;
    // Use this for initialization
    void LoadPlan()
    {

        // load texture from resource folder
        myTexture = Resources.Load("plan") as Texture2D;
        Material material = new Material(Shader.Find("Diffuse"))
        {
            mainTexture = myTexture
        };
        plane.GetComponent<Renderer>().material = material;
    }
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        LoadPlan();
        scalingOngoing = true;
    }
    void PositionPlane()
    {
        //center
        Vector3 midpointAtoB = new Vector3((OtherObjectA.position.x + OtherObjectB.position.x) / 2.0f, (OtherObjectA.position.y + OtherObjectB.position.y) / 2.0f, (OtherObjectA.position.z + OtherObjectB.position.z) / 2.0f); // midpoint between A B this is what you want
        plane.transform.position = midpointAtoB;
        Vector3 midpointAtoC = new Vector3(plane.transform.position.x, (OtherObjectA.position.y + OtherObjectC.position.y) / 2.0f, (OtherObjectA.position.z + OtherObjectC.position.z) / 2.0f); // midpoint between A B this is what you want
        plane.transform.position = midpointAtoC;

        //Scale 
        Debug.Log(Mathf.Abs(OtherObjectA.localPosition.y));
        plane.transform.localScale = new Vector3((Mathf.Abs(OtherObjectA.localPosition.x - OtherObjectB.localPosition.x)) /10, transform.localScale.y, (Mathf.Abs(OtherObjectA.localPosition.y - OtherObjectC.localPosition.y)) / 10);
        //plane.transform.localScale = new Vector3((Mathf.Abs(OtherObjectA.localPosition.x) + Mathf.Abs(OtherObjectB.localPosition.x)) / 10, transform.localScale.y, (Mathf.Abs(OtherObjectA.localPosition.y) + Mathf.Abs(OtherObjectC.localPosition.y)) / 10);

        //rotation
        plane.transform.rotation = Quaternion.Euler(OtherObjectA.eulerAngles.x -90, OtherObjectA.eulerAngles.y, OtherObjectA.eulerAngles.z );
        plane.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
       if (scalingOngoing) PositionPlane();
       if(Input.GetKeyDown("g")) LoadPlan();
        if (Input.GetKeyDown("h")) PositionPlane();
    }
}
