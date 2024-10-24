using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Camera cam;
    int damage = 10;
    float fireRate = 3;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(nameof(Shoot));
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(nameof(Shoot));
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            RaycastHit hit;
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            Physics.Raycast(ray, out hit);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy") hit.collider.GetComponent<Enemy>().OnShot(damage);
                print(hit.collider.name);
            }

            yield return new WaitForSeconds(1 / fireRate);
        }    
        
    }
}
