using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 initPos;

    public float speed = 10f;
    public int index = 0;

    public Animator anim;

    public float HP = 50;
    public float actualHP;
    public bool isAlive = true;


    private GameManager gameManager;

    // Evento para notificar cuando el enemigo es destruido
    public event System.Action OnEnemyDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        /*initPos = Waypoints.route_0[0].position;
        index = 0;*/

        if (Waypoints.route_0 != null && Waypoints.route_0.Length > 0)
        {
            initPos = Waypoints.route_0[0].position;
        }
        else
        {
            Debug.LogError("Waypoints.route_0 is not initialized or is empty");
            return;
        }

        actualHP = HP;

        //anim = transform.GetChild(0).GetComponent<Animator>();

        anim.SetBool("isWalking", true);
        RotateTo();


    }

    // Update is called once per frame
    void Update()
    {
        /*if (!isAlive)
        {
            return;
        }*/
        if (!isAlive || Waypoints.route_0 == null || Waypoints.route_0.Length == 0)
        {
            return;
        }
        if (index >= Waypoints.route_0.Length)
        {
            Destroy(this.gameObject);
            // Take a life;
            FindObjectOfType<GameManager>().TakeALife();
            return;
        }



        transform.position = Vector3.MoveTowards(transform.position, Waypoints.route_0[index].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, Waypoints.route_0[index].position) < 0.25f)
        {
            index++;
            /*RotateTo();*/
            if (index < Waypoints.route_0.Length)
            {
                RotateTo();
            }
        }


        /*if (index >= Waypoints.route_0.Length)
        {
            Destroy(this.gameObject);
            //Take a life;
            FindObjectOfType<GameManager>().TakeALife();
        }*/

    }

    /*private void OnMouseDown()
    {
        Destroy(this.gameObject);
    }*/

    public void RotateTo()
    {
        /*Vector3 target = Vector3.zero;*/

        if (index >= Waypoints.route_0.Length)
        {
            return;
        }

        Vector3 target = Waypoints.route_0[index].position;



        /*target = Waypoints.route_0[index].position;*/

        if (Mathf.Abs(target.x - transform.position.x) > 0.4f)
        {
            if (target.x > transform.position.x)
            {
                transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 90f, 0);
            }
            else
            {
                transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 270f, 0);

            }
        }
        else
        {
            if (Mathf.Abs (target.z - transform.position.z) > 0.4f)
            {
                if (target.z > transform.position.z)
                {
                    transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0f, 0);
                }
                else
                {
                    transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 180f, 0);
                }
            }
        }
    }

    public void TakeHit(float damage)
    {
        if (!isAlive)
        {
            return;
        }

        actualHP -= damage;
        if (actualHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isAlive = false;
        anim.SetBool("isWalking", false);
        anim.SetBool("isDead", true);
        Destroy(this.gameObject, 3f);

        //Add earnings
        FindObjectOfType<GameManager>().money += 5;

        // Incrementar el contador de enemigos destruidos
        gameManager.enemiesDestroyed++;

        Debug.Log(gameManager.enemiesDestroyed);

        gameManager.UpdateEnemiesDestroyedText();

        //SFX
        FindObjectOfType<AudioManager>().Play("ZombiemanScream");

        if (OnEnemyDestroyed != null)
        {
            OnEnemyDestroyed();
        }

    }

    void OnDestroy()
    {
        // Llama a la función UpdateMoneyText cuando el enemigo sea destruido
        if (gameManager != null)
        {
            gameManager.AddMoney(5); 
        }
    }

}

