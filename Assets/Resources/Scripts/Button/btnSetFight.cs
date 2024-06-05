using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnSetFight : MonoBehaviour
{
    public void SetEquip()
    {
        string shipName = PlayerPrefs.GetString("ShipName");
        PlayerPrefs.SetString("ShipFight", shipName);
    }
}
