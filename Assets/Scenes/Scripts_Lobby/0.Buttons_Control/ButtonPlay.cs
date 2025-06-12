using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ButtonPlay : MonoBehaviourPunCallbacks {
    public GameObject CanvasPlay;


   public void ActivarCanvasPlay()
   {
     if (CanvasPlay != null)
     {
         CanvasPlay.SetActive(true);
     }
   }
   
   public void DesactivarCanvasPlay()
   {
     if (CanvasPlay != null)
     {
         CanvasPlay.SetActive(false);
     }
   }
}