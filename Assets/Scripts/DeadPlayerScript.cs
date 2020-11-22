using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPlayerScript : MonoBehaviour
{
    private Transform corpseTransform;
    private Rigidbody2D corpseRigidBody;
    public float yVelocity = 50f;
    public float xVelocity = 40f;
    public int hitDirection = 1;
   public  Sprite[] sprites;

    void Start()
    {
        corpseTransform = this.gameObject.transform;
        corpseRigidBody = this.GetComponent<Rigidbody2D>();
        corpseRigidBody.velocity = new Vector2(hitDirection* xVelocity, yVelocity);
        transform.localScale = new Vector2(hitDirection, 1);
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            // changes the corpse's sprite to the final version and sets the correct orientation.
            this.GetComponent<SpriteRenderer>().sprite = sprites[1];
            transform.localScale = new Vector2(hitDirection, 1);
            // coroutine with a timeout to restart the game after a set amount of seconds.
            StartCoroutine("RestartLevel");
        }
    }
    IEnumerator RestartLevel()
    {
        Debug.Log("You died. Game lost");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SampleScene");
    }

    public int GetDirectionOfHit(int x)
    {
        return this.hitDirection = x;
    }
}
