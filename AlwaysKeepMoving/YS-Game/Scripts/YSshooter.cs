using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSshooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform start;

    // Update is called once per frame
    void Update()
    {
        Vector3 gunpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(gunpos.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }

        
    }

   
}
