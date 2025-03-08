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
    

    private void Update()
    {
        CheckForWall();
    }

    private void CheckForWall()
    {
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallhit, wallCheckDistance, whatIsWall);

        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallhit, wallCheckDistance, whatIsWall);
    }

    private void WallJump()
    {
        Vector3 wallNormal = wallRight ? rightWallhit.normal : leftWallhit.normal;

        Vector3 forceToApply = transform.up * wallJumpUpForce + wallNormal;


        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(forceToApply, ForceMode.Impulse);
    }

}
