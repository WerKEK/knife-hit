using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPos1;
    [SerializeField] private Transform spawnPos2;
    [SerializeField] private Transform spawnPos3;
    [SerializeField] private GameObject knife1;
    [SerializeField] private GameObject knife2;
    [SerializeField] private GameObject knife3;

    void Start()
    {
        float range = Random.Range(0f, 101f);
        if (100f > range)
        {
            Instantiate(knife1, spawnPos1);
        }

        if (50f > range)
        {
            Instantiate(knife2, spawnPos2);
        }

        if (10f > range)
        {
            Instantiate(knife3, spawnPos3);
        }
    }
}
