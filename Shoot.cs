using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bulletPrefab; //prefab of the bullet 
	public Transform bulletSpawn; /*position you want to make the bullet appear
                                    this migth depend on the position of your gun*/ 
    public AudioClip bang; //audio clip of the shoot
	public float vol = .5f; //volume of the sound fx

    public float zoomNormal; //zoom value when not aiming
	public float zoomAim; //zoom value when aiming
	public int smooth = 5; //speed of the transition

	public float fireRate; 
	private AudioSource source;
	private float nextFire;

    Camera playerCam;
	Animator anim;

	void Awake(){
		anim = GetComponent <Animator> (); //animator of the player
		source = GetComponent<AudioSource>(); //audio source attached to the player
        playerCam = (Camera) GameObject.Find("Main Camera").GetComponent(typeof(Camera));
	}

     // Start is called before the first frame update
    void Start()
    {
		nextFire = Time.time;
    }

    void Update(){
        /* add a boolean named holdingGun to the animator for a situation in which you are holding a gun */
        if(anim.GetBool("holdingGun")){
            //commands when holding a gun
            //Aiming
            if(Input.GetMouseButtonDown(1)){
                anim.SetBool("aiming", true);
                Aim(0); //zooming in 
            }
            if(Input.GetMouseButtonUp(1)){
                anim.SetBool("aiming", false);
                Aim(1); //zooming out
            }
            //Shooting
            if(Input.GetMouseButtonDown(0) && Time.time >= nextFire){
				nextFire += fireRate;
				var bullet = (GameObject) Instantiate(
					bulletPrefab,
					bulletSpawn.position,
					bulletSpawn.rotation
				);
				source.PlayOneShot(bang, vol);
				bullet.GetComponent<Rigidbody>().velocity = transform.right * -25; //modify the speed accordingly to your game
				Destroy(bullet, 1.0f); //modify the life time in the function
			}
        }
    }

    public void Aim(int cmd){
        /*function to zoom in and out when aiming
        modify the */
		switch(cmd){
			case 0:
				//zooming in
				playerCam.fieldOfView = Mathf.Lerp(playerCam.fieldOfView, zoomAim, Time.deltaTime+smooth);
				break;
			case 1:
				//zooming out
				playerCam.fieldOfView = Mathf.Lerp(playerCam.fieldOfView, zoomNormal, Time.deltaTime+smooth);
				break;
		} 
	}
}
