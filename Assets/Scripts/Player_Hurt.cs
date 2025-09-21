using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hurt : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventManager.Instance.game_over.Invoke();
        }
    }

}
