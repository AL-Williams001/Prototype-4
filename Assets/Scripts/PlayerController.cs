using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private Rigidbody playerRb;
   private GameObject focalPoint;
   public float speed = 10.0f; // Speed of the player
   public bool hasPowerup;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
      {
        Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to" + hasPowerup);
      }
    }
}
