using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainController : MonoBehaviour
{
    public InventoryObject inventory;
    /////////////////////////Controllers//////////////////////
    private PlayerMoveController PlayerMove;
    private PlayerAttackController PlayerAttack;
    private PlayerAnimationController PlayerAnimation;

    ////////////////////////Public Attributes/////////////////////
    public float moveSpeed;
    public float health;
    public float AttackCoolDownTime;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMove = this.GetComponent<PlayerMoveController>();
        PlayerAttack = this.GetComponent<PlayerAttackController>();
        PlayerAnimation = this.GetComponent<PlayerAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {   
        bool attacked, moved, jumped, ran;//for animation
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
        if (PlayerAttack != null)
            {attacked = PlayerAttack.attack(0.0f, 1.0f, AttackCoolDownTime); }
    }

    public void OnTriggerStay(Collider other){
        var item = other.GetComponent<Item>();
        if(item){
            if(Input.GetKey(KeyCode.Q)){
                inventory.AddItem(item.item, 1);
                Destroy(other.gameObject);
            }
            
        }
    }
    private void OnApplicationQuit(){
        inventory.Container.Clear();
    }
    /*
    public void playerIsDamaged(float damage)
    {   // on enemy damage:
        // minus health, knock back, damage animation...
        // 1. minus health
        if (damage > health) { health = 0; }
        else 
        { 
            //gameObject.GetComponent<TimeStop>().StopTime();
            health -= damage;
            PlayerDamageManage.damageEffect();
        }
        // print("Player is damaged. Remaining HP: "+health.ToString());
        // 2. damage animation
        if ( PlayerAnimation != null) { PlayerAnimation.TakeDamage(); }
        // 3. health UI
    }*/
}
