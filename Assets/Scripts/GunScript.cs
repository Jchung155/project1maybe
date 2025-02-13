using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GunScript : MonoBehaviour
 {
    public GameObject player;
    private Camera cam;
    public float degreeChange = 40;
    public GameObject bullet;
    public GameObject muzzle;
    public float lastShotTime;
    public float shotDelay = 0.01f;
    public PlayerController playerScript;
    public BulletScript bulletScript;
    public float bulletSpeed = 2f;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.position = new Vector2(player.transform.position.x+1, player.transform.position.y+1);
        Vector3 mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - player.transform.position.y, mousePos.x - player.transform.position.x);
        float deg = (180 / Mathf.PI) * angle;

        //gameObject.transform.rotation = Quaternion.Euler(0f, 0f, deg);
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        transform.RotateAround(player.transform.position, Vector3.forward, deg-degreeChange);
        //muzzle.Rotate = Quaternion.Euler(0, 0, deg);

        if (Input.GetMouseButton(0))
        {   
            if (Time.time >= lastShotTime)
            {
                //add the current time to the button delay
                lastShotTime = Time.time + shotDelay;
                //Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, deg)).RB.linearVelocity = new Vector2(Mathf.Cos((deg)*Mathf.Deg2Rad)*bulletSpeed, Mathf.Sin((deg)*Mathf.Deg2Rad)*bulletSpeed);
                GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, deg)) as GameObject;
                bulletScript = newBullet.GetComponent<BulletScript>();
                bulletScript.RB.linearVelocity = new Vector2(Mathf.Cos((deg)*Mathf.Deg2Rad)*bulletSpeed, Mathf.Sin((deg)*Mathf.Deg2Rad)*bulletSpeed);
                playerScript.Push(deg);
            }
        }

    
    }
}


