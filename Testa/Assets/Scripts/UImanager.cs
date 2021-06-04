using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    private static UImanager _instance = null;

    public static UImanager instance { get { return _instance; } }

    public GameObject[] playerHP_obj = null;

    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerHP()
    {
        int minusHP = 3 - DataManager.instance.playerHP;
        for(int i = 0; i < minusHP; i++)
        {
            playerHP_obj[i].SetActive(false);
        }
    }
}
