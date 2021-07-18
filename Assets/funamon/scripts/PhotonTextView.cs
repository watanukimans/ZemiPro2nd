using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonTextView : MonoBehaviour, IPunObservable
{
    private PhotonView photonView;

    public string _text;

    public Text u;

    public string Text
    {
        get { return _text; }
        set { _text = value; RequestOwner(); }
    }

    void Awake()
    {
        this.photonView = GetComponent<PhotonView>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Debug.Log("そうしん");
        // オーナーの場合
        if (stream.IsWriting)
        {
            Debug.Log("そうしん");
            stream.SendNext(this._text);
        }
        // オーナー以外の場合
        else
        {
            this._text = (string)stream.ReceiveNext();
        }
    }

    private void RequestOwner()
    {
        if (this.photonView.IsMine == false)
        {
            if (this.photonView.OwnershipTransfer != OwnershipOption.Request)
                Debug.LogError("OwnershipTransferをRequestに変更してください。");
            else
                this.photonView.RequestOwnership();
        }
    }
}