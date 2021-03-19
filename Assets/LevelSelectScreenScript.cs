using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelSelectScreenScript : MonoBehaviour
{ 
    public GameObject selector;

    public List<GameObject> row1;

    public List<GameObject> row2;

    const int cols = 2;
    const int rows = 2;

    Vector2 positionIndex;
    GameObject currentSlot;

    bool isMoving = false;

    public GameObject[,] grid = new GameObject[cols, rows];

    void Start()
    {
        row1.Add(GameObject.Find("Row1_1"));
        row1.Add(GameObject.Find("Row1_2"));
        row2.Add(GameObject.Find("Row2_1"));
        row2.Add(GameObject.Find("Row2_2"));

        AddRowToGrid(0, row1);
        AddRowToGrid(1, row2);

        positionIndex = new Vector2(0, 0);
        currentSlot = grid[0, 0];
    }

    void AddRowToGrid(int index, List<GameObject> row)
    {
        for (int i = 0; i < 2; i++)
        {
            grid[index, i] = row[i];
        }
    }
    // Update is called once per frame
    void Update()
    {


        // coder le press button qui choisi le perso
    }
    public void MoveSelector(string direction)
    {
        if(isMoving == false)
        {
            isMoving = true;
            if (direction == "right")
            {
                if (positionIndex.x < cols-1)
                {
                    positionIndex.x += 1;
                }
                
            }
            else if (direction == "left")
            {
                if (positionIndex.x > 0)
                {
                    positionIndex.x -= 1;
                }

            }
            else if (direction == "up")
            {
                if (positionIndex.y > 0)
                {
                    positionIndex.y -= 1;
                }

            }
            else if (direction == "down")
            {
                if (positionIndex.y < rows-1)
                {
                    positionIndex.y += 1;
                }

            }
            currentSlot = grid[(int)positionIndex.y, (int)positionIndex.x];
            selector.transform.position = currentSlot.transform.position;
            Invoke("ResetMoving", 0.2f);
        }
    }

    void ResetMoving()
    {
        isMoving = false;
    }
}
