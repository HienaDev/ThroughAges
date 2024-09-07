using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private KeyCode up = KeyCode.W;
    [SerializeField] private KeyCode down = KeyCode.S;
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.D;

    [SerializeField] private float movementSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 velocity;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = Vector2.zero;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        FlipPlayer();
    }

    private void Movement()
    {
        velocity = Vector2.zero;

        if (Input.GetKey(up))
        {
            velocity.y = 1;
        }
        if (Input.GetKey(down))
        {
            velocity.y = -1;
        }
        if (Input.GetKey(right))
        {
            velocity.x = 1;
        }
        if (Input.GetKey(left))
        {
            velocity.x = -1;
        }

        rb.velocity = velocity.normalized * movementSpeed;

        animator.SetFloat("MovSpeed", Mathf.Abs(rb.velocity.magnitude));
    }

    private void FlipPlayer()
    {


        // https://answers.unity.com/questions/640162/detect-mouse-in-right-side-or-left-side-for-player.html

        var playerScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        if (Input.mousePosition.x < playerScreenPoint.x)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else
            transform.rotation = Quaternion.identity;

    }
}
