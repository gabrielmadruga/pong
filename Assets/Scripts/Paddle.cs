using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{

    private Vector2 dir;
    private Vector2 speed;

    void Start()
    {
        dir = new Vector2(0, 0);
        speed = new Vector2(0, 200);
    }

    public void OnMove(InputValue value)
    {
        dir = value.Get<Vector2>();
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.collider.gameObject.name);
        if (collision.collider.gameObject.name == "Ball")
        {
            collision.rigidbody.AddForce(collision.otherRigidbody.velocity.normalized * 0.5f);
            collision.rigidbody.AddForce(transform.right * 0.1f);
            FindObjectOfType<AudioManager>().Play("Paddle");
        }
        // foreach (ContactPoint2D contact in collision.contacts)
        // {
        //     Debug.DrawLine(contact.point, contact.point + contact.normal * 10, Color.green, 2);
        // }
    }
}
