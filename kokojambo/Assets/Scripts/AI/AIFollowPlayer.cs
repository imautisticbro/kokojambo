using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowPlayer : MonoBehaviour
{
    public Transform player; 
    public float followSpeed = 5f; 
    public float stoppingDistance = 2f; 
    public float jumpForce = 5f; 
    public LayerMask groundLayer; 

    private bool isGrounded;

    private void Update()
    {
        Vector2 direction = player.position - transform.position;

        float distance = direction.magnitude;

        if (distance <= stoppingDistance)
        {
            transform.position = transform.position;
        }
        else
        {
            direction.Normalize();
            float moveAmount = followSpeed * Time.deltaTime;
            transform.Translate(direction * moveAmount, Space.World);
        }

        isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, groundLayer);

        if (isGrounded && player.position.y > transform.position.y)
        {
            transform.Translate(Vector2.up * jumpForce * Time.deltaTime, Space.World);
        }

        if (direction.x > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); 
        }
        else if (direction.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); 
        }
    }
}