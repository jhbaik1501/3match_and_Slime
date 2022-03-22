﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{


    [Header("Board Variables")]
    public int column;
    public int row;
    public int previousColumn;
    public int previousRow;

    public int targetX;
    public int targetY;
    private Board board;
    private GameObject otherDot;

    public bool isMatched =false;

    private FindMatches findMatches;
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    private Vector2 tempPosition;
    public float swipeAngle = 0;
    public float swipeResist = 30.0f;
    AudioSource audioSource;


    private void Start()
    {
        swipeResist = 30.0f;
        board = FindObjectOfType<Board>();
        findMatches = FindObjectOfType<FindMatches>();
        audioSource = GetComponent<AudioSource>();
        //targetX = (int)transform.position.x;
        //targetY = (int)transform.position.y;
        //row = targetY;
        //column = targetX;
        //previousRow = row;
        //previousColumn = column;

    }

    private void Update()
    {
        //FindMatched();
        findMatches.FindAllMatches();


        if (isMatched)
        {
            SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
            mySprite.color = new Color(mySprite.color.r, mySprite.color.b, mySprite.color.g, 0.25f);
            
        }



        targetX = column;
        targetY = row;

        
        if (Mathf.Abs(targetX - transform.position.x) > .1)
        {//타겟쪽으로 움직임
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .4f);
            if(board.allDots[column,row] != this.gameObject)
            {
                board.allDots[column, row] = this.gameObject; 
            }
            findMatches.FindAllMatches();
        }
        else
        {
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = tempPosition;
            board.allDots[column, row] = this.gameObject;
        }

        if (Mathf.Abs(targetY - transform.position.y) > .1)
        {//타겟쪽으로 움직임
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .4f);
            if (board.allDots[column, row] != this.gameObject)
            {
                board.allDots[column, row] = this.gameObject;
                findMatches.FindAllMatches();
            }
        }
        else
        {//직접 포지션 정한다.
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = tempPosition;
           
            board.allDots[column, row] = this.gameObject;
        }
    }

    public IEnumerator CheckMoveCo()
    {
        yield return new WaitForSeconds(.3f);
        if(otherDot != null)
        {
            if(!isMatched && !otherDot.GetComponent<Dot>().isMatched)
            {
                otherDot.GetComponent<Dot>().row = row;
                otherDot.GetComponent<Dot>().column = column;
                row = previousRow;
                column = previousColumn;
                yield return new WaitForSeconds(0.3f);
                board.currentState = GameState.move;
            }
            else
            {
                board.DestroyMatches();
                
            }
            otherDot = null;
        }
        
        
    }


    private void OnMouseDown()
    {
        if (board.currentState == GameState.move) { 
        firstTouchPosition = Input.mousePosition;
        Debug.Log(row);
         audioSource.Play();
        }
    }

    private void OnMouseUp()
    {
        if (board.currentState == GameState.move)
        {
            finalTouchPosition = Input.mousePosition;
            Debug.Log(finalTouchPosition);
            CalculateAngle();
        }
    }


    void CalculateAngle()
    {
        if ((Mathf.Abs(finalTouchPosition.y - firstTouchPosition.y) > swipeResist) || (Mathf.Abs(finalTouchPosition.x - firstTouchPosition.x) > swipeResist))
        {
            swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180 / Mathf.PI;
            Debug.Log(swipeAngle);
            MovePiece();
            board.currentState = GameState.wait;
        }
        else
        {
            board.currentState = GameState.move;
        }
    }

    void MovePiece()
    {
        if(swipeAngle >-45 && swipeAngle <= 45 && column < board.width-1)
        {//right
            otherDot = board.allDots[column + 1, row];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Dot>().column -= 1;
            column += 1;
        }
        else if (swipeAngle > 45 && swipeAngle <= 135 && row < board.height-1 )
        {//up
            
            otherDot = board.allDots[column , row +1];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Dot>().row -= 1;
            row += 1;
        }
        else if((swipeAngle > 135 || swipeAngle <= -135) && column >0)
        {//left
            otherDot = board.allDots[column - 1, row];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Dot>().column += 1;
            column -= 1;
        }
        else if(swipeAngle < -45 && swipeAngle >= -135 && row >0) 
        {//down
            otherDot = board.allDots[column , row -1];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Dot>().row += 1;
            row -= 1;
        }
        StartCoroutine(CheckMoveCo());
    }




    void FindMatched()
    {
        if(column >0 && column < board.width - 1)
        {
            GameObject leftDot1 = board.allDots[column -1, row];
            GameObject rightDot1 = board.allDots[column + 1, row];
            if (leftDot1 != null && rightDot1 != null && leftDot1 != this.gameObject && rightDot1 != this.gameObject)
            {


                if (leftDot1.tag == this.gameObject.tag && rightDot1.tag == this.gameObject.tag)
                {
                    leftDot1.GetComponent<Dot>().isMatched = true;
                    rightDot1.GetComponent<Dot>().isMatched = true;
                    isMatched = true;
                }
            }
        }

        if (row > 0 && row < board.height - 1)
        {
            GameObject upDot1 = board.allDots[column, row+1];
            GameObject downDot1 = board.allDots[column , row-1];
            if (upDot1 != null && downDot1 != null && upDot1 != this.gameObject && downDot1 != this.gameObject)
            {
                
                if (upDot1.tag == this.gameObject.tag && downDot1.tag == this.gameObject.tag)
                {
                    upDot1.GetComponent<Dot>().isMatched = true;
                    downDot1.GetComponent<Dot>().isMatched = true;
                    isMatched = true;
                }
            }
        }
    }

}
