using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    int playerDirection= 0;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    [Header("Current movement")]
    [SerializeField] private float forceY = 7f;
    [SerializeField] private float maxSpeed = 3f;
    [SerializeField] private float accelRate = 7f;


    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world coordinates
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the direction from the player's position to the mouse position
        Vector3 direction = worldMousePosition - transform.position;

        // Calculate the angle in degrees from the direction vector
        float angle =  (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 90;
        if (angle > 180) {
            angle = -90; 
        }
        if (angle < 180 && angle > 90)
        {
            angle = 90;
        }


        playerDirection = (int) ((((angle + 90) / 180) * 7.0f) -3.5f);
        anim.SetInteger("playerDirection", playerDirection);


        // Limit the angle to face towards left, right, and bottom of the screen
        angle = Mathf.Clamp(angle, -90f, 90f);

        // Rotate the player object to face the limited angle
        //  transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        MovePlayer();
    }


    private void MovePlayer() {

        float ySpeed = 0;
        if (playerDirection >= 0) {
            ySpeed = 3 - playerDirection;
        } else {
            ySpeed = 3 - -playerDirection;
        }
        ySpeed = ySpeed / 3.0f;

        float ySpeedDiff = (maxSpeed * ySpeed) + rb.velocity.y;
        forceY = ySpeedDiff * accelRate;

        float xSpeed = playerDirection / 3.0f;
        if (xSpeed >= 1 || xSpeed <= -1) {
            xSpeed = 0;
        }
        float xSpeedDiff = (maxSpeed * xSpeed) - rb.velocity.x;
        float forceX = xSpeedDiff * (accelRate);

        rb.AddForce((forceX * Vector2.right) + (forceY * Vector2.down));
    }
}
