using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
     public void Myattack(int power, Collider2D collider)
    {

        collider.gameObject.GetComponent<Enemy>().HP = collider.gameObject.GetComponent<Enemy>().HP - power;
        
    }

    public void Enemyattack(int power, Collider2D collider)
    {

        collider.gameObject.GetComponent<Normal>().HP = collider.gameObject.GetComponent<Normal>().HP - power;

    }
}
