using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [Serializable]
    public class EnemyData
    {
        public EnemyType type;
        public EnemyView prefab;
    }

    public List<EnemyData> dataList;
    
    public EnemyView GetEnemyInstance(EnemyType type, Transform spawnPoint)
    {
        var index = dataList.FindIndex(data => data.type == type);
        if (index >= 0)
            return Instantiate(dataList[index].prefab, spawnPoint.position, Quaternion.identity);
        return null;
    }

}
