using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsWalk : MonoBehaviour
{
    Vector3 playerAxis;
    Vector3 playerRotAxis;
    Vector3 headRotAxis;
    public GameObject laserpoint;
    int weapon;
    public CharacterController charac;
    public GameObject[] prefabProjectile;
    public GameObject weaponPreview;
    public GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        weaponPreview = Instantiate(prefabProjectile[0], transform.position + head.transform.forward, transform.rotation);
        weapon = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        playerAxis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 globalmove = transform.TransformDirection(playerAxis);//local pra global 
        charac.SimpleMove(globalmove * 5);
        playerRotAxis = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        headRotAxis = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);

        transform.Rotate(playerRotAxis);//gira o corpo
        head.transform.Rotate(headRotAxis);//gira cabeca

        if (Input.GetKey(KeyCode.Alpha1)) weapon = 1;
        if (Input.GetKey(KeyCode.Alpha2)) weapon = 2;
        if (Input.GetKey(KeyCode.Alpha3)) weapon = 3;

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject obj;
            if (weapon == 2) obj = Instantiate(prefabProjectile[weapon - 1], transform.position + head.transform.forward*3 + new Vector3(0, 0.5f, 0), transform.rotation);
            else obj = Instantiate(prefabProjectile[weapon-1], transform.position+head.transform.forward+new Vector3(0, 0.5f, 0), transform.rotation);
            /*obj.GetComponent<Rigidbody>().AddForce(head.transform.forward * 1000+ Vector3.up*200);
            obj.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.right*500, ForceMode.Impulse);
            Destroy(obj, 3);*/
            if (obj.GetComponent<guidedBomb>()) {
                obj.GetComponent<guidedBomb>().target = laserpoint;
            }
            if(weapon != 3) obj.GetComponent<Rigidbody>().AddForce(head.transform.forward * 1000);
            else obj.GetComponent<Rigidbody>().AddForce(head.transform.forward * 10);


        }

        if (Physics.Raycast(transform.position, head.transform.forward, out RaycastHit hit))
        {
            laserpoint.transform.position = hit.point;
        }
        else laserpoint.transform.position = transform.position + head.transform.forward * 1000;

    }
}
