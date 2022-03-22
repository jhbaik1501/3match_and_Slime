using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuildManager : MonoBehaviour
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
    Vector2 vec;
    private void Awake()
    {
        
        StartCoroutine(Enemylist());
        
    }

    private IEnumerator Enemylist()
    {
        
        StartCoroutine(MakeSwordS());
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(MakeSwordS());
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(MakeStoneS());
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(MakeCowBoy());
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(MakeHydra());
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(MakeBoxing());
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(MakeStoneS());
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(MakeSnowManS());
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(MakeSnowManS());
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(MakeCowBoy());
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(MakeZeusS());
        yield return new WaitForSeconds(3.0f);
    }
    private IEnumerator MakeNormal()
    {
        Vector2 vec = new Vector2(SelectNode.transform.position.x - 1, SelectNode.transform.position.y - 1);
        Instantiate(NormalS, vec, Quaternion.identity, this.transform);
        yield return new WaitForSeconds(3.0f);
    }
    private IEnumerator MakeCowBoy()
    {
        Vector2 vec = new Vector2(SelectNode.transform.position.x - 1, SelectNode.transform.position.y - 1);
        Instantiate(CowBoyS, vec, Quaternion.identity, this.transform);
        yield return new WaitForSeconds(3.0f);
    }
    private IEnumerator MakeHydra()
    {
        Vector2 vec = new Vector2(SelectNode.transform.position.x - 1, SelectNode.transform.position.y - 1);
        Instantiate(HydraS, vec, Quaternion.identity, this.transform);
        yield return new WaitForSeconds(3.0f);
    }
    private IEnumerator MakeBoxing()
    {
        Vector2 vec = new Vector2(SelectNode.transform.position.x - 1, SelectNode.transform.position.y - 1);
        Instantiate(BoxingS, vec, Quaternion.identity, this.transform);
        yield return new WaitForSeconds(3.0f);
    }
    private IEnumerator MakeStoneS()
    {
        Vector2 vec = new Vector2(SelectNode.transform.position.x - 1, SelectNode.transform.position.y - 1);
        Instantiate(StoneS, vec, Quaternion.identity, this.transform);
        yield return new WaitForSeconds(3.0f);
    }
    private IEnumerator MakeSnowManS()
    {
        Vector2 vec = new Vector2(SelectNode.transform.position.x - 1, SelectNode.transform.position.y - 1);
        Instantiate(SnowManS, vec, Quaternion.identity, this.transform);
        yield return new WaitForSeconds(3.0f);
    }
    private IEnumerator MakeZeusS()
    {
        Vector2 vec = new Vector2(SelectNode.transform.position.x - 1, SelectNode.transform.position.y - 1);
        Instantiate(ZeusS, vec, Quaternion.identity, this.transform);
        yield return new WaitForSeconds(3.0f);
    }
    private IEnumerator MakeSwordS()
    {
        Vector2 vec = new Vector2(SelectNode.transform.position.x - 1, SelectNode.transform.position.y - 1);
        Instantiate(SwordS, vec, Quaternion.identity, this.transform);
        yield return new WaitForSeconds(3.0f);
    }
    private IEnumerator MakeCryS()
    {
        Vector2 vec = new Vector2(SelectNode.transform.position.x - 1, SelectNode.transform.position.y - 1);
        Instantiate(CryS, vec, Quaternion.identity);
        yield return new WaitForSeconds(3.0f);
    }
    private IEnumerator MakeCloudS()
    {
        Vector2 vec = new Vector2(SelectNode.transform.position.x - 1, SelectNode.transform.position.y - 1);
        Instantiate(CloudS, vec, Quaternion.identity);
        yield return new WaitForSeconds(3.0f);
    }


    void Wait()
    {

    }

}
