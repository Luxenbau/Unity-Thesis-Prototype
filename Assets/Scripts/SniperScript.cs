using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScript : MonoBehaviour
{

    public GameObject playerReference;
    public int health = 2;
    public GameObject deadSniper;
    private SpriteRenderer sniperSprite;
    // Start is called before the first frame update
    void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
        sniperSprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int TakeDamage(int x)
    {
        if (health >= 1)
        {
            Debug.Log(" Took damage");
            // coroutine used to insert a small delay for the color to change to display visual hit feedback
            StartCoroutine("DamageFeedback");
            health--;
            Debug.Log("Enemy is hit");
        }
        else
        {
            EnemyDeath(x);

            Destroy(this.gameObject);
        }

        return x;
    }

    IEnumerator DamageFeedback()
    {
        Debug.Log("In coroutine");
        sniperSprite.color = new Color32(145, 30, 30, 255);
        yield return new WaitForSeconds(0.1f);
        sniperSprite.color = new Color32(255, 255, 255, 255);
    }

    public int EnemyDeath(int direction)
    {
        GameObject sniperCorpse = Instantiate(deadSniper, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        return sniperCorpse.GetComponent<DeadEnemy>().GetDirectionOfHit(direction);
    }




}
