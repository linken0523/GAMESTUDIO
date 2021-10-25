using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRotationScript : MonoBehaviour
{   
    // 8 orientations
    // if forward = facing North
    // orientations are N, NE, E, SE, S, SW, W, NW
    private float faceOrientation;
    private float facingN;
    private float facingNE; // up + right
    private float facingE; // right
    private float facingSE; // right + down
    private float facingS; // down
    private float facingSW; // down + left
    private float facingW; // left
    private float facingNW; // left + up
    private float rotation;

    private float rotateSpeed = 5f;
    // Start is called before the first frame update
    public GameObject parent;
    void Start()
    {
        defineOrientation();
        rotation = facingN; // default to face north at start
        
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
        
    }
    void defineOrientation()
    {
        facingN = 0f;
        facingNE = 45f;
        facingE = 90f;
        facingSE = 135f;
        facingS = 180f;
        facingSW = 225f;
        facingW = 270f;
        facingNW = 315f;
    }
    float determineRotation()
    {

        faceOrientation = transform.localEulerAngles.y;


        if(Input.GetMouseButton(0)){
            return facingN-faceOrientation;
        }
        // strange case of pressing two together...
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
           if (Input.GetKey(KeyCode.S)) {
               return facingS - faceOrientation;
           }
            
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {   // if getting normal inputs up right left input(s)

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {   // NE = up + right
                return facingNE - faceOrientation;
            }

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {   // SE = right + down
                return facingSE - faceOrientation;
            }

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {   // SW = down + left
                return facingSW - faceOrientation;
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {   // NW = left + up

                return facingNW - faceOrientation;
            }

            if (Input.GetKey(KeyCode.D))
            {   // E = right
                return facingE - faceOrientation;
            }

            if (Input.GetKey(KeyCode.A))
            {   // W = left
                return facingW - faceOrientation;
            }

            if (Input.GetKey(KeyCode.S))
            {   // S = down
                return facingS - faceOrientation;
            }
        }

        if (Input.GetKey(KeyCode.W)) {
            return facingN - faceOrientation;
        }

        // if no arrow key input
        return 0f; // no rotation
    }
    public void rotate() {


        rotation = determineRotation();
        
       
        if (rotation != 0) 
        { 
            if (rotation > 180 || rotation < -180) {
                transform.Rotate(0, Time.deltaTime * rotateSpeed * -rotation, 0, Space.Self); 
            } else {
                transform.Rotate(0, Time.deltaTime * rotateSpeed * rotation, 0, Space.Self);
            }
        }
    }
}
