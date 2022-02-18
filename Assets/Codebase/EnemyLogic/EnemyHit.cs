using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<HeroMovement>(out var hero))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
