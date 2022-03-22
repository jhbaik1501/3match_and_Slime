using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigid;
    public int HP;
    public float Speed;
    public int AttackPower;
    public float waitTime;
    
    public float AttackRange;
    SpriteRenderer spriteRenderer;
    Animator animator;
    bool isAct;
    public bool isDie;

    

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigid.velocity = Vector2.left * Speed;
        isAct = true;
        animator.SetBool("isAct", true);
    }


    void FixedUpdate()
    {
        MakeRay();

        if (HP <= 0 && isDie == false)
        {
            isDie = true;
            Ondamaged();
        }

    }


    void MakeRay()
    {


        Vector2 frontVec = new Vector2(rigid.position.x, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.left * AttackRange, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.left, AttackRange, LayerMask.GetMask("MyUnit"));
        if (rayHit.collider != null)
        {
            if (isAct == true && rayHit.collider.gameObject.GetComponent<Normal>().isDie == false)
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);
                isAct = false;
                animator.SetBool("isAct", false);

                rigid.constraints = RigidbodyConstraints2D.FreezeAll;
                Invoke("Think", waitTime);
                Enemyattack(AttackPower, rayHit.collider);

            }
        }


    }



    void Think()
    {

        isAct = true;
        animator.SetBool("isAct", true);
        rigid.velocity = Vector2.left * Speed;
        rigid.constraints = RigidbodyConstraints2D.None;
    }



    void Ondamaged()
    {
        if (this.gameObject.name == "EnemyCastle")
        {
            Debug.Log("CLEAR");
        }
        else
        {
            
            isAct = false;
            Invoke("DisappearAct", 0.35f);
            Invoke("Disappear", 0.65f);
        }
    }

    void DisappearAct()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
    }


    void Disappear()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }





    public void Enemyattack(int power, Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Normal>().isDie == false)
        {
            
            collider.gameObject.GetComponent<Normal>().HP = collider.gameObject.GetComponent<Normal>().HP - power;
        }
    }
}
