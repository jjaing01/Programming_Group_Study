using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTick)
        {
            SpawMonster();
            timer = 0;
        }
    }

    void SpawMonster()
    {
        var spawnPoint = GameObject.Find("Patrol Point LT");
        if (spawnPoint && layerMonster)
        {
            Instantiate(prefabMonster, spawnPoint.transform.position, new Quaternion(), layerMonster.transform);
        }
    }

    public GameObject prefabMonster;
    public GameObject layerMonster;
    public float spawnTick = 1.0f;
    private float timer;
}
