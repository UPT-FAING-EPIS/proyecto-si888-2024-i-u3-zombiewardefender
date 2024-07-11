using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed = 70f;

    public float damage = 20f;

    public void Seek (Transform _target)
    {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        { 
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance (transform.position, target.position) <= 0.25f )
        {
            HitTarget(damage);
        }
    }

    public void HitTarget(float _damage)
    {
        target.GetComponent<Enemy>().TakeHit(_damage);
        Destroy(this.gameObject);
    }
}
