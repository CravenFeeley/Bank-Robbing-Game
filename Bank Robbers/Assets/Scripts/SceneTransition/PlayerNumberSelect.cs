using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNumberSelect : MonoBehaviour
{
    // Start is called before the first frame update

    public MenuButtons Mb;
    public SelectPlayers Sp;
        public enum PlayerAmount
    {
        TwoPlayer,
        FourPlayer
    }

    public PlayerAmount Players;

    public GameObject TwoPlayer;
    public GameObject TwoPlayerHighlight;
    public GameObject FourPlayer;
    public GameObject FourPlayerHighlight;

    public GameObject Title;

    public float startingtimer;
    public float currenttimer;
    public bool cooldown;

    public bool Loading;
    public float LoadingTime;



    void Start()
    {
        Mb = GameObject.Find("LevelLoader").GetComponent<MenuButtons>();
        Sp = GameObject.Find("LevelLoader").GetComponent<SelectPlayers>();
        TwoPlayerHighlight.SetActive(true);
        Players = PlayerAmount.TwoPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown == true)
        {
            currenttimer -= Time.deltaTime;
            if(currenttimer <= 0)
            {
                currenttimer = startingtimer;
                cooldown = false;
            }
        }

        if (Loading == true)
        {
            LoadingTime -= Time.deltaTime;
            if (LoadingTime <= 0)
            {
                LoadingTime = 0;

                Mb.settings = MenuButtons.Settings.SelectPlayers;
            }

        }


        if (Mb.settings == MenuButtons.Settings.PlayerCountSelection)
        {
            float vertical = Input.GetAxisRaw("Vertical Controller 1");
            if (cooldown == false)
            {

                switch (Players)
                {
                    case (PlayerAmount.TwoPlayer):
                        if (vertical < -0.1 || vertical > 0.1)
                        {
                            TwoPlayerHighlight.SetActive(false);
                            FourPlayerHighlight.SetActive(true);
                            Players = PlayerAmount.FourPlayer;
                            cooldown = true;
                        }


                        break;

                    case (PlayerAmount.FourPlayer):
                        if (vertical > 0.1 || vertical < -0.1)
                        {
                            TwoPlayerHighlight.SetActive(true);
                            FourPlayerHighlight.SetActive(false);
                            Players = PlayerAmount.TwoPlayer;
                            cooldown = true;

                        }

                        break;
                }
            }

            if (Players == PlayerAmount.TwoPlayer)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    TwoPlayerHighlight.SetActive(false);
                    twoPlayer();

                    Loading = true;


                }
            }

            if (Players == PlayerAmount.FourPlayer)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    FourPlayerHighlight.SetActive(false);
                    fourPlayer();
                    Loading = true;
                }
            }
        }
    }

    public void twoPlayer()
    {
        GameDetails.Players = 2;
        TwoPlayer.gameObject.SetActive(false);
        FourPlayer.gameObject.SetActive(false);
        Title.SetActive(false);
        Sp.TwoPlayerPanel.SetActive(true);
    }

    public void fourPlayer()
    {
        GameDetails.Players = 4;
        TwoPlayer.gameObject.SetActive(false);
        FourPlayer.gameObject.SetActive(false);
        Title.SetActive(false);
        Sp.FourPlayerPanel.SetActive(true);
    }
}
