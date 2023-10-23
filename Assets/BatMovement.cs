using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class BatMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 lastVelocity;
    public float speed = 150; //150 is the base speed, if you want, you can go up from there
    float X_direction;
    float Y_direction;

    float lastVal;

    float start_time;
    float time_elapsed;
    float bat_expiration_time = 10;

    [SerializeField] GameObject Boundries;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        Initial_Movement();
        lastVal = transform.position.x;
        start_time = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
       //Debug.Log("speed =" + rb.velocity.magnitude);
        lastVelocity = rb.velocity;
        Debug.Log("time elapsed =" + time_elapsed);
        time_elapsed = Time.time - start_time;
        //for checking if it's time for the bat to fly away
        if (time_elapsed > bat_expiration_time)
        {
            FlyAway();  
        }
            
            
        

        //for changing the face of the sprite (animation)
        if(transform.position.x > lastVal)
        {
            SwitchSpriteFace("right");
        }
        else if(transform.position.x < lastVal)
        {
            SwitchSpriteFace("left");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BounceOfWalls(collision);
    }

    private void Initial_Movement()
    {

       X_direction = Random.Range(-1f,1f);
       Y_direction = Random.Range(-1f,1f);

        if (X_direction == 0.0 && Y_direction == 0.0)
        {
            X_direction = 1;
        }
       
        Vector2 push = new Vector2(X_direction, Y_direction).normalized; // adding normalized here will disregard the values
                                                                         // and the speeed of the object will always be the speed variable
                                                                         // but with different direction
        rb.AddForce(push*speed);

    }

    private void BounceOfWalls(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0.0f);
    }

    private void  FlyAway()
    {
       
        
        this.gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
        
       
        Vector2 up = new Vector2(0,1);
        float up_power = 3;
        rb.AddForce(up * up_power );


        if(Mathf.Abs(transform.position.y) > Boundries.transform.position.y || Mathf.Abs(transform.position.x) > Boundries.transform.position.x)
       {
          this.gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
            GetComponent<SpawnBat>().KillBat_API();
        }
        
    }

    private void SwitchSpriteFace(string facing_side)
    {

        if(facing_side == "right")
        {
            GetComponent<SpriteRenderer>().flipX = true;
            lastVal = transform.position.x;
        }
        else if(facing_side == "left")
        {
            GetComponent<SpriteRenderer>().flipX = false;
            lastVal = transform.position.x;
        }

 
    }

    
   
}
