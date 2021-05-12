using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        
        float h = Input.GetAxis("Horizontal");
        float PlayerSpeed = h * Time.deltaTime * moveSpeed;
        Vector3 vector = new Vector3();

        vector.x = PlayerSpeed;
        transform.Translate(vector);

        if(h < 0)
        {
            GetComponent<Animator>().SetBool("IsMove", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (h > 0)
        {
            GetComponent<Animator>().SetBool("IsMove", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsMove", false);
        }
    }
}
