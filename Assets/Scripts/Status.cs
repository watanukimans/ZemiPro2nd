using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("disabled", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("disabled", 1.0f);
    }

    void disabled()
    {
        this.gameObject.SetActive(false);
    }
}
