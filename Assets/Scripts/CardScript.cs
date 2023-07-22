using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    [SerializeField] GameObject Card;
    [SerializeField] Camera myMainCamera;
    Vector3 offset;
    Plane dragPlane;
    bool mouseDown = false;

    void OnMouseDown()
    {
        mouseDown = true;
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position); 
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist); 
        offset = transform.position - camRay.GetPoint(planeDist);
    }
    void OnMouseDrag()
    {   
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + offset;
    }

    void OnMouseUp()
    {
        mouseDown = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!mouseDown)
        {
            print(other.name);
        }
        print(other.name);
    }
}
