using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistGunLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ProjectileTemplate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shoot(float attackRange, float attackDamage, Vector3 dir, Vector3 playerPos, Quaternion playerRotation){
        Vector3 bulletInsPos = transform.position + Vector3.up;
        GameObject bullet = Instantiate(ProjectileTemplate, bulletInsPos+2*playerPos, playerRotation);
        ProjectileManager bulletManage = bullet.gameObject.GetComponent<ProjectileManager>();
        bulletManage.setVelocity(dir);
        bulletManage.setDamage(attackDamage);
    }
}
