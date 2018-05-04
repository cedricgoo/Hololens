using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planes : MonoBehaviour {

    public GameObject menu, cam, manager;
    enum States { one, two, three, all };
    States myState;
    Material loadedMat;
    // Use this for initialization
    void Start () {
        manager = GameObject.Find("Manager");
        gameObject.tag = "plane";
        cam = GameObject.Find("Main Camera");
        menu = GameObject.Find("MenuManager").transform.GetChild(0).gameObject;
        loadedMat = Resources.Load("Materials/defaultPlan", typeof(Material)) as Material;
        gameObject.GetComponent<Renderer>().material = loadedMat;
        myState = States.all;
        myState = ChangeState(myState);
        loadedMat = gameObject.GetComponent<Renderer>().material;
    }
	
    void OnSelect()
    {
        myState = ChangeState(myState);
    }

    void OnSelectDouble()
    {
        menu.transform.position = cam.transform.position + cam.transform.forward * 1.8f;
        menu.transform.position = menu.transform.position + menu.transform.right * 0.4f;
        menu.SetActive(true);
        manager.GetComponent<PlanManager>().selectedPlane = gameObject;
    }

    States ChangeState(States s)
    {
        switch (s)
        {
            case States.all:
                Debug.Log("into all states");
                loadedMat.SetFloat("_Percentage2", 0);
                loadedMat.SetFloat("_Percentage3", 0);
                s = States.one;
                break;
            case States.one:
                Debug.Log("into one states");
                loadedMat.SetFloat("_Percentage1", 0);
                loadedMat.SetFloat("_Percentage2", 1);
                s = States.two;
                break;
            case States.two:
                Debug.Log("into two states");
                loadedMat.SetFloat("_Percentage2", 0);
                loadedMat.SetFloat("_Percentage3", 1);
                s = States.three;
                break;
            case States.three:
                Debug.Log("into three states");
                loadedMat.SetFloat("_Percentage1", 1);
                loadedMat.SetFloat("_Percentage2", 1);
                s = States.all;
                break;
            default:
                s = States.all;
                break;
        }
        return s;
    }



	// Update is called once per frame
	void Update () {
		
	}
}
