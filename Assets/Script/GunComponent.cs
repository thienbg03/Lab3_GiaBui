using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float chargeSpeed = 10f;
    private float chargeTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Reset Charge Time when First Pressed
        if (Input.GetButtonDown("Fire1"))
        {
            chargeTime = 0;
        }
        //Update Charge Time With DeltaTime
        chargeTime += Time.deltaTime;
        if (Input.GetButtonUp("Fire1"))
        {
            //Make sure the value is only between 0 and 3
            chargeTime = Mathf.Clamp(chargeTime, 0, 3);
            // Spawn bullet when Fire1 is released
            //set bullet speed to the product of charge speed and charge Time
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            BulletComponent bulletComp = bullet.GetComponent<BulletComponent>();
            bulletComp.bulletSpeed = chargeTime * chargeSpeed;
        }
    }

}
