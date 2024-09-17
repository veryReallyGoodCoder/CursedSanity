using UnityEngine;

public class ZeroGrav : MonoBehaviour
{
    // Adjust the strength of the random floating force
    public float floatingForceStrength = 0.5f;
    
    // This will store the reference to the Rigidbody that's in the zero-G zone
    private Rigidbody floatingRigidbody;

    private void OnTriggerEnter(Collider other)
    {
        // Get the Rigidbody component of the object entering the trigger zone
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Disable gravity and set initial velocity t
            rb.useGravity = false;
            rb.velocity = Vector3.zero;

           
            floatingRigidbody = rb;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Get the Rigidbody component of the object 
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Re-enable gravity
            rb.useGravity = true;

            // Clear the stored reference 
            if (rb == floatingRigidbody)
            {
                floatingRigidbody = null;
            }
        }
    }

    private void FixedUpdate()
    {
        // Apply a gentle random force
        if (floatingRigidbody != null)
        {
            Vector3 randomForce = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            ) * floatingForceStrength;

            floatingRigidbody.AddForce(randomForce, ForceMode.Acceleration);
        }
    }
}
