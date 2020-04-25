using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo1 : MonoBehaviour
{
    public bool b;
    // Start is called before the first frame update
    void Start()
    {
        b = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            b = true;
    }
}
