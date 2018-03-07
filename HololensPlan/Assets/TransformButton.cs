using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransformButton : MonoBehaviour
{
    [SerializeField]
    GameObject plan;

    float posIncrement = 0.1f;
    float rotIncrement = 0.1f;
    float scaleMultiplier = 1;


    void OnSelect()
    {
        switch (name)
        {
            case "pxp":
                plan.transform.position = new Vector3(plan.transform.position.x + posIncrement, plan.transform.position.y, plan.transform.position.z);
                break;
            case "pyp":
                plan.transform.position = new Vector3(plan.transform.position.x, plan.transform.position.y + posIncrement, plan.transform.position.z);
                break;
            case "pzp":
                plan.transform.position = new Vector3(plan.transform.position.x, plan.transform.position.y, plan.transform.position.z + posIncrement);
                break;
            case "rxp":
                plan.transform.rotation = Quaternion.Euler(plan.transform.eulerAngles.x + rotIncrement, plan.transform.eulerAngles.y, plan.transform.eulerAngles.z);
                break;
            case "ryp":
                plan.transform.rotation = Quaternion.Euler(plan.transform.eulerAngles.x, plan.transform.eulerAngles.y + rotIncrement, plan.transform.eulerAngles.z);

                break;
            case "rzp":
                plan.transform.rotation = Quaternion.Euler(plan.transform.eulerAngles.x, plan.transform.eulerAngles.y, plan.transform.eulerAngles.z + rotIncrement);

                break;
            case "pxm":
                plan.transform.position = new Vector3(plan.transform.position.x - posIncrement, plan.transform.position.y, plan.transform.position.z);

                break;
            case "pym":
                plan.transform.position = new Vector3(plan.transform.position.x, plan.transform.position.y - posIncrement, plan.transform.position.z);

                break;
            case "pzm":
                plan.transform.position = new Vector3(plan.transform.position.x, plan.transform.position.y, plan.transform.position.z - posIncrement);

                break;
            case "rxm":
                plan.transform.rotation = Quaternion.Euler(plan.transform.eulerAngles.x - rotIncrement, plan.transform.eulerAngles.y, plan.transform.eulerAngles.z);

                break;
            case "rym":
                plan.transform.rotation = Quaternion.Euler(plan.transform.eulerAngles.x, plan.transform.eulerAngles.y - rotIncrement, plan.transform.eulerAngles.z);

                break;
            case "rzm":
                plan.transform.rotation = Quaternion.Euler(plan.transform.eulerAngles.x, plan.transform.eulerAngles.y, plan.transform.eulerAngles.z - rotIncrement);

                break;
            case "sp":
                plan.transform.localScale += new Vector3(0.03f,0.03f , 0.03f);
                break;
            case "sm":
                plan.transform.localScale -= new Vector3(0.03f, 0.03f, 0.03f);
                break;
        }
    }
}