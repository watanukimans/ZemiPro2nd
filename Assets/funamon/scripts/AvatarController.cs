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
    public int select;
    //private float Btimer;


    private GameObject Manager;
    private GameManager manager;

    /*
    public int[] sendP1cards = new int[10];
    public int[] sendP2cards = new int[10];

    public int one;
    public int two;
    public int three;
    public int four;
    public int five;
    public int six;
    public int seven;
    public int eight;
    public int nine;
    public int ten;
    */
    //private bool P2goes;
    // Start is called before the first frame update
    void Start()
    {
        GetNum = 100;
        JokerNum = 100;
        select = 0;
        //Btimer = 5.0f;

        Manager = GameObject.Find("GameManager");
        manager = Manager.GetComponent<GameManager>();

        /*
        for(int s=0; s < 10; s++)
        {
            sendP1cards[s] = 0;
            sendP2cards[s] = 0;
        }

        one = 0;
        two = 0;
        three = 0;
        four = 5;
        five = 0;
        six = 0;
        seven = 0;
        eight = 0;
        nine = 0;
        ten = 0;
        */
        //P2goes = false;
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
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            /*
            one = sendP1cards[0];
            two = sendP1cards[1];
            three = sendP1cards[2];
            four = sendP1cards[3];
            five = sendP1cards[4];
            six = sendP1cards[5];
            seven = sendP1cards[6];
            eight = sendP1cards[7];
            nine = sendP1cards[8];
            ten = sendP1cards[9];
            */
        }
        else if(PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            //Debug.Log("ううう");
            /*
            sendP1cards[0] = one;
            sendP1cards[1] = two;
            sendP1cards[2] = three;
            sendP1cards[3] = four;
            sendP1cards[4] = five;
            sendP1cards[5] = six;
            sendP1cards[6] = seven;
            sendP1cards[7] = eight;
            sendP1cards[8] = nine;
            sendP1cards[9] = ten;
            */
        }

        //P2goes = manager.P2go;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //Debug.Log("そうしん");
        if (stream.IsWriting)
        {
            // 自身のアバターのスタミナを送信する
            if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
            {
                stream.SendNext(JokerNum);
                //Debug.Log("おまえは" + JokerNum + "だ");

                
                //if (manager.drowed)
                //{
                 /*
                 stream.SendNext(one);
                 stream.SendNext(two);
                 stream.SendNext(three);
                 stream.SendNext(four);
                 stream.SendNext(five);
                 stream.SendNext(six);
                 stream.SendNext(seven);
                 stream.SendNext(eight);
                 stream.SendNext(nine);
                 stream.SendNext(ten);

                Debug.Log(one + "を送信中");
                 */

                 //manager.drowed = false;
                   
                //}
                
            }

            if (manager.isPlayerTurn) //攻撃側
            {
                if (manager.clicked) //もしカードが選択されたら
                {
                    stream.SendNext(select);
                    manager.selectedcard = 0;
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

                
                Debug.Log("おくれてる？");
                /*
                one = (int)stream.ReceiveNext();
                two = (int)stream.ReceiveNext();
                three = (int)stream.ReceiveNext();
                four = (int)stream.ReceiveNext();
                five = (int)stream.ReceiveNext();
                six = (int)stream.ReceiveNext();
                seven = (int)stream.ReceiveNext();
                eight = (int)stream.ReceiveNext();
                nine = (int)stream.ReceiveNext();
                ten = (int)stream.ReceiveNext();
                sendP1cards[0] = one;
                sendP1cards[1] = two;
                sendP1cards[2] = three;
                sendP1cards[3] = four;
                sendP1cards[4] = five;
                sendP1cards[5] = six;
                sendP1cards[6] = seven;
                sendP1cards[7] = eight;
                sendP1cards[8] = nine;
                sendP1cards[9] = ten;
                */
            }

            if (manager.isPlayerTurn == false) //守備側
            {
                select = (int)stream.ReceiveNext();
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

    public void IsGetCard(int card)
    {
        select = card;
    }

    /*
    public void IsRailCard1(int count, int cards)
    {
        sendP1cards[count] = cards;
    }

    public void IsRailCard2(int count2, int cards2)
    {
        sendP2cards[count2] = cards2;
    }
    */
    

    
}
