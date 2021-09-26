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

    public float blendhenka;
    public float eyesizehenka;

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
    public float countDownReset=15f;


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

    public GameObject spotLight;
    public GameObject HaikeiETQ;
    public GameObject HaikeiETM;
    public GameObject MunkuBase;
    public GameObject MonarizaBase;

    public SkinnedMeshRenderer kutisitaMeshRenderer;
    public SkinnedMeshRenderer kutiueMeshRenderer;
    public SkinnedMeshRenderer leftmayuMeshRenderer;
    public SkinnedMeshRenderer leftnamidaMeshRenderer;
    public SkinnedMeshRenderer lefteyesitaMeshRenderer;
    public SkinnedMeshRenderer lefteyeueMeshRenderer;
    public SkinnedMeshRenderer rightmayuMeshRenderer;
    public SkinnedMeshRenderer rightnamidaMeshRenderer;
    public SkinnedMeshRenderer righteyesitaMeshRenderer;
    public SkinnedMeshRenderer righteyeueMeshRenderer;
    public GameObject kutisita;
    public GameObject kutiue;
    public GameObject leftmayu;
    public GameObject leftnamida;
    public GameObject lefteyesita;
    public GameObject lefteyeue;
    public GameObject rightmayu;
    public GameObject rightnamida;
    public GameObject righteyesita;
    public GameObject righteyeue;
    public SkinnedMeshRenderer mkutisitaMeshRenderer;
    public SkinnedMeshRenderer mkutiueMeshRenderer;
    public SkinnedMeshRenderer mleftmayuMeshRenderer;
    public SkinnedMeshRenderer mleftnamidaMeshRenderer;
    public SkinnedMeshRenderer mlefteyesitaMeshRenderer;
    public SkinnedMeshRenderer mlefteyeueMeshRenderer;
    public SkinnedMeshRenderer mrightmayuMeshRenderer;
    public SkinnedMeshRenderer mrightnamidaMeshRenderer;
    public SkinnedMeshRenderer mrighteyesitaMeshRenderer;
    public SkinnedMeshRenderer mrighteyeueMeshRenderer;
    public GameObject mkutisita;
    public GameObject mkutiue;
    public GameObject mleftmayu;
    public GameObject mleftnamida;
    public GameObject mlefteyesita;
    public GameObject mlefteyeue;
    public GameObject mrightmayu;
    public GameObject mrightnamida;
    public GameObject mrighteyesita;
    public GameObject mrighteyeue;
    public float h;//顔の変化量
    public float span = 0.1f;
    private float currentTime = 0f;
    public int j = 1;//顔の状態
    public float w = 0f;//ブレンドシェイプの値悲
    public float w2 = 0f;//ブレンドシェイプの値笑
    public float he;//目の変化量
    public float we =1f;
    public Image cardnum;
    

    //ゲームスタートに関する表示
    public GameObject StartButtun;
    public GameObject LoadImage;
    private bool nowgame;

    //ステータス
    public Image StatusMessage;
    public Sprite Attack;
    public Sprite Defence;

    public GameObject Result;
    public Image ResultMessage;
    public Sprite Win;
    public Sprite Lose;
    private bool finishflg;

    //ネット関連
    public TestScene NetManager;
    public int MyNumber; //自分が何番目のプレイヤーかどうか
    public GameObject MyAvator;
    private AvatarController avatarController;
    public Text console;
    public int jokernum;
    public bool clicked; //クリックされたかどうかを判断
    public int selectedcard; //クリックされたカード

    public Text LoginText;

    private AudioSource bgm;
    public AudioClip title;
    public AudioClip play; 

    /*
    public bool drowed;
    public int[] player1deck;
    private int deckcount1;
    public int[] player2deck;
    private int deckcount2;
    */

    //public bool P2go;

    void Start()
    {
        nowgame = false;
        StartButtun.SetActive(true);
        LoadImage.SetActive(true);
        //StartGame();
        //スタート前
        jokernum = 100;
        clicked = false;
        selectedcard = 0;
        //
        kutisita = GameObject.Find("MonarizaIndivi/Kutisita");
        kutisitaMeshRenderer = kutisita.GetComponent<SkinnedMeshRenderer>();
        kutiue = GameObject.Find("MonarizaIndivi/Kutiue");
        kutiueMeshRenderer = kutiue.GetComponent<SkinnedMeshRenderer>();
        leftmayu = GameObject.Find("MonarizaIndivi/LeftEyemayu");
        leftmayuMeshRenderer = leftmayu.GetComponent<SkinnedMeshRenderer>();
        leftnamida = GameObject.Find("MonarizaIndivi/LeftEyenamida");
        leftnamidaMeshRenderer = leftnamida.GetComponent<SkinnedMeshRenderer>();
        lefteyesita = GameObject.Find("MonarizaIndivi/LeftEyesita");
        lefteyesitaMeshRenderer = lefteyesita.GetComponent<SkinnedMeshRenderer>();
        lefteyeue = GameObject.Find("MonarizaIndivi/LeftEyeue");
        lefteyeueMeshRenderer = lefteyeue.GetComponent<SkinnedMeshRenderer>();
        rightmayu = GameObject.Find("MonarizaIndivi/RightEyemayu");
        rightmayuMeshRenderer = rightmayu.GetComponent<SkinnedMeshRenderer>();
        rightnamida = GameObject.Find("MonarizaIndivi/RightEyenamida");
        rightnamidaMeshRenderer = rightnamida.GetComponent<SkinnedMeshRenderer>();
        righteyesita = GameObject.Find("MonarizaIndivi/RightEyesita");
        righteyesitaMeshRenderer = righteyesita.GetComponent<SkinnedMeshRenderer>();
        righteyeue = GameObject.Find("MonarizaIndivi/RightEyeue");
        righteyeueMeshRenderer = righteyeue.GetComponent<SkinnedMeshRenderer>();

        mkutisita = GameObject.Find("munkuFBX/MunkuKutisita");
        mkutisitaMeshRenderer = mkutisita.GetComponent<SkinnedMeshRenderer>();
        mkutiue = GameObject.Find("munkuFBX/MunkuKutiue");
        mkutiueMeshRenderer = mkutiue.GetComponent<SkinnedMeshRenderer>();
        mleftmayu = GameObject.Find("munkuFBX/MunkuLeftEyemayu");
        mleftmayuMeshRenderer = mleftmayu.GetComponent<SkinnedMeshRenderer>();
        mleftnamida = GameObject.Find("munkuFBX/MunkuLeftEyenamida");
        mleftnamidaMeshRenderer = mleftnamida.GetComponent<SkinnedMeshRenderer>();
        mlefteyesita = GameObject.Find("munkuFBX/MunkuLeftEyesita");
        mlefteyesitaMeshRenderer = mlefteyesita.GetComponent<SkinnedMeshRenderer>();
        mlefteyeue = GameObject.Find("munkuFBX/MunkuLeftEyeue");
        mlefteyeueMeshRenderer = mlefteyeue.GetComponent<SkinnedMeshRenderer>();
        mrightmayu = GameObject.Find("munkuFBX/MunkuRightEyemayu");
        mrightmayuMeshRenderer = mrightmayu.GetComponent<SkinnedMeshRenderer>();
        mrightnamida = GameObject.Find("munkuFBX/MunkuRightEyenamida");
        mrightnamidaMeshRenderer = mrightnamida.GetComponent<SkinnedMeshRenderer>();
        mrighteyesita = GameObject.Find("munkuFBX/MunkuRightEyesita");
        mrighteyesitaMeshRenderer = mrighteyesita.GetComponent<SkinnedMeshRenderer>();
        mrighteyeue = GameObject.Find("munkuFBX/MunkuRightEyeue");
        mrighteyeueMeshRenderer = mrighteyeue.GetComponent<SkinnedMeshRenderer>();


        finishflg = false;
        bgm = this.gameObject.GetComponent<AudioSource>();
        //drowed = false;
        //deckcount1 = 0;
        //deckcount2 = 0;

        //P2go = false;
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
        //Debug.Log(w);
        if (!finishflg)
        {
            if (nowgame)
            {
                /*
                Debug.Log(deck[0]);
                Debug.Log(deck[1]);
                Debug.Log(deck2[0]);
                Debug.Log(deck2[1]);
                */
                //Debug.Log(qvib);

                //Debug.Log("相手のターンまで"+countDown);

                /*
                if (MyNumber == 2) //カード情報の受け取り
                {
                    for(int u=0; u < 10; u++)
                    {
                        player1deck[u] = avatarController.sendP1cards[u];
                        player2deck[u] = avatarController.sendP2cards[u];
                    }
                }
                */
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

                if (selectedcard != 0) //カード選ばれた時
                {
                    //Debug.Log("うんこ");
                    if (isPlayerTurn) //攻撃側
                    {
                        avatarController.IsGetCard(selectedcard);
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
                //顔の変化
                currentTime += Time.deltaTime;
                if (currentTime > span)
                {
                    currentTime = 0f;
                    if (j == 0)
                    {
                        if (w <= 100)
                        {
                            w += h;
                            if (we >= 1)
                            {
                                we += he;
                            }
                            Transform erTransform = EyeR.transform;
                            //大きさ
                            erTransform.localScale = new Vector3(
                                erTransform.localScale.x / we,
                                erTransform.localScale.y / we,
                                erTransform.localScale.z);
                            Transform elTransform = EyeL.transform;
                            //大きさ
                            elTransform.localScale = new Vector3(
                                elTransform.localScale.x / we,
                                elTransform.localScale.y / we,
                                elTransform.localScale.z
                            );
                            Transform qelTransform = QEyeL.transform;
                            //大きさ
                            qelTransform.localScale = new Vector3(
                                qelTransform.localScale.x / we,
                                qelTransform.localScale.y / we,
                                qelTransform.localScale.z
                            );
                            Transform qerTransform = QEyeR.transform;
                            //大きさ
                            qerTransform.localScale = new Vector3(
                                qerTransform.localScale.x / we,
                                qerTransform.localScale.y / we,
                                qerTransform.localScale.z
                            );
                        }
                    }
                    kutisitaMeshRenderer.SetBlendShapeWeight(0, w);
                    kutiueMeshRenderer.SetBlendShapeWeight(0, w);
                    leftmayuMeshRenderer.SetBlendShapeWeight(0, w);
                    leftnamidaMeshRenderer.SetBlendShapeWeight(0, w);
                    lefteyesitaMeshRenderer.SetBlendShapeWeight(0, w);
                    lefteyeueMeshRenderer.SetBlendShapeWeight(0, w);
                    rightmayuMeshRenderer.SetBlendShapeWeight(0, w);
                    rightnamidaMeshRenderer.SetBlendShapeWeight(0, w);
                    righteyesitaMeshRenderer.SetBlendShapeWeight(0, w);
                    righteyeueMeshRenderer.SetBlendShapeWeight(0, w);
                    mkutisitaMeshRenderer.SetBlendShapeWeight(0, w);
                    mkutiueMeshRenderer.SetBlendShapeWeight(0, w);
                    mleftmayuMeshRenderer.SetBlendShapeWeight(0, w);
                    mleftnamidaMeshRenderer.SetBlendShapeWeight(0, w);
                    mlefteyesitaMeshRenderer.SetBlendShapeWeight(0, w);
                    mlefteyeueMeshRenderer.SetBlendShapeWeight(0, w);
                    mrightmayuMeshRenderer.SetBlendShapeWeight(0, w);
                    mrightnamidaMeshRenderer.SetBlendShapeWeight(0, w);
                    mrighteyesitaMeshRenderer.SetBlendShapeWeight(0, w);
                    mrighteyeueMeshRenderer.SetBlendShapeWeight(0, w);

                    kutisitaMeshRenderer.SetBlendShapeWeight(1, w2);
                    kutiueMeshRenderer.SetBlendShapeWeight(1, w2);
                    leftmayuMeshRenderer.SetBlendShapeWeight(1, w2);
                    leftnamidaMeshRenderer.SetBlendShapeWeight(1, w2);
                    lefteyesitaMeshRenderer.SetBlendShapeWeight(1, w2);
                    lefteyeueMeshRenderer.SetBlendShapeWeight(1, w2);
                    rightmayuMeshRenderer.SetBlendShapeWeight(1, w2);
                    rightnamidaMeshRenderer.SetBlendShapeWeight(1, w2);
                    righteyesitaMeshRenderer.SetBlendShapeWeight(1, w2);
                    righteyeueMeshRenderer.SetBlendShapeWeight(1, w2);
                    mkutisitaMeshRenderer.SetBlendShapeWeight(1, w2);
                    mkutiueMeshRenderer.SetBlendShapeWeight(1, w2);
                    mleftmayuMeshRenderer.SetBlendShapeWeight(1, w2);
                    mleftnamidaMeshRenderer.SetBlendShapeWeight(1, w2);
                    mlefteyesitaMeshRenderer.SetBlendShapeWeight(1, w2);
                    mlefteyeueMeshRenderer.SetBlendShapeWeight(1, w2);
                    mrightmayuMeshRenderer.SetBlendShapeWeight(1, w2);
                    mrightnamidaMeshRenderer.SetBlendShapeWeight(1, w2);
                    mrighteyesitaMeshRenderer.SetBlendShapeWeight(1, w2);
                    mrighteyeueMeshRenderer.SetBlendShapeWeight(1, w2);

                }
                //funamon

                if (isPlayerTurn) //プレイヤーがカードを引く
                {
                    PlayerDeck.transform.position = new Vector3(350, 1600, 0);
                    EnemyDeck.transform.position = new Vector3(17.5f, 12, 0);
                }
                else
                {
                    PlayerDeck.transform.position = new Vector3(17.5f, 12, 0);
                    EnemyDeck.transform.position = new Vector3(350, 1600, 0);
                }

                if (MyNumber == 1) //プレイヤー１モナリザ
                {
                    if (isPlayerTurn) //攻撃
                    {
                        ChangePlaceToPlayerTurnA();
                    }
                    else //守備
                    {
                        ChangePlaceToEnemyTurnA();
                    }
                }
                else if (MyNumber == 2) //プレイヤー２ムンク
                {
                    if (isPlayerTurn) //攻撃
                    {
                        ChangePlaceToPlayerTurnB();
                    }
                    else //守備
                    {
                        ChangePlaceToEnemyTurnB();
                    }
                }



            }
            else //ゲーム開始前
            {
                MyNumber = NetManager.Number;

                if (MyNumber >= 1) //入室完了したら、→以下ゲーム開始前の処理。ここでPlayer１かPlayer２かがわかります。今は同じ挙動するけど、Player１をここでいうPlayerにしてPlayer２をここでいうEnemyにしてやればうまく擬似的にできているように見えるはず
                {
                    if (MyNumber < 3) //プレイヤー１か２まで入室可能
                    {
                        //StartButtun.SetActive(true);
                        LoadImage.SetActive(false);
                        //アバターを処理
                        MyAvator = TestScene.My;
                        avatarController = MyAvator.GetComponent<AvatarController>();
                        if (MyNumber == 1) //Player１だったら
                        {
                            ChangePlaceToPlayerTurnA();
                        }
                        else if (MyNumber == 2) //Player2だったら
                        {
                            ChangePlaceToPlayerTurnB();
                            if (jokernum != 100) //どっちがジョーカーかわかる→スタート
                            {
                                Debug.Log("えはいzまっちゃいました？");

                                StartGame();

                            }
                        }
                    }
                    else
                    {
                        LoginText.text = "現在入室禁止です";
                    }
                }
            }
        }
    }
    void StartGame()
    {
        bgm.clip = play;
        bgm.Play();
        // 初期手札を配る
        if (MyNumber == 1) //プレイヤー１での処理を基準にジョーカーの場所を決める
        {
            Shuffle();
            decknum = Random.Range(1, 3);
            switch (decknum)
            {
                case 1: //自分ジョーカー
                    avatarController.IsGetJoker(2); //自分がジョーカーであることをAvatarに送信
                    ChangeTurn();
                    break;
                case 2: //相手ジョーカー
                    avatarController.IsGetJoker(1); //相手がジョーカーであることをAvatarに送信
                    PlayerTurn();
                    StatusMessage.gameObject.SetActive(true);
                    if (isPlayerTurn) //攻撃
                    {
                        StatusMessage.sprite = Attack;
                    }
                    else //守備
                    {
                        StatusMessage.sprite = Defence;
                    }
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
                    StatusMessage.gameObject.SetActive(true);
                    if (isPlayerTurn) //攻撃
                    {
                        StatusMessage.sprite = Attack;
                    }
                    else //守備
                    {
                        StatusMessage.sprite = Attack;
                    }
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
        /*
        if (MyNumber == 1)
        {
            player1deck[deckcount1] = deck[0];
            avatarController.IsRailCard1(deckcount1, player1deck[deckcount1]);
            deckcount1++;
        }
        */
            //Debug.Log(deck[0]);
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
        /*
        if (MyNumber == 1)
        {
            player2deck[deckcount2] = deck2[0];
            avatarController.IsRailCard2(deckcount2, player2deck[deckcount2]);
            deckcount2++;
        }
            */
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
        StatusMessage.gameObject.SetActive(true);
        if (isPlayerTurn) //攻撃
        {
            StatusMessage.sprite = Attack;
        }
        else //守備
        {
            StatusMessage.sprite = Defence;
        }

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
        countDown = countDownReset;
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
        countDown = countDownReset;
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
    
    void SetHand()
    {
        //ターンごとの手札シャッフル
        
        ReShuffle();
        Shuffle();
        /*
        if(MyNumber == 2)
        {
            for (int j = 0; j < deck.Count; j++)
            {
                deck[j] = player1deck[j];
                deck2[j] = player2deck[j];
            }
        }
        */
        for (int i = 0; i < 11; i++)
        {
            //player1deck[i] = deck[i];
            DrowCard(playerHand);
            //drowed = true;
        }
        for (int i = 0; i < 11; i++)
        {
            //player2deck[i] = deck2[i];
            DrowCard2(EnemyHand);
            //drowed = true;
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
            Debug.Log("おわった");
            Invoke("Result", 1.0f);
            finishflg = true;
        }
    }

    void ResultMethod()
    {
        Result.SetActive(true);
        ResultMessage.sprite = Win;
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
        //スポットライトを消す
        spotLight.SetActive(false);
        RectTransform qTransform = MunkuBase.GetComponent<RectTransform>();
        qTransform.anchoredPosition = new Vector3(0, 1000, 0); 
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
        spotLight.SetActive(true);
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
        spotLight.SetActive(false);
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
        spotLight.SetActive(true);
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
    void EyeBallPlus()
    {
        //振動
        if (vib>0)
        {
            vib -= 0.0003f;
        }
        else
        {
            vib += 0.0003f;
        }
    }
    void EyeBallMinus()
    {
        //振動
        if (vib > 0)
        {
            vib += 0.0003f;
        }
        else
        {
            vib -= 0.0003f;
        }
    }
    public void EmotionPlus()
    {
        if (Emotion < 20 && Emotion > 0)
        {
            if (h > blendhenka)
            {
                h -= blendhenka;
            }
            he -= eyesizehenka;
            Emotion++;
            EyeBallPlus(); 
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
            h+=blendhenka;
            he += eyesizehenka;
            Emotion--;
            EyeBallMinus();
        }
        else
        {
            return;
        }
    }
    void ResetFace()
    {
        startSize = new Vector3(1f, 1f, 1f);
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
        w = 0;
        w2 = 0;
        h = 0;
        j = 1;
        we = 1f;
        he = 0;
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
    void QEyePlus()
    {
        //振動
        if (qvib < 0)
        {
            qvib += 0.0003f;
        }
        else
        {
            qvib -= 0.0003f;
        }
    }
    void QEyeMinus()
    {
        //振動
        if (qvib >= 0)
        {
            qvib += 0.0003f;
        }
        else
        {
            qvib -= 0.0003f;
        }
    }
    public void QEmotionPlus()
    {
        if (QEmotion < 20 && QEmotion > 0)
        {
            QEmotion++;
            QEyePlus();
            /*
            QUwaMPlus();
            QSitaMPlus();
            
            QNamidaPlus();
            */
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
            QEyeMinus();
            QEmotion--;
        }
        else
        {
            return;
        }
    }
    void QResetFace()
    {
        startSize = new Vector3(1f, 1f, 1f);
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
    /*
    void EmotionMinusA()
    {

        //kutisitaMeshRenderer.SetBlendShapeWeight(1, 100);
        //kutisitaMeshRenderer.SetBlendShapeWeight(0, 100);
        StartCoroutine(EmotionMinusCoroutine());

    }

　　private IEnumerator EmotionMinusCoroutine()
    {
        yield return null;
    }
    */

    public void Quit()
    {
        #if UNITY_EDITOR
              UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
              UnityEngine.Application.Quit();
        #endif
    }
}
