using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ButtonShop : MonoBehaviourPunCallbacks {
    public GameObject CanvasShop;

   public void ActivarCanvasShop()
   {
     if (CanvasShop != null)
     {
         CanvasShop.SetActive(true);
     }
   }
   
   public void DesactivarCanvasShop()
   {
     if (CanvasShop != null)
     {
         CanvasShop.SetActive(false);
     }
   }
}