using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

public class OilAttackLogic : EnemyAttackController
{   
    // DO NOT PUT START() IN THIS SCRIPT
    // IT WILL OVERRIDE THE START FUNCITON IN PARENT CLASS
    public GameObject createOnDestroy;
    public AudioClip hitSound;
    
    public override void attackLogic(float damage, GameObject player)
    {   
        
        if(this.GetComponent<EnemyMainController>().health<=0){
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