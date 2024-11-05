using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExcelParsher;
using ExcelDataTable.MonsterInfoTableBasicMonster;
using ExcelDataTable.MonsterInfoTableBossMonster;

public class GameCore : MonoBehaviour
{
    private GameCore()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        NPOIAdaptor.GetInstance().Init();
        var basicMosntgerTable = new BasicMonsterTable();
        basicMosntgerTable.LoadSheetDatasAll();

        var bossMonsterTable = new BossMonsterTable();
        bossMonsterTable.LoadSheetDatasAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
