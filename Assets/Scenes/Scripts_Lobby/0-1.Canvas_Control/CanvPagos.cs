using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CanvPagos : MonoBehaviourPunCallbacks
{
    public GameObject CanvasPagos;

    public void ActivarCanvasPagos()
    {
        if (CanvasPagos != null)
        {
            CanvasPagos.SetActive(true);
        }
    }

    public void DesactivarCanvasPagos()
    {
        if (CanvasPagos != null)
        {
            CanvasPagos.SetActive(false);
        }
    }

}