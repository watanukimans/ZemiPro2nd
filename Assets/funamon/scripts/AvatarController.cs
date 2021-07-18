using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class AvatarController :  MonoBehaviourPunCallbacks, IPunObservable
{
    //public Text SelectText;

    public int GetNum;
    public int JokerNum;
    public string select;
    //private float Btimer;


    private GameObject Manager;
    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        GetNum = 100;
        JokerNum = 100;
        select = "何か";
        //Btimer = 5.0f;

        Manager = GameObject.Find("GameManager");
        manager = Manager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //自身が生成したオブジェクトのみ移動処理をする
        if (photonView.IsMine)
        {
            var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            transform.Translate(6f * Time.deltaTime * input.normalized);

            if(GetNum != 100)
            {
                JokerNum = GetNum;
                GetNum = 100;
            }

            
        }

        //反映させる
        
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Debug.Log("そうしん");
        if (stream.IsWriting)
        {
            // 自身のアバターのスタミナを送信する
            if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
            {
                stream.SendNext(JokerNum);
                Debug.Log("おまえは" + JokerNum + "だ");
            }

            if (manager.isPlayerTurn) //攻撃側
            {
                if (manager.clicked) //もしカードが選択されたら
                {
                    stream.SendNext(select);
                    manager.selectedcard = null;
                    manager.clicked = false; //わんちけす
                }
            }
        }
        else
        {
            // 他プレイヤーのアバターのスタミナを受信する
            if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
            {
                JokerNum = (int)stream.ReceiveNext();
                manager.jokernum = JokerNum;
            }

            if (!manager.isPlayerTurn) //守備側
            {
                select = (string)stream.ReceiveNext();
                manager.selectedcard = select;
                Debug.Log(manager.selectedcard + "がきた");
            }
        }
    
    }

    public void IsGetJoker(int joker)
    {
        //Debug.Log(joker);
        //Debug.Log("そうしん");
        GetNum = joker;
    }

    public void IsGetCard(string card)
    {
        select = card;
    }

    

    
}
