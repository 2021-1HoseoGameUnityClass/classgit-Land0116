using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject rayPosition = null;
    public int Hp = 10;
    public float moveSpeed = 3f;
    public bool moveRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckRay();
    }

    public void CheckRay()
    {
        if(GetComponent<Animator>().GetBool("Death") == false)
        {
            LayerMask layermask = new LayerMask();
            layermask = LayerMask.GetMask("Platform");

            RaycastHit2D ray = Physics2D.Raycast(rayPosition.transform.position, new Vector2(0, -1), 1.1f, layermask.value);
            Debug.DrawRay(rayPosition.transform.position, new Vector3(0, -1, 0), Color.red);

            if(ray == false)
            {
                if(moveRight)
                {
                    moveRight = false;
                }
                else
                {
                    moveRight = true;
                }
            }

            Move();
        }

    }

    public void Move()
    {
        float direction = 0f;

        if(moveRight == true)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        Vector3 vector3 = new Vector3(direction, 1, 1);
        transform.localScale = vector3;

        float speed = moveSpeed * Time.deltaTime * direction;
        vector3 = new Vector3(speed, 0, 0);
        transform.Translate(vector3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet") == true)
        {
            Hp = Hp - 5;

            if(Hp < 1)
            {
                GetComponent<Animator>().SetBool("Death", true);

                Destroy(gameObject, 0.5f);
            }
        }
        
    }
}
