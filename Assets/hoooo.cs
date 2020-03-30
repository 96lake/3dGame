using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoooo : MonoBehaviour
{

    public float bombForce = 1000;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) Explode();
    }

    void Explode()
    {
        print("Boom!");
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.rigidbody)
                {
                    hit.rigidbody.isKinematic = false;
                    hit.rigidbody.AddExplosionForce(bombForce, transform.position, 10);
                }
            }
        }
    }
}