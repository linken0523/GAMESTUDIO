using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageManage : MonoBehaviour
{   
    public GameObject createOnDamaged;

    public AudioClip shootSound;
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Damage"){ // player projectile
            ProjectileManager bullet = other.gameObject.GetComponent<ProjectileManager>();
            float pushForce = bullet.getPushForce();
            float damage = bullet.getDamage();
            Vector3 dir = bullet.getVelocity();
            
            this.GetComponent<EnemyMainController>().enemyIsDamaged(pushForce, damage, dir);

            Destroy(other.gameObject);
            

            
            if (createOnDamaged != null)
            {
                GameObject obj = Instantiate(this.createOnDamaged, transform.position + 1.5f *Vector3.up , Quaternion.identity);
            }
            
            if (shootSound != null) 
            {
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
            }

            //Renderer rend = GetComponent<Renderer> ();
            //rend.material.color = Color.Lerp(rend.material.color, Color.black, .5f);
        }
    }
}