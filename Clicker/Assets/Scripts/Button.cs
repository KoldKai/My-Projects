using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
       private MainMenu mainMenu;
       public GameObject effect;
       public GameObject button;

       void Awake()
       {
          mainMenu = GetComponent<MainMenu>();
       }

        public void OnDown()
        {
                mainMenu.money++;
                PlayerPrefs.SetInt("money", mainMenu.money); 
                Instantiate(effect, button.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
                button.transform.localScale = new Vector2 (0.95f, 0.95f);
        }

        public void OnUp()
        {
                button.transform.localScale = new Vector2 (1, 1);
        }
}