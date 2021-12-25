using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerResources data;

    private int _squareSide;

    private void Awake()
    {
        data.Init();
    }

    private void Update()
    {
        Movement();
    }

    public void SetSquareSide(int squareSide)
    {
        _squareSide = squareSide;
    }

    private void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                var cost = _squareSide *
                    (Pathfinding.FindPath(this.transform.position, hit.collider.transform.position)) / 10;

                if (true)
                {
                    if (data.RemoveEnergy(cost))
                    {
                        this.transform.position = hit.collider.transform.position;
                    }
                    else
                    {
                        //event
                    }
                }
                else
                {
                    
                }
            }
        }
    }
}
