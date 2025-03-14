using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D RB;
    public Collider2D Collider;
    public float speed;
    public float jumpSpeed;
    public bool dead = false;
    public float pushSpeed = 2f;
    public Vector2 pushVel;
    public Vector2 vel;
    public float xResistance;
    public float yResistance;
    private Vector2 finalVel;
    public float maxSpeedX;
    public float maxSpeedY;
    public float torque = 20;
    public float currentCapacity;
    public float maxCapacity = 3000f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCapacity = maxCapacity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!dead){
         vel = new Vector2(0,0);
     
        if (Input.GetKey(KeyCode.D))
        {
                vel.x = speed;
               // RB.linearVelocity = new Vector2(RB.linearVelocityX + speed, RB.linearVelocityY);
                //GetComponent<SpriteRenderer>().flipX = false;
        }
        

            if (Input.GetKey(KeyCode.A))
        {
            vel.x = -speed;
            GetComponent<SpriteRenderer>().flipX = true;
        }    
        if (Input.GetKey(KeyCode.Space) && RB.linearVelocity.y == 0)
        {
            vel.y = jumpSpeed;
        }

            //Debug.Log(RB.velocity.y);
            //float angle = Vector3.Angle(transform.position, Input.mousePosition);
            //Debug.Log(angle);

            finalVel = RB.linearVelocity;

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                finalVel.x += vel.x;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                finalVel.y += vel.y;
            }

            if (Input.GetMouseButton(0) && currentCapacity > 0)
            {
                finalVel += pushVel;
            } else pushVel = Vector2.zero;
            

          //  if (!((Input.GetKey(KeyCode.D) || Input.GetMouseButton(0) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Space))))
          // {
          //      finalVel = RB.linearVelocity;
          //  }
           
            if(finalVel.x > 0)
            {
                finalVel.x -= xResistance;
            }
            if(finalVel.x < 0)
            {
                finalVel.x += xResistance;
            }
            if(finalVel.y > -8)
            {
                finalVel.y -= yResistance;
            }

            
            if(finalVel.x > maxSpeedX) finalVel.x = maxSpeedX;
            if(finalVel.x < -maxSpeedX) finalVel.x = -maxSpeedX;
            if(finalVel.y > maxSpeedY) finalVel.y = maxSpeedY;
            if(finalVel.y < -maxSpeedY) finalVel.y = -maxSpeedY;

            RB.linearVelocity = finalVel;
            
            
            //if we wanted to make a system for acceleration, simply set max velocity values for x and y, make movement velocity based but make push acceleration based and change the acceleration amount by the push vector. Using acceleration may solve your gravity problem.
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hazard") && !dead) Die();
        if (other.gameObject.CompareTag("Refill"))
        {
            refillTank();
            Destroy(other.gameObject);
        }
    }

    public void Die(){
    dead = true;
    //transform.position = new Vector3(transform.position.x, transform.position.y, 20);

    Debug.Log("Dead");
    Collider.isTrigger = true;
    RB.freezeRotation = false;
        RB.AddTorque(torque);
        int sign = Random.Range(1, 2);
        if (sign == 2) sign = -1;         
        RB.linearVelocity = new Vector2(Random.Range(1.0f, 3.0f)*sign, Random.Range(3.0f,5.0f));

    }

    public void Push(float deg)
    {
        Debug.Log(deg);
        pushVel = new Vector2(Mathf.Cos((deg-180) * Mathf.Deg2Rad) * pushSpeed, Mathf.Sin((deg-180) * Mathf.Deg2Rad) * pushSpeed);
        Debug.Log(RB.linearVelocity.x);
    }

    public void refillTank()
    {
        currentCapacity = maxCapacity;
    }
}
