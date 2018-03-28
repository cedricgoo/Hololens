using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnSelect()
    {
        SceneManager.LoadScene("plan3D");
    }
}
