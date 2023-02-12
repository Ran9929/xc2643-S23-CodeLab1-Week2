using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int currentLevel = 0;
    public int targetScore = 2;

    public GameObject prizePrefab;
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }

    void Update()
    {
        if (score == targetScore)
        {
            currentLevel++;
            targetScore *= 2;
            SceneManager.LoadScene(currentLevel);
        }
    }
}
