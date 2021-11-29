using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

public class PlayerAttackController : MonoBehaviour
{   /*
      this script dictates how player attacks
      
      functions called in attribute update:
       - attack()

      functions called in playerDetectEnemy.cs
       - enemyNearby
       - setDistanceToPlayer()
    */
    
    private HandyCoolDown AttackCoolDown;


    private bool hasAttacked;
    public AudioClip shootSound;
    public GameObject weaponOne;
    public GameObject weaponTwo;
    private int weaponNumber = 1;
    void Start() {
        hasAttacked = false;
        AttackCoolDown = null;
        weaponOne.SetActive(true);
        weaponTwo.SetActive(false);
        weaponNumber = 1;
    }

    public bool attack(float attackRange, float attackDamage,float AttackCoolDownTime)
    {   
        Vector3 playerPos = this.transform.position;
        Vector3 dir = transform.rotation * Vector3.forward;
        
        

        if (Input.GetMouseButtonDown(0)) {
            
        
            // calculate direction vector for projectile
            
            if(weaponNumber==1){
                weaponOne.GetComponent<FistGunLogic>().shoot(attackRange, attackDamage, dir, transform.forward, transform.rotation);
            }
            if(weaponNumber==2){
                weaponTwo.GetComponent<CannonLogic>().shoot(attackRange, attackDamage, dir, transform.forward, transform.rotation);
            }
            

            // instantiate projectile
            
            // set cool down, control player attack rate
            
            AttackCoolDown = new HandyCoolDown(AttackCoolDownTime, "Player Attack Cool Down");
            if (shootSound != null) 
            {
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
            }
            
        } else {hasAttacked = false; } // player did not press A

        return hasAttacked;
    }
    void Update() {
        // UPDATE() IS FOR COOL DOWN ONLY!!!
        if (AttackCoolDown != null)
        {   
            bool done = AttackCoolDown.check();
            if (done) {
                AttackCoolDown = null;
            }
        }
        if(Input.GetKeyDown(KeyCode.X)){
            weaponNumber+=1;
            if(weaponNumber==3){
                weaponNumber=1;
            }
            if(weaponNumber==1){
                weaponOne.SetActive(true);
                weaponTwo.SetActive(false);
            }
            if(weaponNumber==2){
                
                weaponOne.SetActive(false);
                weaponTwo.SetActive(true);
            }
        }
    }
}



