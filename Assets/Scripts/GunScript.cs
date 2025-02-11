using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GunScript : MonoBehaviour
 {
    public GameObject player;
    private Camera cam;
    public float degreeChange = 40;
    public GameObject shoot;
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

        if (Input.GetMouseButton(0))
        {
            Instantiate(shoot, transform.position, transform.rotation);
        }
    }
}


