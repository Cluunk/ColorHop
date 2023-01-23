using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    [SerializeField] private AudioObject audioObj;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerMovement>();
        if (!player)
            return;
        var rb = player.GetComponent<Rigidbody2D>();
        if (audioObj)
            Instantiate(audioObj, transform.position, Quaternion.identity);
        rb.velocity = Vector2.up * bounceForce;
    }
}
