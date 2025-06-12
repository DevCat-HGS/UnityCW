using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CanvNamePlayer : MonoBehaviourPunCallbacks 
{
    public GameObject canvasNamePlayer; 

    public void ActivarCanvasName()
    {
        if (canvasNamePlayer != null)
        {
            canvasNamePlayer.SetActive(true);
        }
    }
   
    public void DesactivarCanvasName()
    {
        if (canvasNamePlayer != null)
        {
            canvasNamePlayer.SetActive(false);
        }
    }
}