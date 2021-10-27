using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ProjectileManager : MonoBehaviour {
    public float speed;
    private Vector3 velocity;
    private float damage;
    public float pushForce = 200.0f;

    public float destroyRange = 20.0f ;
    private GameObject player;
    //public GameObject LightningEffect;
    void Start(){
        player= GameObject.Find("Player");
    }
    void Update() 
    {
        this.transform.position+=(speed/10 * velocity);
        projectileDestroy();
    }
    
    // setters (set when shooing)
    private void projectileDestroy(){
        Vector3 playerPos = player.transform.position;
        float distanceX = Mathf.Abs(transform.position.x - playerPos.x);
        float distanceZ = Mathf.Abs(transform.position.z - playerPos.z);
        if (distanceX > destroyRange ||
            distanceZ > destroyRange) 
            {
                Destroy(this.gameObject);
            }
    }
    public void setVelocity(Vector3 dir) { velocity = dir; }
    public void setDamage(float attackDamage) { damage = attackDamage; }
    public void setPushForce(float pushForce){ this.pushForce = pushForce; }
    // getters (for on collision enter to calculate damage)
    public Vector3 getVelocity() { return velocity; }
    public float getDamage() { return damage; }
    public float getPushForce() { return pushForce; }

}