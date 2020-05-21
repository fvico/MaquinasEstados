using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 position;

    public GameObject wanderArea;
    public GameObject player;

    void Start()
    {
        GameObject instance =
          Instantiate(prefab, position, Quaternion.identity) as GameObject;
        BehaviorExecutor behaviorExecutor =
          instance.GetComponent<BehaviorExecutor>();
        if (behaviorExecutor != null)
        {
            behaviorExecutor.SetBehaviorParam("wanderArea", wanderArea);
            behaviorExecutor.SetBehaviorParam("player", player);
        }
    }
}

