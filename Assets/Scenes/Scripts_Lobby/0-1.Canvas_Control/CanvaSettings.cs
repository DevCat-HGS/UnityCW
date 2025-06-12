using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ButtonSettings : MonoBehaviourPunCallbacks {
    public GameObject CanvasSettings;


   public void ActivarCanvasSettings()
   {
     if (CanvasSettings != null)
     {
         CanvasSettings.SetActive(true);
     }
   }
   
   public void DesactivarCanvasSettings()
   {
     if (CanvasSettings != null)
     {
         CanvasSettings.SetActive(false);
     }
   }
}