﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasSpawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject wanderArea;
    public GameObject player;


    public int Spawns = 750;
    int spawnCount = 0;
    List<GameObject> entities;

    void Start()
    {
        entities = new List<GameObject>();
        entities.Add(player);
        InvokeRepeating("Spawn", 0f, 1.0f / 1000.0f);
    }

    void Spawn()
    {
        if (spawnCount <= Spawns)
        {
            GameObject instance =
              Instantiate(prefab, GetRandomPosition(), Quaternion.identity)
              as GameObject;
            BehaviorExecutor component =
              instance.GetComponent<BehaviorExecutor>();
            component.SetBehaviorParam("wanderArea", wanderArea);
            component.SetBehaviorParam("player",
                                       entities[Random.Range(0, entities.Count)]);

            ++spawnCount;

            entities.Add(instance);
        }
        else
        {
            CancelInvoke();
        }

    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = Vector3.zero;
        BoxCollider boxCollider = wanderArea.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            randomPosition =
              new Vector3(
                Random.Range(
                    wanderArea.transform.position.x -
                    wanderArea.transform.localScale.x *
                    boxCollider.size.x * 0.5f,
                    wanderArea.transform.position.x +
                    wanderArea.transform.localScale.x *
                    boxCollider.size.x * 0.5f),
                wanderArea.transform.position.y,
                Random.Range(
                    wanderArea.transform.position.z -
                    wanderArea.transform.localScale.z *
                    boxCollider.size.z * 0.5f,
                    wanderArea.transform.position.z +
                    wanderArea.transform.localScale.z *
                    boxCollider.size.z * 0.5f));
        }

        return randomPosition;
    }
}
