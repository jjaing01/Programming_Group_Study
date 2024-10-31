using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExcelParsher;

public class GameCore : MonoBehaviour
{
    private GameCore()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(monsterSpawner, parent);

        NPOIAdaptor.GetInstance().Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public Transform parent;
    //public GameObject monsterSpawner;
}
