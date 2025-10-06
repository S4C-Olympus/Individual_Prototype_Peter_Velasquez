using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public GameObject levelCompleteUI;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            if (levelCompleteUI != null)
                levelCompleteUI.SetActive(true);
        }
    }
}
