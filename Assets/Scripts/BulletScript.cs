using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public float Speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      RB.linearVelocity = transform.right * Speed;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
