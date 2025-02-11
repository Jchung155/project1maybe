using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D RB;
    public float speed;
    public float jumpSpeed;
    public bool dead = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if(!dead){
        Vector2 vel = new Vector2(0,RB.linearVelocity.y);
     
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = speed;
            //GetComponent<SpriteRenderer>().flipX = false;
        }
      
        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -speed;
            //GetComponent<SpriteRenderer>().flipX = true;
        }    
        if (Input.GetKey(KeyCode.Space) && RB.linearVelocity.y == 0)
        {
            vel.y = jumpSpeed;
        }
        RB.linearVelocity = vel;
        //Debug.Log(RB.velocity.y);
        float angle = Vector3.Angle(transform.position, Input.mousePosition);
        //Debug.Log(angle);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hazard") && !dead) Die();
    }

    public void Die(){
    dead = true;
    transform.position = new Vector3(transform.position.x, transform.position.y, 20);

    Debug.Log("Dead");

    }
}
