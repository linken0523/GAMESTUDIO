using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOilCanScript : MonoBehaviour
{
    public GameObject itemObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {   

        if(Input.GetKeyDown(KeyCode.F)){
            
            dropItem();
            
        }
    }
    
    public void dropItem(){

        if(Placeable(itemObject, transform.position +3f*Vector3.up - 1.7f* transform.forward)){
            Instantiate(itemObject, transform.position +1.5f*Vector3.up - 1.7f* transform.forward, transform.rotation*Quaternion.Euler (-90f, 0f, 0f));
        }else{
            print("there is already objects on map");
        }
        

    }
    bool Placeable(GameObject prefab, Vector3 position) {
 
        float radius;
    
        
        radius = 0.9f;
    
        var hitColliders = Physics.OverlapSphere(position, radius);
        print(hitColliders);
        //If there are no colliders overlapping, this area is placeable.
        return hitColliders.Length == 0;
   
    }
}
