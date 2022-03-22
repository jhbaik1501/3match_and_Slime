using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : MonoBehaviour
{

    Rigidbody2D rigid;
    public int HP;
    public float Speed;
    public int AttackPower;
    public float waitTime;
    public int cost;
    public float AttackRange;
    SpriteRenderer spriteRenderer;
    Animator animator;
    bool isAct;
    public bool isDie;
    bool EnemyDie;



    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigid.velocity = Vector2.right * Speed;
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
        Debug.DrawRay(frontVec, Vector3.right * AttackRange, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.right, AttackRange, LayerMask.GetMask("Enemy"));
        if (rayHit.collider != null)
        {
            if (isAct == true && rayHit.collider.gameObject.GetComponent<Enemy>().isDie == false)
            {
                rigid.velocity = new Vector2(0,rigid.velocity.y);
                isAct = false;
                animator.SetBool("isAct", false);

                rigid.constraints = RigidbodyConstraints2D.FreezeAll;
                
                Invoke("Think", waitTime);
               
                Myattack(AttackPower, rayHit.collider);

            }
            
        }

        
    }



    void Think()
    {
        
        isAct = true;
        animator.SetBool("isAct", true);
        rigid.velocity = Vector2.right * Speed;
        rigid.constraints = RigidbodyConstraints2D.None;
    }



    void Ondamaged()
    {
        if (this.gameObject.name == "MyCastle")
        {
            Debug.Log("FAIL");
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



    public void Myattack(int power, Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Enemy>().isDie == false)
        collider.gameObject.GetComponent<Enemy>().HP = collider.gameObject.GetComponent<Enemy>().HP - power;
        
    }

}
