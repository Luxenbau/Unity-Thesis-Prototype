using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 4f;
    public Rigidbody2D playerRigidBody;
    public float jumpHeight = 10f;
    private Collider2D playerCollider;
    [SerializeField] private LayerMask groundLayer;
    public bool pistol = false;
    public GameObject deadPrefab;
    private GameObject spawnPoint;
        

    // Start is called before the first frame update
    void Start()
    {
        SpawnAtPoint();
        DontDestroyOnLoad(this.gameObject);
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal");
        if (horizontalSpeed < 0)
        {
            playerRigidBody.velocity = new Vector2(-(playerSpeed), playerRigidBody.velocity.y);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (horizontalSpeed > 0)
        {
            playerRigidBody.velocity = new Vector2(+(playerSpeed), playerRigidBody.velocity.y);
            //transform.localScale = new Vector2(1, 1);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            playerRigidBody.velocity = new Vector2(0, playerRigidBody.velocity.y);
        }
        // allows jumping when space is pressed and prevents getting stuck in walls.
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(playerRigidBody.velocity.y) < .001f)
        {
                Jump();
        }
    }

    // method called to spawn the player's object at the starting point
    public void SpawnAtPoint()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("StartPoint");
        this.gameObject.transform.position = spawnPoint.transform.position;
    }
    private void Jump()
    {
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpHeight);
        // playerRigidBody.AddForce(new Vector2(0f, 50f), ForceMode2D.Impulse);
        Debug.Log("in jumping part");  
    }
   
    public int PlayerDeath(int direction)
    {
        if (direction != 0)
        {
            GameObject playerCorpse =  Instantiate(deadPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            playerCorpse.GetComponent<DeadPlayerScript>().GetDirectionOfHit(direction);
            Destroy(this.gameObject);
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
