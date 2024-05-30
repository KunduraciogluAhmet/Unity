using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject block;

    public float maxX;
    public Transform spawnPoint;
    public float spawnRate = 1.0f;

    bool gameStarted = false;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;

    int score = 0;



   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted )
        {
            StartSpawning();

            gameStarted = true;
            tapText.SetActive(false);

        }

        
    }


    void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock()
    {

        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(- maxX, maxX);

        Instantiate(block, spawnPos, Quaternion.identity);

        score++;

        scoreText.text = score.ToString();


    }
}
