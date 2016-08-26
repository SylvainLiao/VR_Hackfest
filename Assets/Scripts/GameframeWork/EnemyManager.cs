using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager m_instance;
    public static CharacterManager Instance
    {
        get
        {
            return (m_instance == null) ? new CharacterManager() : m_instance;
        }
    }

    public PlayerBattle PlayerObject;

    public EnemyBattle[] EnemyObjectsPool;

    public void Initailize()
    {

    }

    public EnemyBattle GetEnmeyByName(string name)
    {
        for (int i = 0, iCount = EnemyObjectsPool.Length; i < iCount; ++i)
        {
            if (EnemyObjectsPool[i].name == name)
                return EnemyObjectsPool[i];
        }
        Debug.Log("Cant Find Enemy With "+name);
        return null;
    }

    public PlayerBattle GetPlayer()
    {
        return PlayerObject;
    }
}
