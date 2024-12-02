using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] WeaponSO weapon;
    [SerializeField] ParticleSystem sparks;
    Camera cam;
    void Start()
    {
        cam = Camera.main;
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
        if (weapon.ammoAmount > 0)
        {
            RaycastHit hit;
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            Physics.Raycast(ray, out hit);
            weapon.Shoot();
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy") 
                {
                    hit.collider.GetComponent<Enemy>().OnShot(weapon.damage); 
                }
                else
                {
                    ParticleSystem sparksInstance = Instantiate(sparks,hit.point,hit.collider.transform.rotation);
                    Destroy(sparksInstance.gameObject,0.5f);
                }
                print(hit.collider.name);
            }
        }
        else
        {
            print("No ammo!");
        }
            yield return new WaitForSeconds(1 / weapon.fireRate);
    }
}
