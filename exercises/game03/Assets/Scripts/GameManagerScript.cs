using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public GameObject cellPrefab;

    public CellScript[,] grid; 


    int gridwidth = 90;
    int gridheight = 90;

    float padding = 0.1f; 
    float celldimension = 0.9f;

    bool simulate = true; 
    int time = 0;
    float timer = 0;
    float timerRate = 0.5f; 

    // Start is called before the first frame update
    void Start()
    {
        grid = new CellScript[gridwidth, gridheight];

        for (int x = 0; x < gridwidth; x++)
        {
            for (int y = 0; y < gridheight; y++)
            {
                Vector3 pos = new Vector3(x * (celldimension + padding), 0, y * (celldimension + padding));
                GameObject cellobject = Instantiate(cellPrefab, pos, Quaternion.identity);
                cellobject.transform.localScale = new Vector3(celldimension, celldimension, celldimension);
                CellScript cs = cellobject.GetComponent<CellScript>();
                cs.x = x;
                cs.y = y; 
                grid[x, y] = cs;

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && simulate)
        {
            generatenextstate();

            timer = timerRate;
        } 

        
    }

    void generatenextstate()
    {
        time++;

        for (int x = 0; x < gridwidth; x++)
        {

            for (int y = 0; y < gridheight; y++)
            {
                List<CellScript> liveNeighbors = gatherLiveNeighbors(x, y);


                if (grid[x, y].Alive && liveNeighbors.Count < 2)
                {
                    grid[x, y].nextAlive = false;
                }
                //2. Any live cell with two or three live neighbours lives on to the next generation.
                else if (grid[x, y].Alive && (liveNeighbors.Count == 2 || liveNeighbors.Count == 3))
                {
                    grid[x, y].nextAlive = true;
                }
                //3. Any live cell with more than three live neighbours dies, as if by overpopulation.
                else if (grid[x, y].Alive && liveNeighbors.Count > 3)
                {
                    grid[x, y].nextAlive = false;
                }
                //4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                else if (!grid[x, y].Alive && liveNeighbors.Count == 3)
                {
                    grid[x, y].nextAlive = true;

                }
            }
        }


        for (int x = 0; x < gridwidth; x++)
        {
            for (int y = 0; y < gridheight; y++)
            {
                grid[x, y].Alive = grid[x, y].nextAlive;
            }
        }
    }







    List<CellScript> gatherLiveNeighbors(int x, int y)
    {
        List<CellScript> liveNeighbors = new List<CellScript>();

        for (int i = Mathf.Max(0, x - 1); i <= Mathf.Min(gridwidth - 1, x + 1); i++)
        {
            for (int j = Mathf.Max(0, y - 1); j <= Mathf.Min(gridheight - 1, y + 1); j++)
            {
                if (!(x == i && y == j))
                {
                    if (grid[i, j].Alive)
                    {
                        liveNeighbors.Add(grid[i, j]);
                    }
                }
            }
        }

        return liveNeighbors;
    }

    public void SimulateToggle(bool checkValue)
    {
        simulate = !simulate;
    }
}
