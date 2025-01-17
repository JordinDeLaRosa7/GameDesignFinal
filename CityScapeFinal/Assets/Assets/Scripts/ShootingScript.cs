﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
  public Transform FirePoint;
  public GameObject BulletPrefab;
  public int damage = 40;
  public GameObject impactEffect;

  float t;
  float f;
  bool autofire = true;
  public float autofiredelay = 0.1f;

    void Update()
    {
      // if (Input.GetButton("Fire1")){
      //   Shoot();
      // }

      if(Input.GetKey(KeyCode.Space)){
        if (autofire){
          if (t > 0){
            t -= Time.deltaTime;
          }else {
            Shoot();
            t = autofiredelay;
          }
        }
      }

    }

    void Shoot(){
      RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);
      if (hitInfo){
        //Debug.Log(hitInfo.transform.name);
        Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
        if (enemy != null){
          enemy.TakeDamage(damage);
        }

    }
      //Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
      //this shoots bullet, above code doesn't work.
      Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
