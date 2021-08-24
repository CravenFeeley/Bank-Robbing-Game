using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public GameObject GameManager;

    public GameObject HostageCharacter;
    public GameObject RobberCharacter;
    public GameObject HeavyRobber;
    public GameObject LightRobber;
    public GameObject Selection1;
    public GameObject Selection2;

    public GameObject Player;
    public GameManager GM;

    public MoveCamera cam;




    private void Start()
    {
        switch (GameDetails.Players)
        {


            case 2:

                TwoPlayerLoadIn();

                GM.GameLoaded = true;

                Destroy(gameObject);

                break;
            case 4:
                FourPlayerLoadIn();

                GM.GameLoaded = true;

                Destroy(gameObject);
                break;
        }
    }
    private void Awake()
    {
        cam = GameObject.Find("Camera").GetComponent<MoveCamera>();
        GameManager.SetActive(true);

        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.NumberofPlayers = GameDetails.Players;


        switch(GameDetails.Heisters[0].character)
        {
            case PlayerStats.PlayerCharacter.Balanced:
                Selection1 = RobberCharacter;
                break;

            case PlayerStats.PlayerCharacter.Light:
                Selection1 = LightRobber;
                break;

            case PlayerStats.PlayerCharacter.Heavy:
                Selection1 = HeavyRobber;
                break;
        }
        if (GameDetails.Heisters.Count > 1)
        {


            switch (GameDetails.Heisters[1].character)
            {
                case PlayerStats.PlayerCharacter.Balanced:
                    Selection2 = RobberCharacter;
                    break;

                case PlayerStats.PlayerCharacter.Light:
                    Selection2 = LightRobber;
                    break;

                case PlayerStats.PlayerCharacter.Heavy:
                    Selection2 = HeavyRobber;
                    break;
            }
        }

    }

    public void TwoPlayerLoadIn()
    {
        GameObject Hostage1 = Instantiate(HostageCharacter) as GameObject;
        Hostage1.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
        Hostage1.transform.position = Hostage1.GetComponent<HostageController>().TransportPoint.transform.position;
        GM.TransformPoints.Remove(Hostage1.GetComponent<HostageController>().TransportPoint);
        Hostage1.GetComponent<HostageController>().TransportPointInUse = true;
        cam.Targets.Add(Hostage1.transform);
        //GM.Hostages.Add(Hostage1);

        GameObject Hostage2 = Instantiate(HostageCharacter) as GameObject;
        Hostage2.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
        Hostage2.transform.position = Hostage2.GetComponent<HostageController>().TransportPoint.transform.position;
        GM.TransformPoints.Remove(Hostage2.GetComponent<HostageController>().TransportPoint);
        Hostage2.GetComponent<HostageController>().TransportPointInUse = true;
        cam.Targets.Add(Hostage2.transform);
        //GM.Hostages.Add(Hostage2);

        GameObject Hostage3 = Instantiate(HostageCharacter) as GameObject;
        Hostage3.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
        Hostage3.transform.position = Hostage3.GetComponent<HostageController>().TransportPoint.transform.position;
        GM.TransformPoints.Remove(Hostage3.GetComponent<HostageController>().TransportPoint);
        Hostage3.GetComponent<HostageController>().TransportPointInUse = true;
        cam.Targets.Add(Hostage3.transform);
        //GM.Hostages.Add(Hostage3);

        GameObject Hostage4 = Instantiate(HostageCharacter) as GameObject;
        Hostage4.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
        Hostage4.transform.position = Hostage4.GetComponent<HostageController>().TransportPoint.transform.position;
        GM.TransformPoints.Remove(Hostage4.GetComponent<HostageController>().TransportPoint);
        Hostage4.GetComponent<HostageController>().TransportPointInUse = true;
        cam.Targets.Add(Hostage4.transform);
        // GM.Hostages.Add(Hostage4);


        GameObject Robber1 = Instantiate(Selection1) as GameObject;
            Robber1.GetComponent<RobberController>().TransportPoint = GM.Robberspawns[Random.Range(0, GM.Robberspawns.Count)];
            Robber1.transform.position = Robber1.GetComponent<RobberController>().TransportPoint.transform.position;
            GM.TransformPoints.Remove(Robber1.GetComponent<RobberController>().TransportPoint);
            Robber1.GetComponent<RobberController>().TransportPointInUse = true;
        cam.Targets.Add(Robber1.transform);
        GM.Robbers.Add(Robber1);



        GameObject Player1 = Instantiate(Player) as GameObject;
        Player1.GetComponent<PlayerScript>().controllernumber = GameDetails.player1.controllerNumber;
        if (GameDetails.player1.controllerNumber == 0)
        {
            Player1.GetComponent<PlayerScript>().keyboardcontroller = true;
        }
        if (GameDetails.player1.team == PlayerStats.PlayerTeam.Heister)
        {
            Player1.GetComponent<PlayerScript>().playerteam = PlayerScript.Team.ROBBER;
            GM.RobberTeam.Add(Player1);
            GM.Robbers[0].GetComponent<RobberController>().Player = Player1;
            //GM.Robbers[0].GetComponentInChildren<PlayerController>().Player = Player1;
        }
        if (GameDetails.player1.team == PlayerStats.PlayerTeam.Hostage)
        {
            Player1.GetComponent<PlayerScript>().playerteam = PlayerScript.Team.HOSTAGE;
            GM.HostageTeam.Add(Player1);
        }
        GM.PlayerList.Add(Player1);
        GameObject Player2 = Instantiate(Player) as GameObject;
        Player2.GetComponent<PlayerScript>().controllernumber = GameDetails.player2.controllerNumber;
        if (GameDetails.player2.controllerNumber == 0)
        {
            Player2.GetComponent<PlayerScript>().keyboardcontroller = true;
        }
        if (GameDetails.player2.team == PlayerStats.PlayerTeam.Heister)
        {
            Player2.GetComponent<PlayerScript>().playerteam = PlayerScript.Team.ROBBER;
            GM.RobberTeam.Add(Player2);
            GM.Robbers[0].GetComponent<RobberController>().Player = Player2;
        }
        if (GameDetails.player2.team == PlayerStats.PlayerTeam.Hostage)
        {
            Player2.GetComponent<PlayerScript>().playerteam = PlayerScript.Team.HOSTAGE;
            GM.HostageTeam.Add(Player2);
        }
        GM.PlayerList.Add(Player2);
    }

    public void FourPlayerLoadIn()
    {
        GameObject Hostage1 = Instantiate(HostageCharacter) as GameObject;
        Hostage1.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
        Hostage1.transform.position = Hostage1.GetComponent<HostageController>().TransportPoint.transform.position;
        GM.TransformPoints.Remove(Hostage1.GetComponent<HostageController>().TransportPoint);
        Hostage1.GetComponent<HostageController>().TransportPointInUse = true;
        cam.Targets.Add(Hostage1.transform);
        //GM.Hostages.Add(Hostage1);

        GameObject Hostage2 = Instantiate(HostageCharacter) as GameObject;
        Hostage2.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
        Hostage2.transform.position = Hostage2.GetComponent<HostageController>().TransportPoint.transform.position;
        GM.TransformPoints.Remove(Hostage2.GetComponent<HostageController>().TransportPoint);
        Hostage2.GetComponent<HostageController>().TransportPointInUse = true;
        cam.Targets.Add(Hostage2.transform);
        //GM.Hostages.Add(Hostage2);

        GameObject Hostage3 = Instantiate(HostageCharacter) as GameObject;
        Hostage3.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
        Hostage3.transform.position = Hostage3.GetComponent<HostageController>().TransportPoint.transform.position;
        GM.TransformPoints.Remove(Hostage3.GetComponent<HostageController>().TransportPoint);
        Hostage3.GetComponent<HostageController>().TransportPointInUse = true;
        cam.Targets.Add(Hostage3.transform);
        //GM.Hostages.Add(Hostage3);

        GameObject Hostage4 = Instantiate(HostageCharacter) as GameObject;
        Hostage4.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
        Hostage4.transform.position = Hostage4.GetComponent<HostageController>().TransportPoint.transform.position;
        GM.TransformPoints.Remove(Hostage4.GetComponent<HostageController>().TransportPoint);
        Hostage4.GetComponent<HostageController>().TransportPointInUse = true;
        cam.Targets.Add(Hostage4.transform);
        // GM.Hostages.Add(Hostage4);

        GameObject Robber1 = Instantiate(Selection1) as GameObject;
        Robber1.GetComponent<RobberController>().TransportPoint = GM.Robberspawns[Random.Range(0, GM.Robberspawns.Count)];
        Robber1.transform.position = Robber1.GetComponent<RobberController>().TransportPoint.transform.position;
        GM.TransformPoints.Remove(Robber1.GetComponent<RobberController>().TransportPoint);
        Robber1.GetComponent<RobberController>().TransportPointInUse = true;
        cam.Targets.Add(Robber1.transform);
        GM.Robbers.Add(Robber1);

        GameObject Robber2 = Instantiate(Selection2) as GameObject;
        Robber2.GetComponent<RobberController>().TransportPoint = GM.Robberspawns[Random.Range(0, GM.Robberspawns.Count)];
        Robber2.transform.position = Robber2.GetComponent<RobberController>().TransportPoint.transform.position;
        GM.TransformPoints.Remove(Robber2.GetComponent<RobberController>().TransportPoint);
        Robber2.GetComponent<RobberController>().TransportPointInUse = true;
        cam.Targets.Add(Robber2.transform);
        GM.Robbers.Add(Robber2);

        GameObject Player1 = Instantiate(Player) as GameObject;
        Player1.GetComponent<PlayerScript>().controllernumber = GameDetails.player1.controllerNumber;
        if (GameDetails.player1.controllerNumber == 0)
        {
            Player1.GetComponent<PlayerScript>().keyboardcontroller = true;
        }
        if (GameDetails.player1.team == PlayerStats.PlayerTeam.Heister)
        {
            Player1.GetComponent<PlayerScript>().playerteam = PlayerScript.Team.ROBBER;
            GM.RobberTeam.Add(Player1);
            if(GM.Robbers[0].GetComponent<RobberController>().Player == null)
            {
                GM.Robbers[0].GetComponent<RobberController>().Player = Player1;
            }
            else
            {
                GM.Robbers[1].GetComponent<RobberController>().Player = Player1;
            }

        }
        if (GameDetails.player1.team == PlayerStats.PlayerTeam.Hostage)
        {
            Player1.GetComponent<PlayerScript>().playerteam = PlayerScript.Team.HOSTAGE;
            GM.HostageTeam.Add(Player1);
        }
        GM.PlayerList.Add(Player1);
        GameObject Player2 = Instantiate(Player) as GameObject;
        Player2.GetComponent<PlayerScript>().controllernumber = GameDetails.player2.controllerNumber;
        if (GameDetails.player2.controllerNumber == 0)
        {
            Player2.GetComponent<PlayerScript>().keyboardcontroller = true;
        }
        if (GameDetails.player2.team == PlayerStats.PlayerTeam.Heister)
        {
            Player2.GetComponent<PlayerScript>().playerteam = PlayerScript.Team.ROBBER;
            GM.RobberTeam.Add(Player2);
            if (GM.Robbers[0].GetComponent<RobberController>().Player == null)
            {
                GM.Robbers[0].GetComponent<RobberController>().Player = Player2;
            }
            else
            {
                GM.Robbers[1].GetComponent<RobberController>().Player = Player2;
            }
        }
        if (GameDetails.player2.team == PlayerStats.PlayerTeam.Hostage)
        {
            Player2.GetComponent<PlayerScript>().playerteam = PlayerScript.Team.HOSTAGE;
            GM.HostageTeam.Add(Player2);
        }
        GM.PlayerList.Add(Player2);

        GameObject Player3 = Instantiate(Player) as GameObject;
        Player3.GetComponent<PlayerScript>().controllernumber = GameDetails.player3.controllerNumber;
        if (GameDetails.player3.controllerNumber == 0)
        {
            Player3.GetComponent<PlayerScript>().keyboardcontroller = true;
        }
        if (GameDetails.player3.team == PlayerStats.PlayerTeam.Heister)
        {
            Player3.GetComponent<PlayerScript>().playerteam = PlayerScript.Team.ROBBER;
            GM.RobberTeam.Add(Player3);
            if (GM.Robbers[0].GetComponent<RobberController>().Player == null)
            {
                GM.Robbers[0].GetComponent<RobberController>().Player = Player3;
            }
            else
            {
                GM.Robbers[1].GetComponent<RobberController>().Player = Player3;
            }
        }
        if (GameDetails.player3.team == PlayerStats.PlayerTeam.Hostage)
        {
            Player3.GetComponent<PlayerScript>().playerteam = PlayerScript.Team.HOSTAGE;
            GM.HostageTeam.Add(Player3);
        }
        GM.PlayerList.Add(Player3);
        GameObject Player4 = Instantiate(Player) as GameObject;
        Player4.GetComponent<PlayerScript>().controllernumber = GameDetails.player4.controllerNumber;
        if (GameDetails.player4.controllerNumber == 0)
        {
            Player4.GetComponent<PlayerScript>().keyboardcontroller = true;
        }
        if (GameDetails.player4.team == PlayerStats.PlayerTeam.Heister)
        {
            Player4.GetComponent<PlayerScript>().playerteam = PlayerScript.Team.ROBBER;
            GM.RobberTeam.Add(Player4);
            if (GM.Robbers[0].GetComponent<RobberController>().Player == null)
            {
                GM.Robbers[0].GetComponent<RobberController>().Player = Player4;
            }
            else
            {
                GM.Robbers[1].GetComponent<RobberController>().Player = Player4;
            }
        }
        if (GameDetails.player4.team == PlayerStats.PlayerTeam.Hostage)
        {
            Player4.GetComponent<PlayerScript>().playerteam = PlayerScript.Team.HOSTAGE;
            GM.HostageTeam.Add(Player4);
        }
        GM.PlayerList.Add(Player4);
    }

}
