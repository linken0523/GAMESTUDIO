using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraScript : MonoBehaviour
{
    float rotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    

    
    void Start()
    {
        
    }

    private void Update()
    {   
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CamControl();
        
        
        //show cursor
        //else{
        //Cursor.visible=true;
        //Cursor.lockState = CursorLockMode.Confined;
        
        
    }
    

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -15, 30);

        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {   
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
            
        }
        
    }
    

}
