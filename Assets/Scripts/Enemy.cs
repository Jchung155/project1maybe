using UnityEngine;

public class Enemy : MonoBehaviour
{

public float speed;
public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
       transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            transform.gameObject.tag = "Untagged";
            Destroy(this.gameObject);
        }
    }
}
