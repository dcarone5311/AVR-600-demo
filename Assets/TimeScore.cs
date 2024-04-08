using UnityEngine;
using TMPro;
public class TimeScore : MonoBehaviour
{
    public TextMeshProUGUI TimeText, CoinsText, Victory;
    public int coins, TotalCoins;
    private AudioSource audio;
    public AudioClip winSound;
    private float time;
    private bool played;

    // Start is called before the first frame update
    void Start()
    {
        played = false;
        time = 0f;
        coins = 0; //start with none collected
        TotalCoins = GameObject.FindGameObjectsWithTag("Collectable").Length; //get how many gems are present.
        TimeText.text = "0.00s";
        CoinsText.text = "0/0";
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        string seconds = (time % 60).ToString("0#.00");
        string minutes = Mathf.FloorToInt(time / 60).ToString("0#");

        TimeText.text = minutes + ":" + seconds;
        if (TotalCoins == 0)
        {

            CoinsText.text = "";
        }
        else
        {

            CoinsText.text = "Coins Collected: " + coins.ToString() + '/' + TotalCoins.ToString();
        }

        if (coins == TotalCoins && played == false)
        {
            Victory.gameObject.SetActive(true);
            gameObject.transform.Find("Particle System").gameObject.SetActive(true);
            audio.clip = winSound;
            audio.Play(0);
            played = true;
        }
    }
}