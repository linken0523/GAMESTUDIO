using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnIfCollided : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itemObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "SceneObject"){
            
            Destroy(this.gameObject);
            Instantiate(itemObject, transform.position  - 3f* Vector3.right, Quaternion.identity);
        }
    }

}
