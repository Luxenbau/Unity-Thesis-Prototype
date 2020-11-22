using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject spawnPoint;
    public Transform playerTransform;
    public float xPosition = 0f;
    public float yPosition = 0f;
    public float speed = 1f;
    private SpriteRenderer flip;
    float scaleAngle;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // the variable that will store the pistol's spriterenderer component to access later the flip setting to flip the sprite when aiming backwards.
        flip = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerTransform != null)
        {
                 transform.position = new Vector3(playerTransform.position.x + xPosition, playerTransform.position.y +yPosition, transform.position.z);

        } else
        {
            Destroy(this.gameObject);

        } 

        PistolRotation();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

    }

    public void PistolRotation()
    {
        
        Vector2  dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var a =  new Vector3(0, 0, angle);
         a = transform.eulerAngles; 

        if (a.z >= 90 && a.z <=270 )
        {
           flip.flipY = true;
           xPosition = -0.1f;
        }
        else
        {
           flip.flipY = false;
           xPosition = 0.1f;
        }

        /*  Vector2 mousePos = Input.mousePosition;

          Vector2 pistolDirection = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
          transform.right = pistolDirection; */
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
        bullet.transform.right = transform.right;
    }

}
