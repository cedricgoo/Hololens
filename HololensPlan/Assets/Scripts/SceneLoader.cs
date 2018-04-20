using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    void OnSelect()
    {
        if (name == "GO3D") SceneManager.LoadScene("plan3D");
        if (name == "GO2D") SceneManager.LoadScene("plan2D");

    }
}