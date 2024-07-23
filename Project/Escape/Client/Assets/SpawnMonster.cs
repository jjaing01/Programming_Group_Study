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
        Instantiate(prefabMonster, new Vector3(0, 0, 0), new Quaternion());
    }

    public GameObject prefabMonster;
    public float spawnTick = 1.0f;
    private float timer;
}
