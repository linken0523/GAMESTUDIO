using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainController : MonoBehaviour
{
    public InventoryObject inventory;
    /////////////////////////Controllers//////////////////////
    private PlayerMoveController PlayerMove;
    private PlayerAnimationController PlayerAnimation;

    ////////////////////////Public Attributes/////////////////////
    public float moveSpeed;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMove = this.GetComponent<PlayerMoveController>();
        PlayerAnimation = this.GetComponent<PlayerAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {   
        bool moved, jumped, ran;//for animation
        if (PlayerMove != null)
            {   
                // check input arrow keys and space bar
                if(Input.GetKey(KeyCode.LeftShift)){
                    moved = PlayerMove.move(2*moveSpeed);
                    ran=true;
                }else{
                    moved = PlayerMove.move(moveSpeed);
                    ran=false;
                }
                jumped = PlayerMove.jump(jumpForce);
            }
        else { moved = false; jumped = false; ran=false;}
        ////Animations//////////////
        // if player has animation, do animation, based on what action player has done
            if (PlayerAnimation != null)
            {    
                if (moved) { 
                    if(ran){
                        PlayerAnimation.IdleToRun(); 
                        
                    }else{
                    PlayerAnimation.IdleToMove(); 
                    PlayerAnimation.RunToIdle();
                    }
                }
                else { PlayerAnimation.MoveToIdle(); 
                        PlayerAnimation.RunToIdle();}

                if (jumped) { PlayerAnimation.ToJump(); }
                else { PlayerAnimation.AfterJump(); }
            } 
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
    
}
