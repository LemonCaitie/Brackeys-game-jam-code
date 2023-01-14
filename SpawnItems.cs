using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private int numberOfItems;
    [SerializeField] private bool random;
    public bool generated;

    void OnMouseDown()
    {
        if (generated == false)
        {
            for (int i = 0; i < numberOfItems; i++)
            {
                OnSpawnPrefab();
            }
            generated = true;
        }
    }

    public void OnSpawnPrefab()
    {
        if (random)
        {
            float x = Random.Range(-70, -22);
            float y = Random.Range(-6, 53);
            Instantiate(prefab, new Vector2(x, y), Quaternion.identity);
        }
        else
        {
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }
}
