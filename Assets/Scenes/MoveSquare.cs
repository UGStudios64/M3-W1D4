using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] int maxDistance;

    private Vector2 startPosition;
    private Vector2 direction;

    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * (speed * Time.fixedDeltaTime));
    }

    private void Update()  
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        direction = new Vector2(h, v);
        float sqrLenght = direction.sqrMagnitude;
        if (sqrLenght > 1)
        { direction /= sqrLenght; }

        if (Vector2.Distance(startPosition, rb.position) > maxDistance)
        { rb.position = startPosition; }
    }
}