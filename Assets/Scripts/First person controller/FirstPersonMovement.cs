using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    Vector2 velocity;


    void Update()
    {
        float speedRun = speed;

        if(Input.GetKey(KeyCode.LeftShift))
            speedRun *= 2;
        
        velocity.y = Input.GetAxis("Vertical") * speedRun * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speedRun * Time.deltaTime;
        transform.Translate(velocity.x, 0, velocity.y);
    }
}
