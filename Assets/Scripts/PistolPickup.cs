using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolPickup : MonoBehaviour
{
    public GameObject pistolPrefab;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    Vector2 posOffset = new Vector2();
    Vector2 tempPos = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // spawn the pistol object as a child of the player object, destroy the pickup object.
            GameObject pistol = Instantiate(pistolPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity, collision.gameObject.transform);
            Destroy(this.gameObject);
            
        }
    }
}
