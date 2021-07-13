using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] CardController cardPrefab;
    [SerializeField] Transform playerHand,EnemyHand;

    bool isPlayerTurn = true; 
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

    int Emotion = 10;
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
    public GameObject Yajirusi;
    Vector3 startSize;

    //ゲームスタートに関する表示
    public GameObject StartButtun;
    private bool nowgame;

    //ネット関連
    public TestScene NetManager;
    private int MyNumber; //自分が何番目のプレイヤーかどうか

    void Start()
    {
        nowgame = false;
        StartButtun.SetActive(false);
        //StartGame();
        //スタート前
        
    }

    public void GameStart() //スタートボタン押下時に作動する関数
    {
        Debug.Log("ゲームを開始します");
        StartButtun.SetActive(false);
        //Time.timeScale = 1;
        nowgame = true;
        StartGame();
    }

    void Update()
    {
        if (nowgame){
            //Debug.Log("相手のターンまで"+countDown);
            if (countDown >= 0)
            {
                countDown -= Time.deltaTime;
                UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
            }
            else if (countDown < 0)
            {
                GameObject[] Card10 = GameObject.FindGameObjectsWithTag("Card10");
                foreach (GameObject card10 in Card10)
                    GameObject.Destroy(card10);
                ChangeTurn();
            }

            //funamon

            if (isPlayerTurn) //プレイヤーがカードを引く
            {
                PlayerDeck.transform.position = new Vector3(350, 800, 0);
                EnemyDeck.transform.position = new Vector3(350, 80, 0);
            }
            else
            {
                PlayerDeck.transform.position = new Vector3(350, 80, 0);
                EnemyDeck.transform.position = new Vector3(350, 800, 0);
            }

        }
        else //ゲーム開始前
        {
            MyNumber = NetManager.Number;
            
            if(MyNumber >= 1) //入室完了したら、→以下ゲーム開始前の処理。ここでPlayer１かPlayer２かがわかります。今は同じ挙動するけど、Player１をここでいうPlayerにしてPlayer２をここでいうEnemyにしてやればうまく擬似的にできているように見えるはず
            {
                StartButtun.SetActive(true);

            }
        }
    }
    void StartGame()
    {
        // 初期手札を配る
        SetStartHand();

        // ターンの決定
        //TurnCalc();
    }

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
    /*
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
        CreateCard(cardID, hand);
    }
    void DrowCard3(Transform hand) // カードを引く
    {
        // デッキがないなら引かない
        if (deck.Count == 0)
        {
            return;
        }

        // デッキの一番上のカードを抜き取り、手札に加える
        int cardID = deck[0];
        deck.RemoveAt(0);
        CreateCard2(cardID, hand);
    }
    void DrowCard4(Transform hand) // カードを引く
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
    */
    void SetStartHand() // 手札を配る
    {
        //Shuffle();
        decknum = Random.Range(1, 3);
        switch (decknum)
        {
            case 1: //自分ジョーカー
                /*
                for (int i = 0; i < 11; i++)
                {
                    DrowCard(playerHand);
                }
                for (int i = 0; i < 11; i++)
                {
                    DrowCard4(EnemyHand);
                }
                */
                ChangeTurn();
                break;
            case 2: //相手ジョーカー
                /*
                for (int i = 0; i < 11; i++)
                {
                    DrowCard2(playerHand);
                }
                for (int i = 0; i < 11; i++)
                {
                    DrowCard3(EnemyHand);
                }
                */
                PlayerTurn();
                break;
        }
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
        ResetFace();
        MaxGauge();
        SetHand();
        turn++;
        Debug.Log(turn);
        //CreateCard2(10, EnemyHand);
        countDown = 5.0f;
        Debug.Log("Playerのターン");
    }

    void EnemyTurn()
    {
        //ChangeHand();
        Emotion = 10;
        ResetFace();
        MaxGauge();
        SetHand();
        turn++;
        Debug.Log(turn);
        //CreateCard(10, playerHand);
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
        //左目
        Transform elTransform = EyeL.transform;
        //大きさ
        elTransform.localScale = startSize;
        //振動
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
}
