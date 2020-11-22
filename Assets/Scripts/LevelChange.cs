using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    private string levelName = "SecondScene";
    // Start is called before the first frame update
    void Start()
    {
      //  DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {            
            SceneManager.LoadScene(levelName);
            //collision.gameObject.GetComponent<PlayerController>().SpawnAtPoint();
        }
    }
}
