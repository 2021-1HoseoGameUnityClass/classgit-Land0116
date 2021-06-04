using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pad : MonoBehaviour
{
    public string sceneName = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player") == true)
        {
            DataManager.instance.sceneName = sceneName;
            DataManager.instance.SaveData();
            SceneManager.LoadScene(sceneName);
        }
    }
}
