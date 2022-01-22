using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController Controller;

    [Header("Movement Properties")]
    public float MaxSpeed = 10.0f;
    public float Gravity = -30.0f;
    public float JumpHeight = 3.0f;
    public Vector3 Velocity;

    [Header("Ground Detection Properties")]
    public Transform GroundCheck;
    public float GroundRadius = 0.4f;
    public LayerMask GroundMask;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position,GroundRadius,GroundMask);

        if (isGrounded && Velocity.y < 0.0f)
        {
            Velocity.y = -2.0f;
        }

        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 Move = transform.right * X + transform.forward * Z;
        Controller.Move(Move * MaxSpeed * Time.deltaTime);

        if(Input.GetButton("Jump") && isGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2.0f * Gravity);
        }

        Velocity.y += Gravity * Time.deltaTime;
        Controller.Move(Velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(GroundCheck.position, GroundRadius);
    }
}
