using System.Collections;
using System.Collections.Generic;

using Unity.Mathematics;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float playerSpeed;
    public float DeathDistance;

    private Vector3 StartPos;
    private bool endGame = false;

    private void Start()
    {
        StartPos = transform.position;
    }

    void Update()
    {
        if (transform.position.y < DeathDistance)
        {
            transform.position = StartPos;
        }
        if (!endGame)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0).normalized;
            transform.Translate(direction * Time.deltaTime * playerSpeed, Space.World);
        }
    }

    public void EndGame()
    {
        endGame = true;
    }
}
