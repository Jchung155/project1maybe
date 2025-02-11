using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D RB;
    public float speed;
    public float jumpSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
        Debug.Log(angle);
    }
}
