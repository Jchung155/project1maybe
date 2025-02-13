using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D RB;
    public float speed;
    public float jumpSpeed;
    public bool dead = false;
    public float pushSpeed = 2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if(!dead){
        //Vector2 vel = new Vector2(0,RB.linearVelocity.y);
     
        if (Input.GetKeyDown(KeyCode.D))
        {
                //vel.x = speed;
               // RB.linearVelocity = new Vector2(RB.linearVelocityX + speed, RB.linearVelocityY);
                //GetComponent<SpriteRenderer>().flipX = false;
        }
        
        if (Input.GetKeyUp(KeyCode.D))
        {
             
                //RB.linearVelocity = new Vector2(RB.linearVelocityX - speed, RB.linearVelocityY);
                
        }

            if (Input.GetKey(KeyCode.A))
        {
            //vel.x = -speed;
            //GetComponent<SpriteRenderer>().flipX = true;
        }    
        if (Input.GetKey(KeyCode.Space) && RB.linearVelocity.y == 0)
        {
            //vel.y = jumpSpeed;
        }
        
        //Debug.Log(RB.velocity.y);
        //float angle = Vector3.Angle(transform.position, Input.mousePosition);
        //Debug.Log(angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hazard") && !dead) Die();
    }

    public void Die(){
    dead = true;
    transform.position = new Vector3(transform.position.x, transform.position.y, 20);

    Debug.Log("Dead");

    }

    public void Push(float deg)
    {
        Debug.Log(deg);
        RB.linearVelocity = new Vector2(Mathf.Cos((deg-180) * Mathf.Deg2Rad) * pushSpeed, Mathf.Sin((deg-180) * Mathf.Deg2Rad) * pushSpeed);
        Debug.Log(RB.linearVelocity.x);
    }
}
