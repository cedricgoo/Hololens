using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image : MonoBehaviour {

    [SerializeField]
    public GameObject manager;

    private PlanManager planManager;

    void Start()
    {
        planManager = manager.GetComponent<PlanManager>();
    }

    void OnSelect()
    {
        planManager.HandleLayers(gameObject.name);
    }
}
