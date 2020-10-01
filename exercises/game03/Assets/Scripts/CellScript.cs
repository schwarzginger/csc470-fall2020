using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    Renderer rend;
    //public Color aliveColor;
    public Color deadColor;

    public int x = -1;
    public int y = -1;

    public bool nextAlive; 
    private bool _alive = false;
    

    float goalheight = 10;
    float growspeed = 0.6f;
    Vector3 startPosition;


    public bool Alive {
        get
        {
            return this._alive;

        }

        set
        {
            this._alive = value;
            if (this._alive)
            {
                rend.material.color = new Color(Random.value, Random.value, Random.value);
                goalheight += 1;
    }

            else
            {

                rend.material.color = deadColor;
            }

        }

    }


    // Start is called before the first frame update
    void Start()
    {

        startPosition = transform.position;
        rend = gameObject.GetComponent<Renderer>();
        this.Alive = Random.value < 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        float actualGrowSpeed = growspeed;
        if (!this.Alive)
        {
            actualGrowSpeed *= -1;
        }
        if (transform.localScale.y < goalheight)
        {
            float newHeight = transform.localScale.y + actualGrowSpeed * Time.deltaTime;
            newHeight = Mathf.Clamp(newHeight, 1, 10);
            transform.localScale = new Vector3(transform.localScale.x, newHeight, transform.localScale.z);
        }


        if (transform.position.y < -10)
        {
            //reset position
            transform.position = startPosition;
        }
    }


    private void OnMouseDown()
    {
        this.Alive = !this.Alive;
    }




}
