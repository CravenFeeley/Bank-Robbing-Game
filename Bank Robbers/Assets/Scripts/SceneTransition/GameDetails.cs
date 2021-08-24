using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDetails : MonoBehaviour
{

    public static int Players;

    public enum PlayerTeam
    {
        Hostage,
        Heister
    }
    public static PlayerTeam player1team;

    public static PlayerTeam player2team;

    public static PlayerTeam player3team;

    public static PlayerTeam player4team;

    public static PlayerStats player1 = new PlayerStats();
    public static PlayerStats player2 = new PlayerStats();
    public static PlayerStats player3 = new PlayerStats();
    public static PlayerStats player4 = new PlayerStats();
    public static List<int> ControllerNumber = new List<int>();

    public static List<PlayerStats> Heisters = new List<PlayerStats>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
