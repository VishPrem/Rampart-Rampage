using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public soEventWithVec3Args enemyDied;
    private int enemiesRemaining;
    public spawner spawner;
    public float dayLength;
    public float daySpeed;
    private float currentDayTime;
    private bool gameRunning;
    public int dayCounter;
    public soEvent onRoundStart;
    public static gameManager instance;
    public soEvent onRoundEnd;
    public soEvent onCastleDeath;
    public Material skybox;
    public soEvent enemyDiedWithoutReward;
    public soEvent quitGame;
    public GameObject menu;
    public GameObject healthbar;
    public GameObject player;
    public GameObject menuPOV;
    public player_controls controls;
    public CinemachineVirtualCamera camera;

    private void OnEnable()
    {
        if(instance != null && instance != this) 
        {
            Destroy(instance);
        }
        instance = this;
        enemyDied.events.Add((Vector3 _) => { enemiesRemaining--; });
        enemyDiedWithoutReward.events.Add(() => { enemiesRemaining--; });
        onCastleDeath.events.Add(lose);
        quitGame.events.Add(() => { Debug.Log("Quit");  Application.Quit(); });
        onRoundEnd.events.Add(() => { menu.SetActive(true); controls.enabled = false; camera.enabled = false; healthbar.SetActive(false); menuPOV.SetActive(true); });
        dayCounter = PlayerPrefs.GetInt("Current Day");
    }

    public void OnDisable()
    {
        skybox.SetFloat("_BlendCubemaps", 0);
        PlayerPrefs.SetInt("Current Day", dayCounter);
    }

    public void Update()
    {
        if(!gameRunning) return;
        currentDayTime += Time.deltaTime * daySpeed;
        skybox.SetFloat("_BlendCubemaps", currentDayTime / dayLength);
        if(enemiesRemaining <= 0)
        {
            enemiesRemaining = spawner.spawnWave(dayCounter);
        }
        if(currentDayTime > dayLength)
        {
            endRound();
        }
    }

    public void startRound()
    {
        onRoundStart.invoke();
        gameRunning = true;
        enemiesRemaining = spawner.spawnWave(dayCounter);
    }

    public void endRound()
    {
        onRoundEnd.invoke();
        gameRunning = false;
        dayCounter++;
        enemiesRemaining = 0;
        currentDayTime = 0;
    }

    private void lose()
    {
        Debug.Log("You Lost!");
        endRound();
        dayCounter = 0;
    }

    public void resetDay()
    {
        currentDayTime = 0;
        skybox.SetFloat("_BlendCubemaps", 0);
    }
}
