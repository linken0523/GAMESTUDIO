using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject createOnDestroy;
    public AudioClip hitSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(transform.position.y<=0.06f){
            if (createOnDestroy != null) 
            {
                GameObject obj = Instantiate(this.createOnDestroy);
                obj.transform.position = this.transform.position;
            }
            
            if (hitSound != null) 
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
            }


        }
    } 
}
