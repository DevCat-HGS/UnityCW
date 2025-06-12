using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ButtonCredits : MonoBehaviourPunCallbacks {
    public GameObject CanvasCredits;


   public void ActivarCanvasCredits()
   {
     if (CanvasCredits != null)
     {
         CanvasCredits.SetActive(true);
     }
   }
   
   public void DesactivarCanvasCredits()
   {
     if (CanvasCredits != null)
     {
         CanvasCredits.SetActive(false);
     }
   }
}