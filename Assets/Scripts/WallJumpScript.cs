using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpScript : MonoBehaviour
{
    [Header("Wall Jump")]
    //Wall jump variables.
    protected Rigidbody rb;
    public LayerMask whatIsWall;
    public float wallCheckDistance;
    private RaycastHit leftWallhit;
    private RaycastHit rightWallhit;
    public Transform orientation;
    private bool wallRight;
    private bool wallLeft;
    public float wallJumpUpForce;
    public float wallJumpSideForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    private void Update()
    {
        CheckForWall();
        
    }

    private void FixedUpdate()
    {
        WallJump();
    }

    private void CheckForWall()
    {
        wallRight = Physics.Raycast(transform.position, transform.right, out rightWallhit, wallCheckDistance, whatIsWall);
        Debug.Log(wallRight);

        wallLeft = Physics.Raycast(transform.position, -transform.right, out leftWallhit, wallCheckDistance, whatIsWall);
        Debug.Log(wallLeft);
    }

    private void WallJump()
    {
        Vector3 wallNormal = wallRight ? rightWallhit.normal : leftWallhit.normal;

        Vector3 forceToApply = transform.up * wallJumpUpForce + wallNormal;


        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(forceToApply, ForceMode.Impulse);
    }

}
