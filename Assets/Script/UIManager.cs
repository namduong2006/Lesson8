using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]private Text speedText;
    [SerializeField]private Text lapText;
    [SerializeField]private Text posText;
    [SerializeField] private Text coinText;
    public Player player;
    private int maxlap = 12;
    private int pos = 1;
    float speed;
    float lap;
    // Update is called once per frame
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        lap = player.GetLapCount();
        speed = player.GetSpeed();
        speedText.text = speed.ToString("0.0");
        lapText.text = $"{lap}/{maxlap}";
        posText.text = pos.ToString();
        coinText.text=player.Getcoin().ToString();
    }
   
}
