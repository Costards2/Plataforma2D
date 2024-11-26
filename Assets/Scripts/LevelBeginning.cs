using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBeginning : MonoBehaviour
{
    public GameObject playerPosition;

    void Start()
    {
         PlayerManager.instance.gameObject.transform.position = playerPosition.transform.position;
    }

}
