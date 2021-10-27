using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    private bool hasAttacked;
    public AudioClip shootSound;

    void Start() {
        hasAttacked = false;
        
    }

    public bool attack(float attackRange, float attackDamage,float AttackCoolDownTime)
    {   
        Vector3 playerPos = this.transform.position;
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        Vector3 dir = transform.forward;
        if(Physics.Raycast(rayOrigin, out hitInfo)){
            if(hitInfo.collider!=null){
                dir = (hitInfo.point - (transform.position + Vector3.up)).normalized;

            }
        }

        if (Input.GetMouseButtonDown(0)) {
            
        
            // calculate direction vector for projectile
            
            

            

            // instantiate projectile
            Vector3 bulletInsPos = transform.position + Vector3.up;
            GameObject bullet = Instantiate(ProjectileTemplate, bulletInsPos , Quaternion.identity);
            ProjectileManager bulletManage = bullet.gameObject.GetComponent<ProjectileManager>();
            bulletManage.setVelocity(dir);
            bulletManage.setDamage(attackDamage);
            
            
            if (shootSound != null) 
            {
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
            }
            
        } else {hasAttacked = false; } // player did not press A

        return hasAttacked;
    }
}



