using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerCursor : MonoBehaviour
{
    public Transform newCursor, objectHit;
    [SerializeField] Image MouseAppearence;
    [SerializeField] Sprite Normal, Clickable;
    [SerializeField] Vector3 MousePosition;

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        MousePosition = Input.mousePosition;
        newCursor.position = new Vector3(MousePosition.x, MousePosition.y, 0);

        RaycastHit2D hit = Physics2D.Raycast(MousePosition, Vector2.zero);

        if (hit.collider != null) // single click
        {
            objectHit = hit.transform;
            // Do something with the object that was hit by the raycast.
            if (objectHit.GetComponent<ComputerEventHandlerScript>() != null)
            {
                MouseAppearence.sprite = Clickable;
            }
        } else
                {
                    MouseAppearence.sprite = Normal;
                }
        
        if (hit.collider != null && Input.GetButtonDown("Fire1")) // single click
        {
            objectHit = hit.transform;
            // Do something with the object that was hit by the raycast.
            if (objectHit.GetComponent<ComputerEventHandlerScript>() != null && objectHit.tag != "TopBar")
            {
                objectHit.GetComponent<ComputerEventHandlerScript>().VirtualMouseClick();
            }
        }

        if (hit.collider != null && Input.GetButton("Fire1") && newCursor.childCount == 0) // click and hold
        {
            objectHit = hit.transform;
            // Do something with the object that was hit by the raycast.
            if (objectHit.GetComponent<ComputerEventHandlerScript>() != null && objectHit.tag == "TopBar")
            {
                objectHit.GetComponent<ComputerEventHandlerScript>().VirtualMouseClickAndHold();
            }
        }
    }
}//EndScript