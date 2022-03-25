using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField] private Vector2 throwForce;
    private bool isActive = true;
    private Rigidbody2D rb;
    private BoxCollider2D knifeCollider;
    private GameObject knife;
    private int apple;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0) || !isActive) return;
        rb.AddForce(throwForce, ForceMode2D.Impulse);
        rb.gravityScale = 1;
        GameController.Instance.UI.DecrementDisplayedKnifeCount();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive)
            return;
        isActive = false;
        if (collision.collider.CompareTag("Wood"))
        {
            GetComponent<ParticleSystem>().Play();
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            transform.SetParent(collision.collider.transform);
            knifeCollider.offset = new Vector2(knifeCollider.offset.x, 0f);
            knifeCollider.size = new Vector2(knifeCollider.size.x, 0.28f);
            Handheld.Vibrate();
            GameController.Instance.OnSuccsessKnifeHit();
        }
        else if (collision.collider.CompareTag("Knife"))
        {
            rb.velocity = new Vector2(rb.velocity.x, -2);
            Handheld.Vibrate();
            GameController.Instance.StartGameOverSequence(false);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            apple++;
            if (PlayerPrefs.HasKey("Apple"))
            {
                PlayerPrefs.SetInt("Apple", PlayerPrefs.GetInt("Apple") + GetApples());
            }
            else
            {
                PlayerPrefs.SetInt("Apple", GetApples());
            }

            Destroy(collision.gameObject);
        }
    }

    private int GetApples()
    {
        return apple;
    }

}

