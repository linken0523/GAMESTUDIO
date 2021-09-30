using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainController : MonoBehaviour
{
    public InventoryObject inventory;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move(moveSpeed);
    }

    public void OnTriggerEnter(Collider other){
        var item = other.GetComponent<Item>();
        if(item){
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }
    private void OnApplicationQuit(){
        inventory.Container.Clear();
    }
    public bool move(float Speed)
    {
       if (Input.GetKey(KeyCode.W)
           || Input.GetKey(KeyCode.S)
           || Input.GetKey(KeyCode.A)
           || Input.GetKey(KeyCode.D))
        {
            Vector3 playerMovement = new Vector3(0f, 0f, 0f) ;
        
            if(Input.GetKey(KeyCode.W)){
                playerMovement += new Vector3(0f, 0f, 1f);
            }
            if(Input.GetKey(KeyCode.S)){
                playerMovement += new Vector3(0f, 0f, -1f);
            }
            if(Input.GetKey(KeyCode.D)){
                playerMovement += new Vector3(1f, 0f, 0f);
            }
            if(Input.GetKey(KeyCode.A)){
                playerMovement += new Vector3(-1f, 0f, 0f);
            }

            transform.Translate(playerMovement.normalized * Speed * Time.deltaTime);
            return true;
        }else{
            return false;
        }
    }
}
