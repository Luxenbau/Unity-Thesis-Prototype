using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.x >= 200 || transform.position.y >= 200)
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
        else if (collision.gameObject.tag == "Player")
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
            collision.gameObject.GetComponent<PlayerController>().PlayerDeath(direction);
            Destroy(this.gameObject);

        }
        else
        {
            Debug.Log("Ignore the collision");
            
        }




    }
}
