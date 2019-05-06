using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreen : MonoBehaviour
{
   public void OnPlayClick()
   {
      MenuManager.Instance.ShowGameMenu();
   }
}
