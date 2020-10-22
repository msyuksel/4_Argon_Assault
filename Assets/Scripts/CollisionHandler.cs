using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ok as long as this is the only script that loads scripts

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke(nameof(ReloadScene), levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
