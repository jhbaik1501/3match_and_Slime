using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum GameState{
    wait,
    move
}




    public class Board :MonoBehaviour
    {

    public GameState currentState = GameState.move;
    public int width;
    public int height;
    public int offSet;
    public GameObject tilePrefab;
    public GameObject[] dots;
    public GameObject[] destroyEffect;
    private BackgroundTile[,] allTiles;
    public GameObject[,] allDots;
    private FindMatches findMatches;
    public BuildManager buildManager;
    AudioSource audioSource;
   

    void Awake()
    {
        findMatches = FindObjectOfType<FindMatches>();
        allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        audioSource = GetComponent<AudioSource>();
        SetUp();
    }




    private void SetUp()
    {

        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
            {
                Vector2 tempPosition = new Vector2(i, j + offSet);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "(" + i + "," + j + ")";
                int dotToUse = Random.Range(0, dots.Length);
                int maxIterations = 0;
                while (MatchesAt(i, j, dots[dotToUse]) && maxIterations<100)
                {//3칸짜리있으면 되섞기
                    dotToUse = Random.Range(0, dots.Length);
                    maxIterations++;
                }
                maxIterations = 0;
                GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                dot.GetComponent<Dot>().row = j;
                dot.GetComponent<Dot>().column = i;

                dot.transform.parent = this.transform;
                dot.name = "(" + i + "," + j + ")";
                allDots[i, j] = dot;
                
            }



    }



    private bool MatchesAt(int column, int row, GameObject piece)
    {//3match업게 되섞기
        if(column>1 && row > 1)
        {
            if (allDots[column - 1, row].tag == piece.tag && allDots[column - 2, row].tag == piece.tag)
                return true;
            if (allDots[column, row - 1].tag == piece.tag && allDots[column, row - 2].tag == piece.tag)
                return true;
        }else if(column <=1 || row <=1)
        {
            if (row > 1)
            {
                if (allDots[column, row - 1].tag == piece.tag && allDots[column, row - 2].tag == piece.tag)
                    return true;
            }
            if(column > 1)
            {
                if (allDots[column - 1, row].tag == piece.tag && allDots[column - 2, row].tag == piece.tag)
                    return true;
            }
        }


        return false;
    }
   
    private void DestroyMatchesAt(int column, int row)
    {

        if (allDots[column, row].GetComponent<Dot>().isMatched)
        {
            findMatches.currentMatches.Remove(allDots[column,row]) ;
            GameObject particle = Instantiate(destroyEffect[1], allDots[column, row].transform.position, Quaternion.identity); ;
            if (allDots[column, row].tag == "Green")
            {
                particle = Instantiate(destroyEffect[0], allDots[column, row].transform.position, Quaternion.identity);
            }
            else if(allDots[column, row].tag == "Blue")
            {
                particle = Instantiate(destroyEffect[1], allDots[column, row].transform.position, Quaternion.identity);
            }
            else if(allDots[column, row].tag == "Gold")
            {
                particle = Instantiate(destroyEffect[2], allDots[column, row].transform.position, Quaternion.identity);
            }
            else if(allDots[column, row].tag == "Red")
            {
                particle = Instantiate(destroyEffect[3], allDots[column, row].transform.position, Quaternion.identity);
            }
            else if (allDots[column, row].tag == "Ice")
            {
                particle = Instantiate(destroyEffect[4], allDots[column, row].transform.position, Quaternion.identity);
            }
            else 
            {
                particle = Instantiate(destroyEffect[5], allDots[column, row].transform.position, Quaternion.identity);
            }
            Destroy(particle, .5f);
            
            Destroy(allDots[column, row]);
            audioSource.Play();
            buildManager.Coin++;
            allDots[column, row] = null;
        }
      
    }

    public void DestroyMatches()
    {
        for(int i=0; i<width; i++){
            for (int j = 0; j < height; j++)
            {
                if (allDots[i, j] != null)
                {
                    DestroyMatchesAt(i, j);
                }
            }
        }
        
        StartCoroutine(DecreaseRowCo());
    }





    private IEnumerator DecreaseRowCo(){
        
        int nullCount = 0;

        for(int i =0; i< width; i++) {
            for(int j=0; j < height; j++)
            {
                
                if (allDots[i, j] == null)
                {
                    nullCount++;
                    
                }
                else if (nullCount > 0){
                    
                  allDots[i, j].GetComponent<Dot>().row -= nullCount;
                  allDots[i, j] = null; 
                }
                

            }
            nullCount = 0;
        }
        yield return new WaitForSeconds(.3f);
        StartCoroutine(FillBoardCo());
    }


    private void RefillBoard()
    {
        for(int i=0; i<width; i++)
        {   for(int j =0; j < height; j++)
            {
                if (allDots[i, j] == null)
                {
                    Vector2 tempPosition = new Vector2(i, j + offSet);
                    int dotToUse = Random.Range(0, dots.Length);
                    GameObject piece = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                    allDots[i, j] = piece;
                    piece.GetComponent<Dot>().row = j;
                    piece.GetComponent<Dot>().column = i;
                }
            }

        }
    }

    private bool MatchesOnBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i, j] != null)
                {
                    if (allDots[i, j].GetComponent<Dot>().isMatched)
                    {
                        return true;
                    }
                }
            }
        }
       return false;
    }




    private IEnumerator FillBoardCo()
    {
        RefillBoard();
        yield return new WaitForSeconds(0.3f);


        while (MatchesOnBoard())
        {
            yield return new WaitForSeconds(0.3f);
            DestroyMatches();
        }
        yield return new WaitForSeconds(0.3f);
        currentState = GameState.move;
    }
}
