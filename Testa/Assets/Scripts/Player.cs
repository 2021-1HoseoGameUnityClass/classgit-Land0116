using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float JumpForce = 0.1f;

    public bool Jump = true;
    public bool move = false;
    public float moveHorizontal;

    public GameObject bulletObj = null;
    public GameObject InstantiateObj = null;



    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            Move();
        }
        else
        {
            GetComponent<Animator>().SetBool("IsMove", false);
        }

        if(Input.GetButtonDown("Jump"))
        {
            PlayerJump();
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    public void Move()
    {
        
        //float h = Input.GetAxis("Horizontal");
        float h = moveHorizontal;
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

    public void PlayerJump()
    {
        if (Jump == false)
        {
            GetComponent<Animator>().SetBool("IsMove", false);
            GetComponent<Animator>().SetBool("IsJump", true);

            Vector2 vector2 = new Vector2(0, JumpForce);
            GetComponent<Rigidbody2D>().AddForce(vector2);
            Jump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Platform")
        {
            GetComponent<Animator>().SetBool("IsJump", false);
            Jump = false;
        }
    }

    public void Shot()
    {
        AudioClip audioClip = Resources.Load<AudioClip>("RangedAttack");
        GetComponent<AudioSource>().clip = audioClip;
        GetComponent<AudioSource>().Play();
        float direction = transform.localScale.x;
        Quaternion quaternion = new Quaternion(0, 0, 0, 0);
        Instantiate(bulletObj, InstantiateObj.transform.position, quaternion).GetComponent<Bullet>().InstantiateBullet(direction);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            DataManager.instance.playerHP -= 1;
            if (DataManager.instance.playerHP < 0)
            {
                DataManager.instance.playerHP = 0;
            }
            UImanager.instance.PlayerHP();
        }
    }

    public void OnMove(bool _right)
    {
        if(_right)
        {
            moveHorizontal = 1f;
        }
        else
        {
            moveHorizontal = -1f;
        }
        move = true;
    }

    public void OffMove()
    {
        moveHorizontal = 0;
        move = false;
    }
}
