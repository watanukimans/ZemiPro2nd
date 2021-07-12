using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class SendCardData : MonoBehaviourPunCallbacks
{
    //GameObject MainBrain; //自身のネットワークオブジェクトを格納
    private Text PlayerNum;
    // Start is called before the first frame update
    void Start()
    {
       // MainBrain = TestScene.My;
       //PlayerNum.text = $"{photonView.Owner.NickName}({photonView.OwnerActorNr})";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void Click1() //カードをクリックする
    {
        MainBrain.SendMessage("Select", this.gameObject.name);
    }
    */
}
