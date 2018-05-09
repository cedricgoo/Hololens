using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour {

    public GameObject menu;

    private void OnSelect()
    {
        menu.SetActive(false);
    }
}
