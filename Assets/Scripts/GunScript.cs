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
    public Rigidbody2D RB;
    public bool dead = false;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dead)
        {
            gameObject.transform.position = new Vector2(player.transform.position.x + 0.25f, player.transform.position.y + 0.25f);
            Vector3 mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(mousePos.y - player.transform.position.y, mousePos.x - player.transform.position.x);
            float deg = (180 / Mathf.PI) * angle;

            //gameObject.transform.rotation = Quaternion.Euler(0f, 0f, deg);
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.RotateAround(player.transform.position, Vector3.forward, deg - degreeChange);
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
                    float randomDeg = deg + Random.Range(-6.00f, 6.00f);
                    bulletScript.RB.linearVelocity = new Vector2(Mathf.Cos((randomDeg) * Mathf.Deg2Rad) * bulletSpeed, Mathf.Sin((randomDeg) * Mathf.Deg2Rad) * bulletSpeed);
                    //Debug.Log(deg);
                    playerScript.Push(deg);
                }
            }

            if (playerScript.dead)
            {
                Die();
            }
        }
    
    }

    public void Die()
    {
        dead = true;
        RB.freezeRotation = false;
        RB.AddTorque(300f);
        int sign = Random.Range(1, 2);
        if (sign == 2) sign = -1;
        RB.linearVelocity = new Vector2(Random.Range(1.0f, 3.0f) * sign, Random.Range(3.0f, 5.0f));
    }
}


