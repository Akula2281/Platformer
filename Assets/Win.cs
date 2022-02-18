using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject _winMenu;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<HeroMovement>(out var hero))
        {
            _winMenu.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
