using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, 0, -1.0f);
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    public float moveSpeed = 10.0f;
}
