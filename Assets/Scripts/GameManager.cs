using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] CardController cardPrefab;
    [SerializeField] Transform playerHand,EnemyHand;

    public bool isPlayerTurn = true; 
    List<int> deck = new List<int>() {};
    List<int> deck2 = new List<int>() {};
    public CardEntity cardEntity;
    public float countDown = 5.0f;
    public int turn = 0;
    public int decknum;
    //テスト用
    public int dCard;
    public int t1;
    public int t2;
    public int t3;
    public int t4;
    public int t5;
    public int t6;
    public int t7;
    public int t8;
    public int t9;
    public Image UIobj;
    public float countTime = 5.0f;


    //funamon変数
    public GameObject PlayerDeck;
    public GameObject EnemyDeck;
    //目の動く幅
    float vib = 0;
    float qvib = 0;
    //目の速さ
    int vibcount=25;
    int qvibcount = 25;
    int Emotion = 10;
    int QEmotion = 10;
    public GameObject UwamabutaR;
    public GameObject UwamabutaL;
    public GameObject SitamabutaR;
    public GameObject SitamabutaL;
    public GameObject EyeR;
    public GameObject EyeL;
    public GameObject NamidaR;
    public GameObject NamidaL;
    public GameObject MayuR;
    public GameObject MayuL;
    public GameObject Uwakutibiru;
    public GameObject Sitakutibiru;
    public GameObject QUwaMR;
    public GameObject QUwaML;
    public GameObject QSitaMR;
    public GameObject QSitaML;
    public GameObject QEyeR;
    public GameObject QEyeL;
    public GameObject QMayuR;
    public GameObject QMayuL;
    public GameObject QNamidaR;
    public GameObject QNamidaL;
    public GameObject QUwakutibiru;
    public GameObject QSitakutibiru;
    public GameObject Yajirusi;
    public RectTransform EyeRR;
    public RectTransform EyeLL;
    public RectTransform QEyeRR;
    public RectTransform QEyeLL;
    Vector3 startSize;

    
    public GameObject HaikeiETQ;
    public GameObject HaikeiETM;
    public GameObject MunkuBase;
    public GameObject MonarizaBase;
    

    //ゲームスタートに関する表示
    public GameObject StartButtun;
    public GameObject LoadImage;
    private bool nowgame;


    //ネット関連
    public TestScene NetManager;
    public int MyNumber; //自分が何番目のプレイヤーかどうか
    public GameObject MyAvator;
    public Text console;
    public int jokernum;
    public bool clicked; //クリックされたかどうかを判断
    public string selectedcard; //クリックされたカード

    void Start()
    {
        nowgame = false;
        StartButtun.SetActive(true);
        LoadImage.SetActive(true);
        //StartGame();
        //スタート前
        jokernum = 100;
        clicked = false;
        selectedcard = null;
    }

    public void GameStart() //スタートボタン押下時に作動する関数
    {
        if (MyNumber == 1)
        {
            Debug.Log("ゲームを開始します");
            StartButtun.SetActive(false);
        
            nowgame = true;
            StartGame();
        }
    }

    void Update()
    {
        //Debug.Log()
        if (nowgame){
            //Debug.Log(qvib);

            //Debug.Log("相手のターンまで"+countDown);
            
                if (countDown >= 0)
                {
                    countDown -= Time.deltaTime;
                    UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
                }
                else if (countDown < 0)
                {
                    clicked = false;
                    GameObject[] Card10 = GameObject.FindGameObjectsWithTag("Card10");
                    foreach (GameObject card10 in Card10)
                        GameObject.Destroy(card10);
                    ChangeTurn();
                }

            if (selectedcard != null) //カード選ばれた時
            {
                //Debug.Log("うんこ");
                if (isPlayerTurn) //攻撃側
                {
                    MyAvator.GetComponent<AvatarController>().IsGetCard(selectedcard);
                    //selectedcard = null;
                }
                else //守備側
                {

                }
            }
            
            //目の振動
            if (Emotion < 10)
            {
                EyeRR.position += new Vector3(vib, 0, 0);
                EyeLL.position += new Vector3(vib, 0, 0);
                vibcount++;
                if (vibcount == 50)
                {
                    vibcount = 0;
                    vib *= -1;
                }
            }
            if (QEmotion < 10)
            {
                QEyeRR.position += new Vector3(qvib, 0, 0);
                QEyeLL.position += new Vector3(qvib, 0, 0);
                qvibcount++;
                if (qvibcount == 50)
                {
                    qvibcount = 0;
                    qvib *= -1;
                }
            }
            //funamon

            if (isPlayerTurn) //プレイヤーがカードを引く
            {
                PlayerDeck.transform.position = new Vector3(350,1600,0);
                EnemyDeck.transform.position = new Vector3(720, 250, 0);
            }
            else
            {
                PlayerDeck.transform.position = new Vector3(720, 250, 0);
                EnemyDeck.transform.position = new Vector3(350, 1600, 0);
            }

            

        }
        else //ゲーム開始前
        {
            MyNumber = NetManager.Number;
            
            if(MyNumber >= 1) //入室完了したら、→以下ゲーム開始前の処理。ここでPlayer１かPlayer２かがわかります。今は同じ挙動するけど、Player１をここでいうPlayerにしてPlayer２をここでいうEnemyにしてやればうまく擬似的にできているように見えるはず
            {
                //StartButtun.SetActive(true);
                LoadImage.SetActive(false);
                //アバターを処理
                MyAvator = TestScene.My;

                if(MyNumber == 1) //Player１だったら
                {
                    ChangePlaceToPlayerTurnA();
                }
                else if(MyNumber == 2) //Player2だったら
                {
                    ChangePlaceToPlayerTurnB();
                    if (jokernum != 100) //どっちがジョーカーかわかる→スタート
                    {
                        Debug.Log("えはいzまっちゃいました？");
                        StartGame();
                    }
                }
            }
        }
    }
    void StartGame()
    {
        // 初期手札を配る
        if (MyNumber == 1) //プレイヤー１での処理を基準にジョーカーの場所を決める
        {
            Shuffle();
            decknum = Random.Range(1, 3);
            switch (decknum)
            {
                case 1: //自分ジョーカー
                    MyAvator.GetComponent<AvatarController>().IsGetJoker(2); //自分がジョーカーであることをAvatarに送信
                    ChangeTurn();
                    break;
                case 2: //相手ジョーカー
                    MyAvator.GetComponent<AvatarController>().IsGetJoker(1); //相手がジョーカーであることをAvatarに送信
                    PlayerTurn();
                    break;
            }
            //SetStartHand();

        }
        else if(MyNumber == 2)
        {
            Debug.Log("わたしは２");
            Debug.Log("ゲームを開始します");
            Shuffle();
            StartButtun.SetActive(false);
         
            nowgame = true;
            //console.text = MyAvator.GetComponent<AvatarController>().JokerNum.ToString();

            switch (jokernum)
            {
                case 1: //自分ジョーカー
                    //Debug.Log("ふ");
                    //MyAvator.GetComponent<AvatarController>().IsGetJoker(1); //自分がジョーカーであることをAvatarに送信
                    ChangeTurn();
                    break;
                case 2: //相手ジョーカー
                    //Debug.Log("ふふふ");
                    //MyAvator.GetComponent<AvatarController>().IsGetJoker(0); //相手がジョーカーであることをAvatarに送信
                    PlayerTurn();
                    break;
            }
        }
        // ターンの決定
        //TurnCalc();
    }

    /*
    void SetStartHand() // 手札を配る
    {
        //Shuffle();
        //decknum = Random.Range(1, 3);
        switch (decknum)
        {
            case 1: //自分ジョーカー
                MyAvator.GetComponent<AvatarController>().IsGetJoker(1); //自分がジョーカーであることをAvatarに送信
                ChangeTurn();
                break;
            case 2: //相手ジョーカー
                MyAvator.GetComponent<AvatarController>().IsGetJoker(0); //相手がジョーカーであることをAvatarに送信
                PlayerTurn();
                break;
        }
    }
    */

    public void CreateCard(int cardID, Transform place)
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID);
        //お試し用4行
        card.tag = "Card" + cardID;
    }
    public void CreateCard2(int cardID, Transform place)
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Initura(cardID);
        card.tag = "Card" + cardID;
    }
    void DrowCard(Transform hand) // カードを引く
    {
        // デッキがないなら引かない
        if (deck.Count == 0)
        {
            return;
        }

        // デッキの一番上のカードを抜き取り、手札に加える
        int cardID = deck[0];
        deck.RemoveAt(0);
        CreateCard(cardID, hand);
    }
    void DrowCard2(Transform hand) // カードを引く
    {
        // デッキがないなら引かない
        if (deck2.Count == 0)
        {
            return;
        }

        // デッキの一番上のカードを抜き取り、手札に加える
        int cardID = deck2[0];
        deck2.RemoveAt(0);
        CreateCard2(cardID, hand);
    }
    
    
    void TurnCalc() // ターンを管理する
    {
        if (isPlayerTurn)
        {
            PlayerTurn();
        }
        else
        {
            EnemyTurn();
        }
    }
    public void ChangeTurn() // ターンエンド処理
    {
        isPlayerTurn = !isPlayerTurn; // ターンを逆にする
        TurnCalc(); // ターンを相手に回す
    }
    void PlayerTurn()
    {
        //ChangeHand();
        Emotion = 10;
        QEmotion = 10;
        ResetFace();
        QResetFace();
        MaxGauge();
        SetHand();
        turn++;
        Debug.Log(turn);
        countDown = 5.0f;
        Debug.Log("Playerのターン");
    }

    void EnemyTurn()
    {
        //ChangeHand();
        Emotion = 10;
        QEmotion = 10;
        ResetFace();
        QResetFace();
        MaxGauge();
        SetHand();
        turn++;
        Debug.Log(turn);
        countDown = 5.0f;
        Debug.Log("Enemyのターン");
    }
    void Shuffle()
    {
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            int temp = deck[k];
            deck[k] = deck[n];
            deck[n] = temp;
        }

        //確認
        //for (int i = 0; i < 11; i++)
        //{
        //    Debug.Log(deck[i]);
        //}

        int m = deck2.Count;
        while (m > 1)
        {
            m--;
            int l = UnityEngine.Random.Range(0, m + 1);
            int temp2 = deck2[l];
            deck2[l] = deck2[m];
            deck2[m] = temp2;
        }
    }
    //ここから下未実装
    void SetHand()
    {
        //ターンごとの手札シャッフル
        ReShuffle();
        Shuffle();
        for (int i = 0; i < 11; i++)
        {
            DrowCard(playerHand);
        }
        for (int i = 0; i < 11; i++)
        {
            DrowCard2(EnemyHand);
        }
    }
    void ReShuffle()
    //ターンごとのデッキリストを定義
    {
        DeleteCard();
        Debug.Log(dCard);
        for (int n = 1; n < 11; n++)
        {
            deck.Remove(n);
            deck2.Remove(n);
        }
        for (int n = 1; n < 10; n++)
        {
            deck.Add(n);
            deck2.Add(n);
        }
        if (isPlayerTurn == true)
            {
                deck2.Add(10);
            }
            else
            {
                deck.Add(10);
            }
        if (dCard == 1)
        {
            deck.Remove(t1);
            deck2.Remove(t1);
        }
        if (dCard == 2)
        {
            deck.Remove(t1);
            deck.Remove(t2);
            deck2.Remove(t1);
            deck2.Remove(t2);
        }
        if (dCard == 3)
        {
            deck.Remove(t1);
            deck.Remove(t2);
            deck.Remove(t3);
            deck2.Remove(t1);
            deck2.Remove(t2);
            deck2.Remove(t3);
        }
        if (dCard == 4)
        {
            deck.Remove(t1);
            deck.Remove(t2);
            deck.Remove(t3);
            deck.Remove(t4);
            deck2.Remove(t1);
            deck2.Remove(t2);
            deck2.Remove(t3);
            deck2.Remove(t4);
        }
        if (dCard == 5)
        {
            deck.Remove(t1);
            deck.Remove(t2);
            deck.Remove(t3);
            deck.Remove(t4);
            deck.Remove(t5);
            deck2.Remove(t1);
            deck2.Remove(t2);
            deck2.Remove(t3);
            deck2.Remove(t4);
            deck2.Remove(t5);
        }
        if (dCard == 6)
        {
            deck.Remove(t1);
            deck.Remove(t2);
            deck.Remove(t3);
            deck.Remove(t4);
            deck.Remove(t5);
            deck.Remove(t6);
            deck2.Remove(t1);
            deck2.Remove(t2);
            deck2.Remove(t3);
            deck2.Remove(t4);
            deck2.Remove(t5);
            deck2.Remove(t6);
        }
        if (dCard == 7)
        {
            deck.Remove(t1);
            deck.Remove(t2);
            deck.Remove(t3);
            deck.Remove(t4);
            deck.Remove(t5);
            deck.Remove(t6);
            deck.Remove(t7);
            deck2.Remove(t1);
            deck2.Remove(t2);
            deck2.Remove(t3);
            deck2.Remove(t4);
            deck2.Remove(t5);
            deck2.Remove(t6);
            deck2.Remove(t7);
        }
        if (dCard == 8)
        {
            deck.Remove(t1);
            deck.Remove(t2);
            deck.Remove(t3);
            deck.Remove(t4);
            deck.Remove(t5);
            deck.Remove(t6);
            deck.Remove(t7);
            deck.Remove(t8);
            deck2.Remove(t1);
            deck2.Remove(t2);
            deck2.Remove(t3);
            deck2.Remove(t4);
            deck2.Remove(t5);
            deck2.Remove(t6);
            deck2.Remove(t7);
            deck2.Remove(t8);
        }
        if (dCard == 9)
        {
            deck.Remove(t1);
            deck.Remove(t2);
            deck.Remove(t3);
            deck.Remove(t4);
            deck.Remove(t5);
            deck.Remove(t6);
            deck.Remove(t7);
            deck.Remove(t8);
            deck.Remove(t9);
            deck2.Remove(t1);
            deck2.Remove(t2);
            deck2.Remove(t3);
            deck2.Remove(t4);
            deck2.Remove(t5);
            deck2.Remove(t6);
            deck2.Remove(t7);
            deck2.Remove(t8);
            deck2.Remove(t9);
            //勝利条件を満たした
        }
    }
    
    void DeleteCard()
    {
        GameObject[] Card1 = GameObject.FindGameObjectsWithTag("Card1");
        foreach (GameObject card1 in Card1)
            GameObject.Destroy(card1);
        GameObject[] Card2 = GameObject.FindGameObjectsWithTag("Card2");
        foreach (GameObject card2 in Card2)
            GameObject.Destroy(card2);
        GameObject[] Card3 = GameObject.FindGameObjectsWithTag("Card3");
        foreach (GameObject card3 in Card3)
            GameObject.Destroy(card3);
        GameObject[] Card4 = GameObject.FindGameObjectsWithTag("Card4");
        foreach (GameObject card4 in Card4)
            GameObject.Destroy(card4);
        GameObject[] Card5 = GameObject.FindGameObjectsWithTag("Card5");
        foreach (GameObject card5 in Card5)
            GameObject.Destroy(card5);
        GameObject[] Card6 = GameObject.FindGameObjectsWithTag("Card6");
        foreach (GameObject card6 in Card6)
            GameObject.Destroy(card6);
        GameObject[] Card7 = GameObject.FindGameObjectsWithTag("Card7");
        foreach (GameObject card7 in Card7)
            GameObject.Destroy(card7);
        GameObject[] Card8 = GameObject.FindGameObjectsWithTag("Card8");
        foreach (GameObject card8 in Card8)
            GameObject.Destroy(card8);
        GameObject[] Card9 = GameObject.FindGameObjectsWithTag("Card9");
        foreach (GameObject card9 in Card9)
            GameObject.Destroy(card9);
    }
    public void MaxGauge()
    {
        UIobj.fillAmount = 1;
    }
    //ターン切り替え時に絵の位置を移動
    
    void ChangePlaceToEnemyTurnA() //自身がプレイヤー１モナリザ、そして守備
    {
        HaikeiETQ.SetActive(true);
        RectTransform qTransform = MunkuBase.GetComponent<RectTransform>();
        qTransform.anchoredPosition = new Vector3(0, -63, 0); 
        RectTransform mTransform = MonarizaBase.GetComponent<RectTransform>();
        mTransform.anchoredPosition = new Vector3(276, -162, 0);
        
        //ヒエラルキーの順序を入れ替え
        Transform mp = GameObject.Find("MonarizaBase").transform;
        mp.SetSiblingIndex(2);
        Transform qp = GameObject.Find("MunkuBase").transform;
        qp.SetSiblingIndex(1);

    }
    void ChangePlaceToPlayerTurnA() //自身がプレイヤー１モナリザ、そして攻撃
    {
        HaikeiETQ.SetActive(false);
        RectTransform qTransform = MunkuBase.GetComponent<RectTransform>();
        qTransform.anchoredPosition = new Vector3(0,107,0);
        RectTransform mTransform = MonarizaBase.GetComponent<RectTransform>();
        mTransform.anchoredPosition = new Vector3(800, -63, 0);
        //ヒエラルキーの順序を入れ替え
        Transform mp = GameObject.Find("MonarizaBase").transform;
        mp.SetSiblingIndex(0);
        Transform qp = GameObject.Find("MunkuBase").transform;
        qp.SetSiblingIndex(4);
    }
    void ChangePlaceToEnemyTurnB() //自身がプレイヤー２ムンク、そして守備
    {
        HaikeiETM.SetActive(true);
        RectTransform qTransform = MunkuBase.GetComponent<RectTransform>();
        qTransform.anchoredPosition = new Vector3(266, 44, 0);
        RectTransform mTransform = MonarizaBase.GetComponent<RectTransform>();
        mTransform.anchoredPosition = new Vector3(266, 30, 0); 
        //ヒエラルキーの順序を入れ替え
        Transform mp = GameObject.Find("MonarizaBase").transform;
        mp.SetSiblingIndex(0);
        Transform qp = GameObject.Find("MunkuBase").transform;
        qp.SetSiblingIndex(3);

    }
    void ChangePlaceToPlayerTurnB()　//自身がプレイヤー２ムンク、そして攻撃
    {
        HaikeiETM.SetActive(false);
        RectTransform qTransform = MunkuBase.GetComponent<RectTransform>();
        qTransform.anchoredPosition = new Vector3(-800, 30, 0);
        RectTransform mTransform = MonarizaBase.GetComponent<RectTransform>();
        mTransform.anchoredPosition = new Vector3(0, -63, 0);
        //ヒエラルキーの順序を入れ替え
        Transform mp = GameObject.Find("MonarizaBase").transform;
        mp.SetSiblingIndex(4);
        Transform qp = GameObject.Find("MunkuBase").transform;
        qp.SetSiblingIndex(0);
    }
    

    //顔関連
    void UwamabutaMinus()
    {
        //右上瞼
        Transform umrTransform = UwamabutaR.transform;
        //位置
        Vector3 posr = umrTransform.localPosition;
        posr.y += 0.1f;
        umrTransform.localPosition = posr;
        //しなり
        //角度
        Vector3 localAngleR = umrTransform.localEulerAngles;
        localAngleR.z -= 5f;
        umrTransform.localEulerAngles = localAngleR;

        //左上瞼
        Transform umlTransform = UwamabutaL.transform;
        //位置
        Vector3 posl = umlTransform.localPosition;
        posl.y += 0.1f;
        umlTransform.localPosition = posl;
        //しなり
        //角度
        Vector3 localAngleL = umlTransform.localEulerAngles;
        localAngleL.z += 5f;
        umlTransform.localEulerAngles = localAngleL;
    }
    
    void UwamabutaPlus()
    {

        //右上瞼
        //位置
        Transform umrTransform = UwamabutaR.transform;
        Vector3 posr = umrTransform.localPosition;
        posr.y -= 0.1f;
        umrTransform.localPosition = posr;
        //しなり
        //角度
        Vector3 localAngleR = umrTransform.localEulerAngles;
        localAngleR.z += 5f;
        umrTransform.localEulerAngles = localAngleR;
        //左上瞼
        //位置
        Transform umlTransform = UwamabutaL.transform;
        Vector3 posl = umlTransform.localPosition;
        posl.y -= 0.1f;
        umlTransform.localPosition = posl;
        //しなり
        //角度
        Vector3 localAngleL = umlTransform.localEulerAngles;
        localAngleL.z -= 5f;
        umlTransform.localEulerAngles = localAngleL;

    }
    void SitamabutaMinus()
    {

        //右下瞼
        //位置
        Transform smrTransform = SitamabutaR.transform;
        Vector3 posr = smrTransform.localPosition;
        posr.y += 0.1f;
        smrTransform.localPosition = posr;
        //しなり
        //角度
        Vector3 localAngleR = smrTransform.localEulerAngles;
        localAngleR.z -= 5f;
        smrTransform.localEulerAngles = localAngleR;

        //左下瞼
        //位置
        Transform smlTransform = SitamabutaL.transform;
        Vector3 posl = smlTransform.localPosition;
        posl.y += 0.1f;
        smlTransform.localPosition = posl;
        //しなり
        //角度
        Vector3 localAngleL = smlTransform.localEulerAngles;
        localAngleL.z += 5f;
        smlTransform.localEulerAngles = localAngleL;


    }
    void SitamabutaPlus()
    {

        //右下瞼
        //位置
        Transform smrTransform = SitamabutaR.transform;
        Vector3 posr = smrTransform.localPosition;
        posr.y -= 0.1f;
        smrTransform.localPosition = posr;
        //しなり
        //角度
        Vector3 localAngleR = smrTransform.localEulerAngles;
        localAngleR.z += 5f;
        smrTransform.localEulerAngles = localAngleR;

        //左下瞼
        //位置
        Transform smlTransform = SitamabutaL.transform;
        Vector3 posl = smlTransform.localPosition;
        posl.y -= 0.1f;
        smlTransform.localPosition = posl;
        //しなり
        //角度
        Vector3 localAngleL = smlTransform.localEulerAngles;
        localAngleL.z -= 5f;
        smlTransform.localEulerAngles = localAngleL;

    }
    void EyeBallPlus()
    {

        Transform erTransform = EyeR.transform;
        //大きさ
        erTransform.localScale = new Vector3(
            erTransform.localScale.x * 1.1f,
            erTransform.localScale.y * 1.1f,
            erTransform.localScale.z
        );
        //振動
        if (vib>0)
        {
            vib -= 0.01f;
        }
        else
        {
            vib += 0.01f;
        }
        Transform elTransform = EyeL.transform;
        //大きさ
        elTransform.localScale = new Vector3(
            elTransform.localScale.x * 1.1f,
            elTransform.localScale.y * 1.1f,
            elTransform.localScale.z
        );
        //振動

    }
    void EyeBallMinus()
    {

        Transform erTransform = EyeR.transform;
        //大きさ
        erTransform.localScale = new Vector3(
            erTransform.localScale.x / 1.1f,
            erTransform.localScale.y / 1.1f,
            erTransform.localScale.z
        );
        //振動
        if (vib > 0)
        {
            vib += 0.01f;
        }
        else
        {
            vib -= 0.01f;
        }
    Transform elTransform = EyeL.transform;
        //大きさ
        elTransform.localScale = new Vector3(
            elTransform.localScale.x / 1.1f,
            elTransform.localScale.y / 1.1f,
            elTransform.localScale.z
        );
        //振動

    }
    void NamidaPlus()
    {
        if (Emotion == 10)
        {
            NamidaR.SetActive(false);
            NamidaL.SetActive(false);
        }
        else
        {
            NamidaR.SetActive(true);
            NamidaL.SetActive(true);
        }
        Transform nrTransform = NamidaR.transform;
        //大きさ
        nrTransform.localScale = new Vector3(
            nrTransform.localScale.x / 1.1f,
            nrTransform.localScale.y / 1.1f,
            nrTransform.localScale.z
       );

    Transform nlTransform = NamidaL.transform;
        //大きさ
        nlTransform.localScale = new Vector3(
            nlTransform.localScale.x / 1.1f,
            nlTransform.localScale.y / 1.1f,
            nlTransform.localScale.z
       );
    }
    void NamidaMinus()
    {
        if (Emotion == 10)
        {
            NamidaR.SetActive(false);
            NamidaL.SetActive(false);
        }
        else
        {
            NamidaR.SetActive(true);
            NamidaL.SetActive(true);
        }
        Transform nrTransform = NamidaR.transform;
        //大きさ
        nrTransform.localScale = new Vector3(
            nrTransform.localScale.x * 1.1f,
            nrTransform.localScale.y * 1.1f,
            nrTransform.localScale.z
       );

    Transform nlTransform = NamidaL.transform;
        //大きさ
        nlTransform.localScale = new Vector3(
            nlTransform.localScale.x * 1.1f,
            nlTransform.localScale.y * 1.1f,
            nlTransform.localScale.z
       );

    }
    void MayuPlus()
    {
        //右眉
        Transform mrTransform = MayuR.transform;
        //角度
        Vector3 localAngleR = mrTransform.localEulerAngles;
        localAngleR.z += 5f;
        mrTransform.localEulerAngles = localAngleR;
        //しなり

        //左眉
        Transform mlTransform = MayuL.transform;
        //角度
        Vector3 localAngleL = mlTransform.localEulerAngles;
        localAngleL.z -= 5f;
        mlTransform.localEulerAngles = localAngleL;
        //しなり
    }
    void MayuMinus()
    {
        //右眉
        Transform mrTransform = MayuR.transform;
        //角度
        Vector3 localAngleR = mrTransform.localEulerAngles;
        localAngleR.z -= 5f;
        mrTransform.localEulerAngles = localAngleR;
        //しなり

        //左眉
        Transform mlTransform = MayuL.transform;
        //角度
        Vector3 localAngleL = mlTransform.localEulerAngles;
        localAngleL.z += 5f;
        mlTransform.localEulerAngles = localAngleL;
        //しなり
    }
    void Mouth()
    {
        //しなり
        //開き具合
    }
    public void EmotionPlus()
    {
        if (Emotion < 20 && Emotion > 0)
        {
            Emotion++;
            
            UwamabutaPlus();
            SitamabutaPlus();
            EyeBallPlus();
            NamidaPlus();
            
        }
        else
        {
            return;
        }
    }
    
    public void EmotionMinus()
    {
        if (Emotion < 20 && Emotion > 0)
        {

            Emotion--;
            UwamabutaMinus();
            SitamabutaMinus();
            EyeBallMinus();
            NamidaMinus();
        }
        else
        {
            return;
        }
    }
    void ResetFace()
    {
        startSize = new Vector3(1f, 1f, 1f);
        //右上瞼
        Transform umrTransform = UwamabutaR.transform;
        //位置
        Vector3 posr = umrTransform.localPosition;
        posr.y = 56.7f;
        umrTransform.localPosition = posr;
        //しなり
        //角度
        Vector3 localAngleR = umrTransform.localEulerAngles;
        localAngleR.z = 0f;
        umrTransform.localEulerAngles = localAngleR;

        //左上瞼
        Transform umlTransform = UwamabutaL.transform;
        //位置
        Vector3 posl = umlTransform.localPosition;
        posl.y = 56.7f;
        umlTransform.localPosition = posl;
        //しなり
        //角度
        Vector3 localAngleL = umlTransform.localEulerAngles;
        localAngleL.z = 0f;
        umlTransform.localEulerAngles = localAngleL;

        //右下瞼
        //位置
        Transform smrTransform = SitamabutaR.transform;
        Vector3 possmr = smrTransform.localPosition;
        possmr.y = 56.7f;
        smrTransform.localPosition = possmr;
        //しなり
        //角度
        Vector3 localAnglesmR = smrTransform.localEulerAngles;
        localAnglesmR.z = 0f;
        smrTransform.localEulerAngles = localAnglesmR;

        //左下瞼
        //位置
        Transform smlTransform = SitamabutaL.transform;
        Vector3 possml = smlTransform.localPosition;
        possml.y = 56.7f;
        smlTransform.localPosition = possml;
        //しなり
        //角度
        Vector3 localAnglesmL = smlTransform.localEulerAngles;
        localAnglesmL.z = 0f;
        smlTransform.localEulerAngles = localAnglesmL;

        //右目
        Transform erTransform = EyeR.transform;
        //大きさ
        erTransform.localScale = startSize;
        //振動
        Vector3 posebr = erTransform.localPosition;
        posebr.x = 8.675928e-06f;
        erTransform.localPosition = posebr;
        vib = 0;
        vibcount = 25;
        //左目
        Transform elTransform = EyeL.transform;
        //大きさ
        elTransform.localScale = startSize;
        //振動
        Vector3 posebl = elTransform.localPosition;
        posebl.x = -14.09999f;
        elTransform.localPosition = posebl;
        //右涙
        Transform nrTransform = NamidaR.transform;
        //大きさ
        nrTransform.localScale = startSize;
        //左涙
         Transform nlTransform = NamidaL.transform;
        //大きさ
        nlTransform.localScale = startSize;
    }
    /*void ChangeHand()
    {
        Vector3 PHpos=playerHand.transform.position;
        Vector3 EHpos = EnemyHand.transform.position;
        EnemyHand.transform.position = PHpos;
        playerHand.transform.position = EHpos;
    }
    */
    //ここからムンク
    void QUwaMMinus()
    {
        //右上瞼
        Transform umrTransform = QUwaMR.transform;
        //位置
        Vector3 posr = umrTransform.localPosition;
        posr.y += 0.1f;
        umrTransform.localPosition = posr;
        //しなり
        //角度
        Vector3 localAngleR = umrTransform.localEulerAngles;
        localAngleR.z -= 5f;
        umrTransform.localEulerAngles = localAngleR;

        //左上瞼
        Transform umlTransform = QUwaML.transform;
        //位置
        Vector3 posl = umlTransform.localPosition;
        posl.y += 0.1f;
        umlTransform.localPosition = posl;
        //しなり
        //角度
        Vector3 localAngleL = umlTransform.localEulerAngles;
        localAngleL.z += 5f;
        umlTransform.localEulerAngles = localAngleL;
    }
    void QUwaMPlus()
    {
        //右上瞼
        //位置
        Transform umrTransform = QUwaMR.transform;
        Vector3 posr = umrTransform.localPosition;
        posr.y -= 0.1f;
        umrTransform.localPosition = posr;
        //しなり
        //角度
        Vector3 localAngleR = umrTransform.localEulerAngles;
        localAngleR.z += 5f;
        umrTransform.localEulerAngles = localAngleR;
        //左上瞼
        //位置
        Transform umlTransform = QUwaML.transform;
        Vector3 posl = umlTransform.localPosition;
        posl.y -= 0.1f;
        umlTransform.localPosition = posl;
        //しなり
        //角度
        Vector3 localAngleL = umlTransform.localEulerAngles;
        localAngleL.z -= 5f;
        umlTransform.localEulerAngles = localAngleL;
    }
    void QSitaMMinus()
    {
        //右下瞼
        //位置
        Transform smrTransform = QSitaMR.transform;
        Vector3 posr = smrTransform.localPosition;
        posr.y += 0.1f;
        smrTransform.localPosition = posr;
        //しなり
        //角度
        Vector3 localAngleR = smrTransform.localEulerAngles;
        localAngleR.z -= 5f;
        smrTransform.localEulerAngles = localAngleR;

        //左下瞼
        //位置
        Transform smlTransform = QSitaML.transform;
        Vector3 posl = smlTransform.localPosition;
        posl.y += 0.1f;
        smlTransform.localPosition = posl;
        //しなり
        //角度
        Vector3 localAngleL = smlTransform.localEulerAngles;
        localAngleL.z += 5f;
        smlTransform.localEulerAngles = localAngleL;
    }
    void QSitaMPlus()
    {
        //右下瞼
        //位置
        Transform smrTransform = QSitaMR.transform;
        Vector3 posr = smrTransform.localPosition;
        posr.y -= 0.1f;
        smrTransform.localPosition = posr;
        //しなり
        //角度
        Vector3 localAngleR = smrTransform.localEulerAngles;
        localAngleR.z += 5f;
        smrTransform.localEulerAngles = localAngleR;

        //左下瞼
        //位置
        Transform smlTransform = QSitaML.transform;
        Vector3 posl = smlTransform.localPosition;
        posl.y -= 0.1f;
        smlTransform.localPosition = posl;
        //しなり
        //角度
        Vector3 localAngleL = smlTransform.localEulerAngles;
        localAngleL.z -= 5f;
        smlTransform.localEulerAngles = localAngleL;
    }

    void QEyePlus()
    {
        Transform erTransform = QEyeR.transform;
        //大きさ
        erTransform.localScale = new Vector3(
            erTransform.localScale.x * 1.1f,
            erTransform.localScale.y * 1.1f,
            erTransform.localScale.z
        );
        //振動
        if (qvib < 0)
        {
            qvib += 0.01f;
        }
        else
        {
            qvib -= 0.01f;
        }
        Transform elTransform = QEyeL.transform;
        //大きさ
        elTransform.localScale = new Vector3(
            elTransform.localScale.x * 1.1f,
            elTransform.localScale.y * 1.1f,
            elTransform.localScale.z
        );
        //振動
    }
    void QEyeMinus()
    {
        Transform erTransform = QEyeR.transform;
        //大きさ
        erTransform.localScale = new Vector3(
            erTransform.localScale.x / 1.1f,
            erTransform.localScale.y / 1.1f,
            erTransform.localScale.z
        );
        //振動
        if (qvib >= 0)
        {
            qvib += 0.01f;
        }
        else
        {
            qvib -= 0.01f;
        }
        Transform elTransform = QEyeL.transform;
        //大きさ
        elTransform.localScale = new Vector3(
            elTransform.localScale.x / 1.1f,
            elTransform.localScale.y / 1.1f,
            elTransform.localScale.z
        );
        //振動
    }
    void QNamidaPlus()
    {
        if (QEmotion==10)
        {
            QNamidaR.SetActive(false);
            QNamidaL.SetActive(false);
        }
        else
        {
            QNamidaR.SetActive(true);
            QNamidaL.SetActive(true);
        }
        Transform nrTransform = QNamidaR.transform;
        //大きさ
        nrTransform.localScale = new Vector3(
            nrTransform.localScale.x / 1.1f,
            nrTransform.localScale.y / 1.1f,
            nrTransform.localScale.z
       );

        Transform nlTransform = QNamidaL.transform;
        //大きさ
        nlTransform.localScale = new Vector3(
            nlTransform.localScale.x / 1.1f,
            nlTransform.localScale.y / 1.1f,
            nlTransform.localScale.z
       );
    }
    void QNamidaMinus()
    {
        if (QEmotion == 10)
        {
            QNamidaR.SetActive(false);
            QNamidaL.SetActive(false);
        }
        else
        {
            QNamidaR.SetActive(true);
            QNamidaL.SetActive(true);
        }
        Transform nrTransform = QNamidaR.transform;
        //大きさ
        nrTransform.localScale = new Vector3(
            nrTransform.localScale.x * 1.1f,
            nrTransform.localScale.y * 1.1f,
            nrTransform.localScale.z
       );

        Transform nlTransform = QNamidaL.transform;
        //大きさ
        nlTransform.localScale = new Vector3(
            nlTransform.localScale.x * 1.1f,
            nlTransform.localScale.y * 1.1f,
            nlTransform.localScale.z
       );
    }
    void QMayuPlus()
    {
        //右眉
        Transform mrTransform = QMayuR.transform;
        //角度
        Vector3 localAngleR = mrTransform.localEulerAngles;
        localAngleR.z += 5f;
        mrTransform.localEulerAngles = localAngleR;
        //しなり

        //左眉
        Transform mlTransform = QMayuL.transform;
        //角度
        Vector3 localAngleL = mlTransform.localEulerAngles;
        localAngleL.z -= 5f;
        mlTransform.localEulerAngles = localAngleL;
        //しなり
    }
    void QMayuMinus()
    {
        //右眉
        Transform mrTransform = QMayuR.transform;
        //角度
        Vector3 localAngleR = mrTransform.localEulerAngles;
        localAngleR.z -= 5f;
        mrTransform.localEulerAngles = localAngleR;
        //しなり

        //左眉
        Transform mlTransform = QMayuL.transform;
        //角度
        Vector3 localAngleL = mlTransform.localEulerAngles;
        localAngleL.z += 5f;
        mlTransform.localEulerAngles = localAngleL;
        //しなり
    }
    public void QEmotionPlus()
    {
        if (QEmotion < 20 && QEmotion > 0)
        {
            QEmotion++;

            QUwaMPlus();
            QSitaMPlus();
            QEyePlus();
            QNamidaPlus();

        }
        else
        {
            return;
        }
    }
    public void QEmotionMinus()
    {
        if (QEmotion < 20 && QEmotion > 0)
        {

            QEmotion--;
            QUwaMMinus();
            QSitaMMinus();
            QEyeMinus();
            QNamidaMinus();
        }
        else
        {
            return;
        }
    }
    void QResetFace()
    {
        startSize = new Vector3(1f, 1f, 1f);
        //右上瞼
        Transform umrTransform = QUwaMR.transform;
        //位置
        Vector3 posr = umrTransform.localPosition;
        posr.y = 56.7f;
        umrTransform.localPosition = posr;
        //しなり
        //角度
        Vector3 localAngleR = umrTransform.localEulerAngles;
        localAngleR.z = 0f;
        umrTransform.localEulerAngles = localAngleR;

        //左上瞼
        Transform umlTransform = QUwaML.transform;
        //位置
        Vector3 posl = umlTransform.localPosition;
        posl.y = 56.7f;
        umlTransform.localPosition = posl;
        //しなり
        //角度
        Vector3 localAngleL = umlTransform.localEulerAngles;
        localAngleL.z = 0f;
        umlTransform.localEulerAngles = localAngleL;

        //右下瞼
        //位置
        Transform smrTransform = QSitaMR.transform;
        Vector3 possmr = smrTransform.localPosition;
        possmr.y = 56.7f;
        smrTransform.localPosition = possmr;
        //しなり
        //角度
        Vector3 localAnglesmR = smrTransform.localEulerAngles;
        localAnglesmR.z = 0f;
        smrTransform.localEulerAngles = localAnglesmR;

        //左下瞼
        //位置
        Transform smlTransform = QSitaML.transform;
        Vector3 possml = smlTransform.localPosition;
        possml.y = 56.7f;
        smlTransform.localPosition = possml;
        //しなり
        //角度
        Vector3 localAnglesmL = smlTransform.localEulerAngles;
        localAnglesmL.z = 0f;
        smlTransform.localEulerAngles = localAnglesmL;

        //右目
        Transform erTransform = QEyeR.transform;
        //大きさ
        erTransform.localScale = startSize;
        //振動
        Vector3 posebr = erTransform.localPosition;
        posebr.x = 22.13998f;
        erTransform.localPosition = posebr;
        qvib = 0f;
        qvibcount = 25;
        //左目
        Transform elTransform = QEyeL.transform;
        //大きさ
        elTransform.localScale = startSize;
        //振動
        Vector3 posebl = elTransform.localPosition;
        posebl.x = -4.100001f;
        elTransform.localPosition = posebl;
        //右涙
        Transform nrTransform = QNamidaR.transform;
        //大きさ
        nrTransform.localScale = startSize;
        //左涙
        Transform nlTransform = QNamidaL.transform;
        //大きさ
        nlTransform.localScale = startSize;
    }
}
