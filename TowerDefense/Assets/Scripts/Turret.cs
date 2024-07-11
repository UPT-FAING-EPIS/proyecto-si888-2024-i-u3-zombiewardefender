using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float range = 15f;

    public string enemyTag = "Enemy";
    public Transform partToRotate;

    public float fireRate = 1f;
    private float fireCountDown;

    public GameObject bulletPrefab;
    public Transform firePlace;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.25f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        //Turret Rotation
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;


        partToRotate.rotation = Quaternion.Euler(0f, rotation.y + 90f, 0f);

        //turret shoot
        if(fireCountDown < 0)
        {
            Shoot();
            fireCountDown = 1 / fireRate;
        }
        fireCountDown -= Time.deltaTime; 

    }

    public void Shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePlace.position, firePlace.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet .Seek(target);
    }

    public void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if (distToEnemy < shortestDistance)
            {
                shortestDistance = distToEnemy;
                nearestEnemy = enemy;

            }
        }

        if (nearestEnemy != null && shortestDistance <= range && nearestEnemy.GetComponent<Enemy>().isAlive)
        {
            target = nearestEnemy.transform;

        }
        else
        {
            target = null;
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
