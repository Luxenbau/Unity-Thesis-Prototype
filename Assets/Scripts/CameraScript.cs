using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerTransform;
    private List<GameObject> checkCamera = new List<GameObject>() ;

    // Start is called before the first frame update
    void Start()
    {     
        // check if camera already exists and destoy new ones.
        checkCamera.AddRange( GameObject.FindGameObjectsWithTag("MainCamera"));
        if (checkCamera.Count >1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y+4f, transform.position.z);
        }
        else if (GameObject.FindGameObjectWithTag("Player") != null)
        {
             
            playerTransform = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        }
            
    }
}
