using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using static UnityEngine.GraphicsBuffer;

public class CrosshairMovement : MonoBehaviour
{
    [SerializeField]
    Animator crosshair_animater;

    bool onTarget = false;
    private void Start()
    {
        
        transform.position = new Vector2(0, 0);
        Cursor.visible = false;
    }
    private void Update()
    {
        // Get the mouse position in screen coordinates
        Vector2 mousePosition = Input.mousePosition;

        // Convert the mouse position to world coordinates
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Set the crosshair's position to the mouse position
        transform.position = worldMousePosition;

     

       if(onTarget)
        {
            
        }
       else if(!onTarget)
        {
          
        }
        if (onTarget == true)
        {
            onTarget = false;
        }



    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        crosshair_animater.SetBool("onTarget", true);


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        crosshair_animater.SetBool("onTarget", false);
    }



}
