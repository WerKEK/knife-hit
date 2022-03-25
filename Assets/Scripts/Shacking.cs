using UnityEngine;

public class Shacking : MonoBehaviour
{
    private bool isShacking;
    private Vector2 pos;
    private float shake = 0.03f;
    private int health = 7;
    [SerializeField] private Object destructable;
    private void Start()
    {
        pos = transform.position;
    }
    private void Update()
    {
        if (isShacking)
        {
            transform.position = pos + Random.insideUnitCircle * shake;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Knife"))
        {
            isShacking = true;
            health--;
            if (health <= 0)
            {
                ExplodeObj();
            }
            Invoke(nameof(StopShaking), 0.5f);
        }
    }
    private void StopShaking()
    {
        isShacking = false;
        transform.position = pos;
    }
    private void ExplodeObj()
    {
        GameObject destruct = (GameObject)Instantiate(destructable);
        destruct.transform.position = transform.position;
        Destroy(gameObject);
    }
}
