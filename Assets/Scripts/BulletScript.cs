using UnityEngine;
using UnityEngine.Audio;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public float Speed = 2f;
    public float destroyTime = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Test stuff
        //RB.linearVelocity = new Vector2(Mathf.Cos((transform.eulerAngles.z)*Mathf.Deg2Rad)*Speed, Mathf.Sin((transform.eulerAngles.z)*Mathf.Deg2Rad)*Speed);
        //RB.linearVelocity = transform.right * Speed;  

        float size = Random.Range(0.20f, 0.40f);
        transform.localScale = new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
