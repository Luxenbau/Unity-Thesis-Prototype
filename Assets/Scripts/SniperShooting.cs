using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject spawnPoint;
    public GameObject player;
    public GameObject sniper;
    public float xPosition = 0f;
    public float yPosition = 0f;
    public float speed = 1f;
    private SpriteRenderer flip;
    private float delay;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        flip = this.GetComponent<SpriteRenderer>();
        sniper = GameObject.FindGameObjectWithTag("Sniper");
        delay = 1.5f;

        if (sniper.transform != null)
        {
            transform.position = new Vector3(sniper.transform.position.x + xPosition, sniper.transform.position.y + yPosition, transform.position.z);
        }
    }


    void Update()
    {
        if (player != null)
        {
            GunRotation();


            if ((sniper.transform.position.x - player.transform.position.x) < 15f)
            {
                delay -= Time.deltaTime;
                if (delay <= 0)
                {
                    Shoot();
                    delay = 1.5f;
                }
            }
        }
    }

    public void GunRotation()
    {
        Vector2 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        var a = new Vector3(0, 0, angle);
        a = transform.eulerAngles;
       // Debug.Log("Enemy rifle angle " + a);
        if (a.z >= 90 && a.z <= 270)
        {
            flip.flipY = true;
            xPosition = -0.1f;
        }
        else
        {
            flip.flipY = false;
            xPosition = 0.1f;
        }

    }


    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
        bullet.transform.right = transform.right;
    }

}
