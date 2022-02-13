using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMoveScript : MonoBehaviour
{
    private Vector3 mousePos;

    private float distanceFromMouse;

    void Start()
    {
        
    }

    void Update()
    {
        //gets the transform.postion of the mouse
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // zero z

        //gets the distance from the mouse to use as the speed the object goes to the mouse
        distanceFromMouse = Vector3.Distance(transform.position, mousePos);

        //moves the object
        transform.position = Vector3.MoveTowards(transform.position, mousePos, distanceFromMouse * 3 * Time.deltaTime);
    }
}
