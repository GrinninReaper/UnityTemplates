using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScpawner : MonoBehaviour
{
    private float time = 0.0f;

    public float delay; //the delay between each obstacle
    public GameObject platform; //the prefab of the platform you wwantto add 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time > delay){
            createObstacle();
        }

        time += Time.deltaTime;
    }

    //function to create the obstacles
    private void createObstacle(){
        Debug.Log("Creating obstacle");
        GameObject newPlatform = Instantiate(platform);
        randomize(newPlatform);
        time = 0.0f;
    }

    //function to randomize the creation
    private void randomize(GameObject platform){
        Vector3 addedSliding = new Vector3(Random.Range(-1.5f, 1.5f), 0, 0);
        platform.transform.position = platform.transform.position + addedSliding;
    }
}
