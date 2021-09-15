using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public int start_coin_amount;
    public Text coin_amount;

    public static int current_coin_amount;
    
    // Start is called before the first frame update
    void Start()
    {
        current_coin_amount = start_coin_amount;
    }

    // Update is called once per frame
    void Update()
    {
        coin_amount.text = current_coin_amount.ToString();
    }
}
