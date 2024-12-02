using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponControl2 : MonoBehaviour
{
    Camera cam;
    [SerializeField] int damage = 10;
    [SerializeField] float fireRate = 2;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            StartCoroutine(Shoot());
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        if (hit.collider != null) 
        {            
            print(hit.collider.name);
            if (hit.collider.tag == "Enemy")
            {
                hit.collider.GetComponent<Enemy>().OnShot(damage);
            }
        }

        yield return new WaitForSeconds(1/fireRate);
    }
}
