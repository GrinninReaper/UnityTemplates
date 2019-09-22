using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMove : MonoBehaviour
{

    private Vector3 start;

    public float dragSpeed;

    // Update is called once per frame
    void Update()
    {
        DragMove(); //calling the function
    }

    private void DragMove(){
        if(Input.GetMouseButtonDown(0)){
            start = Input.mousePosition; //get the position of the mouse at the beginning of the click
            return;
        }

        if(!Input.GetMouseButton(0)){
            //make sure when not clicking you don't move
            return;
        }

        Vector3 end = Camera.main.ScreenToViewportPoint(Input.mousePosition - start); //calculating the vector you want to move
        Vector3 move = new Vector3(end.x*dragSpeed, 0, 0); //calculating the movement vector

        transform.Translate(move, Space.World); //move the object
    }

}