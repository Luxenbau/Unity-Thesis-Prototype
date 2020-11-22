using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.x >= 200 || transform.position.y >=200)
        {
            Destroy(this.gameObject);
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            /*   int direction = 0;
               if (transform.position.x > collision.transform.position.x)
               {
                   direction = -1;
               }
               else
               {
                   direction = 1;
               } */

            int direction = GetDirection(collision);

            collision.gameObject.GetComponent<EnemyController>().TakeDamage(direction);
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Sniper")
        {
            int direction = GetDirection(collision);
            collision.gameObject.GetComponent<SniperScript>().TakeDamage(direction);
            Destroy(this.gameObject);


        }
        else
        {
            Debug.Log("Ignore the collision");
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<CapsuleCollider2D>());
        }

    }

    private int GetDirection(Collision2D collision)
    {
        int direction = 0;
        if (transform.position.x > collision.transform.position.x)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        return direction;
    }


}
