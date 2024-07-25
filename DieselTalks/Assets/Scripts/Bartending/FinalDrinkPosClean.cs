using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDrinkPosClean : MonoBehaviour
{
    public void CleanChildren()
    {
        for (int i = 0; i < transform.childCount; i++) Destroy(transform.GetChild(i).gameObject);
    }
}
