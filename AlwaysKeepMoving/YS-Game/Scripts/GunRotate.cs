using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    Transform shoulderLocation;

    

    // Update is called once per frame
    void Update()
    {
        shoulderLocation = GameObject.FindGameObjectWithTag("ShoulderTransform").transform;
        Vector2 target = new Vector2(shoulderLocation.position.x, shoulderLocation.position.y);
        transform.position = target;

        Vector3 mousepos = Input.mousePosition;
        Vector3 gunposition = Camera.main.WorldToScreenPoint(transform.position);
        mousepos.x = mousepos.x - gunposition.x;
        mousepos.y = mousepos.y - gunposition.y;
        float gunangle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg - 270f;
        //float gunangle1 = Mathf.Atan2(mousepos.y - 50, mousepos.x + 50) * Mathf.Rad2Deg - 270f;
        //float gunangle2 = Mathf.Atan2(mousepos.y - 50, mousepos.x + 50) * Mathf.Rad2Deg - 270f;

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
        {
            Debug.Log("gun is backwards");
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, gunangle));
        }
        else
        {
            
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, gunangle));
        }
    }
}
