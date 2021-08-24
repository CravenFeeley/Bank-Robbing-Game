using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public enum Settings
    {
        PlayerCountSelection,
        SelectPlayers,
        TeamSelect,
        CharacterSelect,
        LoadGame
    }    
    public Settings settings;
    // Start is called before the first frame update
    void Start()
    {
        settings = Settings.PlayerCountSelection;
        GameDetails.player1.playerNumber = 1;
        GameDetails.player2.playerNumber = 2;
        GameDetails.player3.playerNumber = 3;
        GameDetails.player4.playerNumber = 4;
    }

    // Update is called once per frame
    void Update()
    {

        if(settings == Settings.LoadGame)
        {
            LoadLevel(sceneIndex: 1);
        }

    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;
        /*while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 9f);
            Debug.Log(progress);
            yield return null;
        }*/
        yield return (operation.progress > 0.9f);
        StartCoroutine(Loaded(operation));
    }

    IEnumerator Loaded (AsyncOperation sync)
    {
        yield return new WaitForSeconds(1);
        sync.allowSceneActivation = true;
    }



}
