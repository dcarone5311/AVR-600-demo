using UnityEngine;
using TMPro;
public class TimeScore : MonoBehaviour
{
    public TextMeshProUGUI TimeText, CoinsText;
    public int coins, TotalCoins;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        coins = 0; //start with none collected
        TotalCoins = GameObject.FindGameObjectsWithTag("Collectable").Length; //get how many gems are present.
        TimeText.text = "0.00s";
        CoinsText.text = "0/0";

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
    }
}