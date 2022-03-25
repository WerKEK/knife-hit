using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] private Vector2 forseDir;
    [SerializeField] private int spin;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(forseDir);
        rb.AddTorque(spin);
    }
}
