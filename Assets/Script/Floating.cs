using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public static float gravity = -30;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("ê⁄êGíÜ");
        gravity = 30;
    }

    private void OnTriggerExit(Collider other)
    {
        gravity = -30;
    }
}
