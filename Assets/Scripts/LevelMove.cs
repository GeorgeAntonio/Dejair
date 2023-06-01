using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex;

    AudioSource somDaPorta;

    private void Start()
    {
        somDaPorta = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player")) {
            somDaPorta.Play(0);
            GameController gameController = FindObjectOfType<GameController>();
            gameController.GoToLevel(sceneBuildIndex);
        }
    }
}