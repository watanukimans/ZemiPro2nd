using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeScript2 : MonoBehaviour
{
    public GameObject righteye;
    public GameObject lefteye;
    public GameObject lefteyeb;
    public GameObject righteyeb;
    // Start is called before the first frame update
    void OnMouseEnter()
    {
        //Debug.Log("マウスが乗った");
        righteye.transform.localScale = new Vector3(
            righteye.transform.localScale.x * 1.2f,
            righteye.transform.localScale.y * 1.2f,
            righteye.transform.localScale.z
        );
        lefteye.transform.localScale = new Vector3(
            lefteye.transform.localScale.x * 1.2f,
            lefteye.transform.localScale.y * 1.2f,
            lefteye.transform.localScale.z
        );
        righteyeb.transform.rotation = Quaternion.Euler(0, 0, -20);
        lefteyeb.transform.rotation = Quaternion.Euler(0, 0, 20);
    }
    private void OnMouseExit()
    {
        righteye.transform.localScale = new Vector3(
            righteye.transform.localScale.x / 1.2f,
            righteye.transform.localScale.y / 1.2f,
            righteye.transform.localScale.z
        );
        lefteye.transform.localScale = new Vector3(
            lefteye.transform.localScale.x / 1.2f,
            lefteye.transform.localScale.y / 1.2f,
            lefteye.transform.localScale.z
        );
        righteyeb.transform.rotation = Quaternion.Euler(0, 0, 0);
        lefteyeb.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
