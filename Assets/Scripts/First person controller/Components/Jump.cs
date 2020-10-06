using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    GroundCheck groundCheck;
    Rigidbody rigidbody;
    public float jumpStrength = 2;
    public event System.Action Jumped;


    void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (!groundCheck)
            groundCheck = GroundCheck.Create(transform);
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
        {
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
        }

        if (Input.GetButtonDown("Jump") && GameManager.Instance.IsUnderwater)
        {

            StartCoroutine(coroutineGravity());
            rigidbody.AddForce(Vector3.up * 50 * jumpStrength);
            Jumped?.Invoke();
        }

    }

    IEnumerator coroutineGravity()
    {
        rigidbody.useGravity = false;
        yield return new WaitForSeconds(0.5f);
        rigidbody.useGravity = true;
    }
}
