using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int actionPointsAvailable = 4;
    [SerializeField] float padding = 1f;
    [SerializeField] bool isSelected = false;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    void Start()
    {
        SetupMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void OnMouseDown()
    {
        Debug.Log("MOUSEDOWN");
        isSelected = true;
    }

    void incrementActionPoints()
    {
        actionPointsAvailable -= 1;
    }


    private void Move()
    {
        if (!isSelected)
        {
            return;
        }

        Debug.Log("moving.");
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
