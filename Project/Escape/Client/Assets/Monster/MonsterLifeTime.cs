using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLifeTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float lifeTime = 30.0f;
}
