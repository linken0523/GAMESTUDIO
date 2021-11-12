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
    public GameObject ProjectileTemplate;
    private HandyCoolDown AttackCoolDown;


    private bool hasAttacked;
    public AudioClip shootSound;

    void Start() {
        hasAttacked = false;
        AttackCoolDown = null;
    }

    public bool attack(float attackRange, float attackDamage,float AttackCoolDownTime)
    {   
        Vector3 playerPos = this.transform.position;
        Vector3 dir = transform.rotation * Vector3.forward;
        
        

        if (Input.GetMouseButtonDown(0)) {
            
        
            // calculate direction vector for projectile
            
            

            

            // instantiate projectile
            Vector3 bulletInsPos = transform.position + Vector3.up;
            GameObject bullet = Instantiate(ProjectileTemplate, bulletInsPos+2*transform.forward , transform.rotation);
            ProjectileManager bulletManage = bullet.gameObject.GetComponent<ProjectileManager>();
            bulletManage.setVelocity(dir);
            bulletManage.setDamage(attackDamage);
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
    }
}



