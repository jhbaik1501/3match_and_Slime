using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public GameObject SelectNode;

    public GameObject NormalS;
    public GameObject CowBoyS;
    public GameObject HydraS;
    public GameObject BoxingS;
    public GameObject StoneS;
    public GameObject SnowManS;
    public GameObject ZeusS;
    public GameObject SwordS;
    public GameObject CryS;
    public GameObject CloudS;
    public Vector2 vec;
    public int Coin;
    public Text text;


    private void Awake()
    {
        Debug.Log(SelectNode.transform.position + "아군");
        Coin = 0;
        text.text = Coin.ToString();
        GetCoin();
        vec = new Vector2(SelectNode.transform.position.x , SelectNode.transform.position.y-1);
        
    }

    private void FixedUpdate()
    {
        text.text = Coin.ToString();
        
    }


    public void MakeCowBoys()
    {
        int cost = 15;
        if (Coin >= cost)
        {
           
            Instantiate(CowBoyS, vec, Quaternion.identity, this.transform);// (1. 생성할 오브젝트, 2. 생성할 위치, 3. 생성된 오브젝트의 각도)
            Coin -= cost;                                                                                                                                   //버튼에 이함수넣기.
        }
        else {
            Debug.Log("살숭벗어");
         }
    }


    public void MakeNormalS()
    {
        int cost = 10;
        if (Coin >= cost)
        {
            Debug.Log(SelectNode.transform.position.y);
            Instantiate(NormalS, vec, Quaternion.identity, this.transform);// (1. 생성할 오브젝트, 2. 생성할 위치, 3. 생성된 오브젝트의 각도)
            Coin -= cost;                                                                                                       //버튼에 이함수넣기.
        }
        else
        {
            Debug.Log("살숭벗어");
        }

    }


    public void MakeHydraS()
    {
        int cost = 15;
        if (Coin >= cost)
        {
           
            Instantiate(HydraS, vec, Quaternion.identity, this.transform);// (1. 생성할 오브젝트, 2. 생성할 위치, 3. 생성된 오브젝트의 각도)
            Coin -= cost;                                                                                                                               //버튼에 이함수넣기.
        }
        else
        {
            Debug.Log("살숭벗어");
        }
    }



    public void MakeBoxingS()
    {
        int cost = 15;
        if (Coin >= cost)
        {

            Instantiate(BoxingS, vec, Quaternion.identity, this.transform);// (1. 생성할 오브젝트, 2. 생성할 위치, 3. 생성된 오브젝트의 각도)
            Coin -= cost;                                                                                                                               //버튼에 이함수넣기.
        }
        else
        {
            Debug.Log("살숭벗어");
        }
    }



    public void MakeStoneS()
    {
        int cost = 20;
        if (Coin >= cost)
        {

            Instantiate(StoneS, vec, Quaternion.identity, this.transform);// (1. 생성할 오브젝트, 2. 생성할 위치, 3. 생성된 오브젝트의 각도)
            Coin -= cost;                                                                                                                               //버튼에 이함수넣기.
        }
        else
        {
            Debug.Log("살숭벗어");
        }
    }
    public void MakeSnowManS()
    {
        int cost = 25;
        if (Coin >= cost)
        {

            Instantiate(SnowManS, vec, Quaternion.identity, this.transform);// (1. 생성할 오브젝트, 2. 생성할 위치, 3. 생성된 오브젝트의 각도)
            Coin -= cost;                                                                                                                               //버튼에 이함수넣기.
        }
        else
        {
            Debug.Log("살숭벗어");
        }
    }
    public void MakeZeusS()
    {
        int cost = 50;
        if (Coin >= cost)
        {

            Instantiate(ZeusS, vec, Quaternion.identity, this.transform);// (1. 생성할 오브젝트, 2. 생성할 위치, 3. 생성된 오브젝트의 각도)
            Coin -= cost;                                                                                                                               //버튼에 이함수넣기.
        }
        else
        {
            Debug.Log("살숭벗어");
        }
    }
    public void MakeSwordS()
    {
        int cost = 20;
        if (Coin >= cost)
        {

            Instantiate(SwordS, vec, Quaternion.identity, this.transform);// (1. 생성할 오브젝트, 2. 생성할 위치, 3. 생성된 오브젝트의 각도)
            Coin -= cost;                                                                                                                               //버튼에 이함수넣기.
        }
        else
        {
            Debug.Log("살숭벗어");
        }
    }
    public void MakeCryS()
    {
        int cost = 30;
        if (Coin >= cost)
        {

            Instantiate(CryS, vec, Quaternion.identity, this.transform);// (1. 생성할 오브젝트, 2. 생성할 위치, 3. 생성된 오브젝트의 각도)
            Coin -= cost;                                                                                                                               //버튼에 이함수넣기.
        }
        else
        {
            Debug.Log("살숭벗어");
        }
    }
    public void MakeCloudS()
    {
        int cost = 30 ;
        if (Coin >= cost)
        {

            Instantiate(CloudS, vec, Quaternion.identity, this.transform);// (1. 생성할 오브젝트, 2. 생성할 위치, 3. 생성된 오브젝트의 각도)
            Coin -= cost;                                                                                                                               //버튼에 이함수넣기.
        }
        else
        {
            Debug.Log("살숭벗어");
        }
    }



    void GetCoin()
    {
        Coin += 3;
        Invoke("GetCoin",2);
    }


}
