using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class CanvasManager : MonoBehaviour {

    private GestureRecognizer recognizer;

    [SerializeField]
    GameObject menu, cam;

    // Use this for initialization
    void Start () {
        //menu.transform.position = cam.transform.position + cam.transform.forward * 1.2f;
    }

    public void OnTrigger()
    {
        if (!menu.activeSelf)
        {
            menu.transform.position = cam.transform.position + cam.transform.forward * 1.2f;
            menu.SetActive(true);
        }
        else menu.SetActive(false);
    }


    /*void OnTriggerMenu()
    {
        //if (!menu.activeSelf) menu.SetActive(true);
        menu.SetActive(false);
    }*/


    // Update is called once per frame
    void Update () {
		
	}
}
