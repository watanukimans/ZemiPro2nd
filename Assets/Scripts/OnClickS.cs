using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Threading;
using UnityEditor;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClickS : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject panel;
    public Image cardImage;
    public Sprite ace;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;
    public Sprite joker;
    float seconds;

    //数字関連
    
    public Sprite zero;
    public Sprite one;
    public Sprite ntwo;
    public Sprite nthree;
    public Sprite nfour;
    public Sprite nfive;
    public Sprite nsix;
    public Sprite nseven;
    public Sprite neight;
    public Sprite nnine;

    public float reset;

    public int selectCard;

    private void Update()
    {
        if (GameManager.Instance.isPlayerTurn == false) //守備側
        {
            if (GameManager.Instance.selectedcard != 0) //カード情報が送られてきた時
            {
                SelectClick();

                //GameManager.Instance.selectedcard = "";
            }
        }
    }

    public void SelectClick()
    {
        reset=GameManager.Instance.countDownReset; 
        //Debug.Log(GameManager.Instance.selectedcard + "が選ばれているよ");
        /*
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        pos.y += 100f;
        myTransform.position = pos;
        */
        // クリックされた時に行いたい処理
        //Debug.Log("押されたよ");
        if (this.gameObject.tag == "Card" + GameManager.Instance.selectedcard && this.gameObject.tag == "Card1")
        {
            Transform myTransform = this.transform;
            //Vector3 pos = myTransform.position;
            //pos.y += 100f;
            //myTransform.position = pos;
            myTransform.localPosition = new Vector3(150, 300, 1);

            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = ace;
            GameObject[] Card1 = GameObject.FindGameObjectsWithTag("Card1");
            foreach (GameObject card1 in Card1)
                GameObject.Destroy(card1, 1.0f);
            GameManager.Instance.countDown = reset;
            //お試し
            ReDeck(1);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
            GameManager.Instance.selectedcard = 0;
        }
        if (this.gameObject.tag == "Card" + GameManager.Instance.selectedcard && this.gameObject.tag == "Card2")
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;
            pos.y += 100f;
            myTransform.position = pos;

            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = two;
            GameObject[] Card2 = GameObject.FindGameObjectsWithTag("Card2");
            foreach (GameObject card2 in Card2)
                GameObject.Destroy(card2, 1.0f);
            GameManager.Instance.countDown = reset;
            ReDeck(2);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
            GameManager.Instance.selectedcard = 0;
        }
        if (this.gameObject.tag == "Card" + GameManager.Instance.selectedcard && this.gameObject.tag == "Card3")
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;
            pos.y += 100f;
            myTransform.position = pos;

            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = three;
            GameObject[] Card3 = GameObject.FindGameObjectsWithTag("Card3");
            foreach (GameObject card3 in Card3)
                GameObject.Destroy(card3, 1.0f);
            GameManager.Instance.countDown = reset;
            ReDeck(3);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
            GameManager.Instance.selectedcard = 0;
        }
        if (this.gameObject.tag == "Card" + GameManager.Instance.selectedcard && this.gameObject.tag == "Card4")
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;
            pos.y += 100f;
            myTransform.position = pos;

            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = four;
            GameObject[] Card4 = GameObject.FindGameObjectsWithTag("Card4");
            foreach (GameObject card4 in Card4)
                GameObject.Destroy(card4, 1.0f);
            GameManager.Instance.countDown = reset;
            ReDeck(4);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
            GameManager.Instance.selectedcard = 0;
        }
        if (this.gameObject.tag == "Card" + GameManager.Instance.selectedcard && this.gameObject.tag == "Card5")
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;
            pos.y += 100f;
            myTransform.position = pos;

            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = five;
            GameObject[] Card5 = GameObject.FindGameObjectsWithTag("Card5");
            foreach (GameObject card5 in Card5)
                GameObject.Destroy(card5, 1.0f);
            GameManager.Instance.countDown = reset;
            ReDeck(5);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
            GameManager.Instance.selectedcard = 0;
        }
        if (this.gameObject.tag == "Card" + GameManager.Instance.selectedcard && this.gameObject.tag == "Card6")
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;
            pos.y += 100f;
            myTransform.position = pos;

            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = six;
            GameObject[] Card6 = GameObject.FindGameObjectsWithTag("Card6");
            foreach (GameObject card6 in Card6)
                GameObject.Destroy(card6, 1.0f);
            GameManager.Instance.countDown = reset;
            ReDeck(6);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
            GameManager.Instance.selectedcard = 0;
        }
        if (this.gameObject.tag == "Card" + GameManager.Instance.selectedcard && this.gameObject.tag == "Card7")
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;
            pos.y += 100f;
            myTransform.position = pos;

            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = seven;
            GameObject[] Card7 = GameObject.FindGameObjectsWithTag("Card7");
            foreach (GameObject card7 in Card7)
                GameObject.Destroy(card7, 1.0f);
            GameManager.Instance.countDown = reset;
            ReDeck(7);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
            GameManager.Instance.selectedcard = 0;
        }
        if (this.gameObject.tag == "Card" + GameManager.Instance.selectedcard && this.gameObject.tag == "Card8")
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;
            pos.y += 100f;
            myTransform.position = pos;

            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = eight;
            GameObject[] Card8 = GameObject.FindGameObjectsWithTag("Card8");
            foreach (GameObject card8 in Card8)
                GameObject.Destroy(card8, 1.0f);
            GameManager.Instance.countDown = reset;
            ReDeck(8);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
            GameManager.Instance.selectedcard = 0;
        }
        if (this.gameObject.tag == "Card"+GameManager.Instance.selectedcard && this.gameObject.tag == "Card9")
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;
            pos.y += 100f;
            myTransform.position = pos;

            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = nine;
            GameObject[] Card9 = GameObject.FindGameObjectsWithTag("Card9");
            foreach (GameObject card9 in Card9)
                GameObject.Destroy(card9, 1.0f);
            GameManager.Instance.countDown = reset;
            ReDeck(9);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
            GameManager.Instance.selectedcard = 0;
        }
        if (this.gameObject.tag == "Card" + GameManager.Instance.selectedcard && this.gameObject.tag == "Card10")
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;
            pos.y += 100f;
            myTransform.position = pos;

            Invoke("GMChangeTurn", 1);
            cardImage.sprite = joker;
            GameObject[] Card10 = GameObject.FindGameObjectsWithTag("Card10");
            foreach (GameObject card10 in Card10)
                GameObject.Destroy(card10, 1.0f);
            GameManager.Instance.countDown = reset;
            //GameManager.Instance.ChangeTurn();
            //GMChangeTurn();
            GameManager.Instance.selectedcard = 0;
        }
    }


    public void OnPointerClick(PointerEventData eventData) //自分で選択した時
    {
        if (GameManager.Instance.isPlayerTurn)
        {
            //Debug.Log(eventData);
            reset = GameManager.Instance.countDownReset;
            //Y座標を移動
            Transform myTransform = this.transform;
            //Vector3 pos = myTransform.localPosition;
            //pos.y += 100f;
            myTransform.localPosition = new Vector3(150, 300, 1);
            // クリックされた時に行いたい処理
            Debug.Log("押されたよ");
            if (this.gameObject.CompareTag("Card1"))
            {
                //ゲージカウントをリセット
                GameManager.Instance.MaxGauge();
                cardImage.sprite = ace;
                GameObject[] Card1 = GameObject.FindGameObjectsWithTag("Card1");
                foreach (GameObject card1 in Card1)
                    GameObject.Destroy(card1, 1.0f);
                GameManager.Instance.countDown = reset;
                //お試し
                ReDeck(1);
                Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
                selectCard = 1;
            }
            if (this.gameObject.CompareTag("Card2"))
            {
                //ゲージカウントをリセット
                GameManager.Instance.MaxGauge();
                cardImage.sprite = two;
                GameObject[] Card2 = GameObject.FindGameObjectsWithTag("Card2");
                foreach (GameObject card2 in Card2)
                    GameObject.Destroy(card2, 1.0f);
                GameManager.Instance.countDown = reset;
                ReDeck(2);
                Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
                selectCard = 2;
            }
            if (this.gameObject.CompareTag("Card3"))
            {
                //ゲージカウントをリセット
                GameManager.Instance.MaxGauge();
                cardImage.sprite = three;
                GameObject[] Card3 = GameObject.FindGameObjectsWithTag("Card3");
                foreach (GameObject card3 in Card3)
                    GameObject.Destroy(card3, 1.0f);
                GameManager.Instance.countDown = reset;
                ReDeck(3);
                Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
                selectCard = 3;
            }
            if (this.gameObject.CompareTag("Card4"))
            {
                //ゲージカウントをリセット
                GameManager.Instance.MaxGauge();
                cardImage.sprite = four;
                GameObject[] Card4 = GameObject.FindGameObjectsWithTag("Card4");
                foreach (GameObject card4 in Card4)
                    GameObject.Destroy(card4, 1.0f);
                GameManager.Instance.countDown = reset;
                ReDeck(4);
                Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
                selectCard = 4;
            }
            if (this.gameObject.CompareTag("Card5"))
            {
                //ゲージカウントをリセット
                GameManager.Instance.MaxGauge();
                cardImage.sprite = five;
                GameObject[] Card5 = GameObject.FindGameObjectsWithTag("Card5");
                foreach (GameObject card5 in Card5)
                    GameObject.Destroy(card5, 1.0f);
                GameManager.Instance.countDown = reset;
                ReDeck(5);
                Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
                selectCard = 5;
            }
            if (this.gameObject.CompareTag("Card6"))
            {
                //ゲージカウントをリセット
                GameManager.Instance.MaxGauge();
                cardImage.sprite = six;
                GameObject[] Card6 = GameObject.FindGameObjectsWithTag("Card6");
                foreach (GameObject card6 in Card6)
                    GameObject.Destroy(card6, 1.0f);
                GameManager.Instance.countDown = reset;
                ReDeck(6);
                Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
                selectCard = 6;
            }
            if (this.gameObject.CompareTag("Card7"))
            {
                //ゲージカウントをリセット
                GameManager.Instance.MaxGauge();
                cardImage.sprite = seven;
                GameObject[] Card7 = GameObject.FindGameObjectsWithTag("Card7");
                foreach (GameObject card7 in Card7)
                    GameObject.Destroy(card7, 1.0f);
                GameManager.Instance.countDown = reset;
                ReDeck(7);
                Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
                selectCard = 7;
            }
            if (this.gameObject.CompareTag("Card8"))
            {
                //ゲージカウントをリセット
                GameManager.Instance.MaxGauge();
                cardImage.sprite = eight;
                GameObject[] Card8 = GameObject.FindGameObjectsWithTag("Card8");
                foreach (GameObject card8 in Card8)
                    GameObject.Destroy(card8, 1.0f);
                GameManager.Instance.countDown =reset;
                ReDeck(8);
                Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
                selectCard = 8;
            }
            if (this.gameObject.CompareTag("Card9"))
            {
                //ゲージカウントをリセット
                GameManager.Instance.MaxGauge();
                cardImage.sprite = nine;
                GameObject[] Card9 = GameObject.FindGameObjectsWithTag("Card9");
                foreach (GameObject card9 in Card9)
                    GameObject.Destroy(card9, 1.0f);
                GameManager.Instance.countDown = reset;
                ReDeck(9);
                Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
                selectCard = 9;
            }
            if (this.gameObject.CompareTag("Card10"))
            {
                Invoke("GMChangeTurn", 1);
                cardImage.sprite = joker;
                GameObject[] Card10 = GameObject.FindGameObjectsWithTag("Card10");
                foreach (GameObject card10 in Card10)
                    GameObject.Destroy(card10, 1.0f);
                GameManager.Instance.countDown = reset;
                //GameManager.Instance.ChangeTurn();
                //GMChangeTurn();
                selectCard = 10;
            }


            //ネット関連
            GameManager.Instance.clicked = true;
            GameManager.Instance.selectedcard = selectCard;
            Debug.Log("Card" + selectCard + "を選んでいるよ");
        }
    }
    void ReDeck(int n)
    {
        Debug.Log(n + "Deck");
        GameManager.Instance.dCard++;
        int deCard = GameManager.Instance.dCard;
        if (deCard == 1)
        {
            GameManager.Instance.t1 = n;
            GameManager.Instance.cardnum.sprite = neight;
        }
        if (deCard == 2)
        {
            GameManager.Instance.t2 = n;
            GameManager.Instance.cardnum.sprite = nseven;
        }
        if (deCard == 3)
        {
            GameManager.Instance.t3 = n;
            GameManager.Instance.cardnum.sprite = nsix;
        }
        if (deCard == 4)
        {
            GameManager.Instance.t4 = n;
            GameManager.Instance.cardnum.sprite = nfive;
        }
        if (deCard == 5)
        {
            GameManager.Instance.t5 = n;
            GameManager.Instance.cardnum.sprite = nfour;
        }
        if (deCard == 6)
        {
            GameManager.Instance.t6 = n;
            GameManager.Instance.cardnum.sprite = nthree;
        }
        if (deCard == 7)
        {
            GameManager.Instance.t7 = n;
            GameManager.Instance.cardnum.sprite = ntwo;
        }
        if (deCard == 8)
        {
            GameManager.Instance.t8 = n;
            GameManager.Instance.cardnum.sprite = one;
        }
        if (deCard == 9)
        {
            GameManager.Instance.t9 = n;
            GameManager.Instance.cardnum.sprite = zero;
        }

    }
    void GMChangeTurn()
    {
        GameManager.Instance.ChangeTurn();
        //Debug.Log("naze");
    }
    
}
