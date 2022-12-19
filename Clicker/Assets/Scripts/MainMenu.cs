using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] public int money;    
    public Text moneyText;    
    public GameObject button;

    private void Start()
    {
       
        money = PlayerPrefs.GetInt("money");
        StartCoroutine(IdleFarm());
        OfflineTime(); 
    }
    
    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money++;
        Debug.Log(money);
        PlayerPrefs.SetInt("money", money);
        StartCoroutine(IdleFarm());
    }

    private void OfflineTime()
    {
        TimeSpan ts;
        if (PlayerPrefs.HasKey("LastSession"))
        {
            ts = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            Debug.Log(string.Format("Вас не было {0} дней, {1} часов, {2} минут, {3} секунд", ts.Days, ts.Hours, ts.Minutes, ts.Seconds));
            money += (int)ts.TotalSeconds;
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
        }
    }
#else
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());

    }
#endif

    
    void Update()
    {
        moneyText.text = PlayerPrefs.GetInt("money").ToString();
    }
}
