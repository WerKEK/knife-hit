using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject apple;
    [SerializeField] private int chance = 25;

    private void Start()
    {
        float range = Random.Range(0f, 101f);
        if (chance > range)
        {
            Instantiate(apple, spawnPos);
        }
    }
}
