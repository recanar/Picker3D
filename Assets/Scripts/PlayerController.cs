using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float HorizontalInput { get; private set; }

    Rigidbody rb;
    GameManager gameManager;
    float speed;
    float horizontalMove;
    float limitMove = 3f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        speed = 7;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");//left-right movement input
        horizontalMove = HorizontalInput * speed;
        if (gameManager.currentState==State.Playing)
        {
            if (transform.position.x<-limitMove||transform.position.x>limitMove)
            {
                rb.velocity= new Vector3(0, 0, speed);
            }//if player reaches any side of limit, stop velocity for horizontal
            if (transform.position.x > limitMove && horizontalMove<0)
            {
                rb.velocity = new Vector3(horizontalMove, 0, speed);
            }//if player reach limit for right side only moves left
            if (transform.position.x < -limitMove && horizontalMove > 0)
            {
                rb.velocity = new Vector3(horizontalMove, 0, speed);
            }//if player reach limit for left side only moves right
            if (transform.position.x <= limitMove && transform.position.x >= -limitMove)
            {
                rb.velocity = new Vector3(horizontalMove, 0, speed);
            }//if stays middle can go any side
        }//move player
        else
        {
            rb.velocity = Vector3.zero;
        }//stop player
    }
}
