using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;

    private bool movingRight = true;

    public Transform groundDetection;
    public float lineLength = 1f;
    public GameObject playerReference;
    public int health = 3;
    public GameObject deadEnemy;
    private SpriteRenderer enemySprite;

    void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
        enemySprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetection.position, Vector2.down, lineLength);

        if (groundCheck.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

        
    }
    // the method that is called when the bullet hits the enemy, substracting the health.
    public int TakeDamage(int x)
    {    
        if (health>=1)
        {
            Debug.Log(" Took damage");
            // coroutine used to insert a small delay for the color to change to display visual hit feedback
            StartCoroutine("DamageFeedback");
            health--;
            Debug.Log("Enemy is hit");
        } else
        {
            EnemyDeath(x);
            Destroy(this.gameObject);
        }

        return x;
    }

    IEnumerator DamageFeedback()
    {
        Debug.Log("In coroutine");
        enemySprite.color = new Color32(145, 30, 30, 255);
        yield return new WaitForSeconds(0.1f);
        enemySprite.color = new Color32(255, 255, 255, 255);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // direction variable will be used to determine the corpse's flying direction, -1 to the left, 1 to the right.
        int direction = 0;
        if (collision.gameObject.tag == "Player")
        {
       
            if (transform.position.x > collision.transform.position.x)
            {
                Debug.Log("Player is colliding on left side");
                direction = -1;
            }
            else
            {
                Debug.Log("Player is colliding on right side");
                direction = 1;
            }

            playerReference.GetComponent<PlayerController>().PlayerDeath(direction);

        }
        else if (collision.gameObject.tag == "PlayerCorpse")
     // else
        {

            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>());
        }


    }

    public int EnemyDeath(int direction)
    {     
            GameObject enemyCorpse = Instantiate(deadEnemy, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            return enemyCorpse.GetComponent<DeadEnemy>().GetDirectionOfHit(direction); 
    }

}
