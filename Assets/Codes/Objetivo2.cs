using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo2 : MonoBehaviour
{
    public bool b;
    public Objetivo1 vassoura;
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
        if (other.CompareTag("Player") && vassoura.b)
            b = true;
    }
}
