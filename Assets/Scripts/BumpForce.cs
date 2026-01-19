using UnityEngine;
using System.Collections;
public class BumpForce : MonoBehaviour 
{
    public float bumpPower = 5f;

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody myRb = GetComponent<Rigidbody>();
        
        // If MY constraints are already unfrozen, I'm a victim - don't do anything
        if (myRb.constraints == RigidbodyConstraints.None)
            return;
        
        // Check if I'm actually moving (I'm the attacker)
        if (myRb.linearVelocity.magnitude < 1f)
            return;  // I'm not the attacker, do nothing
        
        if (collision.gameObject.CompareTag("Llama"))
        {
            Rigidbody otherRb = collision.rigidbody;
            
            Vector3 pushDir = collision.transform.position - transform.position;
            pushDir.y = 0.2f; 
            pushDir.Normalize();
            
            otherRb.constraints = RigidbodyConstraints.None;
            otherRb.AddForce(pushDir * bumpPower, ForceMode.Impulse);
        }
    }
}