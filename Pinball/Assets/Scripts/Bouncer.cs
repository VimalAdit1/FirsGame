
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    //Change bounce force to negative inside Inspector for flipped normals
    public float bounceForce = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        Rigidbody ball = collision.collider.GetComponent<Rigidbody>();
        ball.AddForce(contact.normal * -bounceForce, ForceMode.Impulse);
    }
}
