using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> PlayerList = new List<GameObject>();
    public List<GameObject> HostageTeam = new List<GameObject>();
    public List<GameObject> RobberTeam = new List<GameObject>();
    public int HostageCount;
    public List<GameObject> Hostages = new List<GameObject>();
    public List<GameObject> HostagesControlled = new List<GameObject>();
    public List<GameObject> HostagesScared = new List<GameObject>();
    public List<GameObject> HostagesAvailable = new List<GameObject>();
    public List<GameObject> Robbers = new List<GameObject>();
    public List<Material> Materials = new List<Material>();

    public List<Transform> PowerUpPoints = new List<Transform>();
    public Transform PowerUpPosition;
    public float PowerupTimer = 5f;
    public float PowerUpTimeStart;
    public GameObject Powerup;

    public int NumberofPlayers;

    public List<Transform> Robberspawns = new List<Transform>();
    public List<Transform> TransformPoints = new List<Transform>();

    public float Countdown;
    public TextMeshProUGUI Countdowntext;
    public TextMeshProUGUI Countdowntext2;
    public TextMeshProUGUI Getdown;
    public Image GetdownImage;
    public float GetDownTimer;

    public GameObject PlayerSelectScreen;
    public GameObject Welcome1;
    public GameObject Welcome2;
    public GameObject Welcome3;
    public GameObject Welcome4;
    public GameObject TeamSelectScreen;
    public GameObject Hostage1;
    public GameObject Hostage2;
    public GameObject Hostage3;
    public GameObject Hostage4;
    public GameObject Robber1;
    public GameObject Robber2;
    public GameObject Robber3;
    public GameObject Robber4;

    public bool GameLoaded;

    public GameObject keycardowner;

    public Image Keycard;
    public MoveCamera cam;

    public enum PlayerSelect
    {
        LOADING,
        EVERYBODYDOWN,
        COMPLETED,
        NOTHING,
    }
    public PlayerSelect playerselect;

    private void Awake()
    {
    }

    void Start()
    {
        PowerupTimer = PowerUpTimeStart;
        GetdownImage.fillAmount = 0;


        cam = GameObject.Find("Camera4").GetComponent<MoveCamera>();


    }



    void Update()
    {
        switch (playerselect)
        {
            case (PlayerSelect.LOADING):
                if(GameLoaded == true)
                {
                    int random = Random.Range(0, Hostages.Count);
                    keycardowner = Hostages[random];
                    keycardowner.GetComponent<HostageController>().keycardowner = true;
                    playerselect = PlayerSelect.EVERYBODYDOWN;

                }
                break;

            case (PlayerSelect.EVERYBODYDOWN):
                GetdownImage.gameObject.SetActive(true);
                GetDownTimer += Time.deltaTime;
                float calc_cooldown = GetDownTimer * 2;
                GetdownImage.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
                if(GetDownTimer >= 2)
                {
                    playerselect = PlayerSelect.COMPLETED;  
                }
                break;

            case (PlayerSelect.COMPLETED):
                GetDownTimer -= Time.deltaTime;
                float calc_cooldown2 = GetDownTimer / 2;
                GetdownImage.fillAmount = Mathf.Clamp(calc_cooldown2, 0, 1);
                if (GetDownTimer <= 0)
                {
                    GetDownTimer = 0;
                    GetdownImage.gameObject.SetActive(false);
                    Countdown -= Time.deltaTime;
                    Countdowntext2.gameObject.SetActive(true);

                    if (Countdown >= 2)
                    {
                        Countdowntext2.text = "" + (Countdown + 1).ToString("F0");
                    }
                    else if(Countdown <= 2)
                    {
                        Countdowntext2.gameObject.SetActive(false);
                        Countdowntext.gameObject.SetActive(true);
                        Countdowntext.text = "" + (Countdown + 1).ToString("F0");
                    }


                    
                    if (Countdown <= -1)
                    {
                        Countdown = 0;
                        Countdowntext.text = "GO!";
                        Countdowntext.gameObject.SetActive(false);
                        playerselect = PlayerSelect.NOTHING;
                    }
                    
                }

                
                break;

            case (PlayerSelect.NOTHING):
                PowerupTimer -= Time.deltaTime;
                if(PowerupTimer <= 0)
                {
                    PowerUpPosition = PowerUpPoints[Random.Range(0, PowerUpPoints.Count)];


                    GameObject PowerUp = Instantiate(Powerup) as GameObject;
                    PowerUp.GetComponent<CollectScript>().collectabletype = CollectScript.Collectabletype.SHOUT;
                    PowerUp.GetComponent<CollectScript>().collectibleWeight = 1;
                    PowerUp.transform.position = PowerUpPosition.position;
                    PowerUp.GetComponent<CollectScript>().Position = PowerUpPosition;
                    PowerUpPoints.Remove(PowerUpPosition);
                    PowerupTimer = PowerUpTimeStart;
                }
                break;
        }    
    }
}
