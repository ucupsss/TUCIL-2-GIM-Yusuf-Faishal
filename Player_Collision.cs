using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    private void Start(){
        GameManager.Instance.onplay.AddListener(ActivatePlayer);
    }
    private void ActivatePlayer(){
        gameObject.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Obstacle")) // Use CompareTag for better performance
        {
            gameObject.SetActive(false);
            GameManager.Instance.GameOver(); // Destroy the player object
        }
    }
}
