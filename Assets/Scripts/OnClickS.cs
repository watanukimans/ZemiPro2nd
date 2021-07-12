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


    public void OnPointerClick(PointerEventData eventData)
    {
        
        //Y座標を移動
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        pos.y -= 100f;
        myTransform.position = pos;
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
            GameManager.Instance.countDown = 5.0f;
            //お試し
            ReDeck(1);
            Debug.Log("1ターン目に消されたのは"+GameManager.Instance.t1);
        }
        if (this.gameObject.CompareTag("Card2"))
        {
            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = two;
            GameObject[] Card2 = GameObject.FindGameObjectsWithTag("Card2");
            foreach (GameObject card2 in Card2)
                GameObject.Destroy(card2, 1.0f);
            GameManager.Instance.countDown = 5.0f;
            ReDeck(2);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
        }
        if (this.gameObject.CompareTag("Card3"))
        {
            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = three;
            GameObject[] Card3 = GameObject.FindGameObjectsWithTag("Card3");
            foreach (GameObject card3 in Card3)
                GameObject.Destroy(card3, 1.0f);
            GameManager.Instance.countDown = 5.0f;
            ReDeck(3);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
        }
        if (this.gameObject.CompareTag("Card4"))
        {
            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = four;
            GameObject[] Card4 = GameObject.FindGameObjectsWithTag("Card4");
            foreach (GameObject card4 in Card4)
                GameObject.Destroy(card4, 1.0f);
            GameManager.Instance.countDown = 5.0f;
            ReDeck(4);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
        }
        if (this.gameObject.CompareTag("Card5"))
        {
            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = five;
            GameObject[] Card5 = GameObject.FindGameObjectsWithTag("Card5");
            foreach (GameObject card5 in Card5)
                GameObject.Destroy(card5, 1.0f);
            GameManager.Instance.countDown = 5.0f;
            ReDeck(5);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
        }
        if (this.gameObject.CompareTag("Card6"))
        {
            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = six;
            GameObject[] Card6 = GameObject.FindGameObjectsWithTag("Card6");
            foreach (GameObject card6 in Card6)
                GameObject.Destroy(card6, 1.0f);
            GameManager.Instance.countDown = 5.0f;
            ReDeck(6);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
        }
        if (this.gameObject.CompareTag("Card7"))
        {
            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = seven;
            GameObject[] Card7 = GameObject.FindGameObjectsWithTag("Card7");
            foreach (GameObject card7 in Card7)
                GameObject.Destroy(card7, 1.0f);
            GameManager.Instance.countDown = 5.0f;
            ReDeck(7);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
        }
        if (this.gameObject.CompareTag("Card8"))
        {
            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = eight;
            GameObject[] Card8 = GameObject.FindGameObjectsWithTag("Card8");
            foreach (GameObject card8 in Card8)
                GameObject.Destroy(card8, 1.0f);
            GameManager.Instance.countDown = 5.0f;
            ReDeck(8);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
        }
        if (this.gameObject.CompareTag("Card9"))
        {
            //ゲージカウントをリセット
            GameManager.Instance.MaxGauge();
            cardImage.sprite = nine;
            GameObject[] Card9 = GameObject.FindGameObjectsWithTag("Card9");
            foreach (GameObject card9 in Card9)
                GameObject.Destroy(card9, 1.0f);
            GameManager.Instance.countDown = 5.0f;
            ReDeck(9);
            Debug.Log("1ターン目に消されたのは" + GameManager.Instance.t1);
        }
        if (this.gameObject.CompareTag("Card10"))
        {
            Invoke("GMChangeTurn", 1);
            cardImage.sprite = joker;
            GameObject[] Card10 = GameObject.FindGameObjectsWithTag("Card10");
            foreach (GameObject card10 in Card10)
                GameObject.Destroy(card10, 1.0f);
            GameManager.Instance.countDown = 5.0f;
            //GameManager.Instance.ChangeTurn();
            //GMChangeTurn();
        }

    }
    void ReDeck(int n)
    {
        GameManager.Instance.dCard++;
        int deCard = GameManager.Instance.dCard;
        if (deCard == 1)
        {
            GameManager.Instance.t1 = n;
        }
        if (deCard == 2)
        {
            GameManager.Instance.t2 = n;
        }
        if (deCard == 3)
        {
            GameManager.Instance.t3 = n;
        }
        if (deCard == 4)
        {
            GameManager.Instance.t4 = n;
        }
        if (deCard == 5)
        {
            GameManager.Instance.t5 = n;
        }
        if (deCard == 6)
        {
            GameManager.Instance.t6 = n;
        }
        if (deCard == 7)
        {
            GameManager.Instance.t7 = n;
        }
        if (deCard == 8)
        {
            GameManager.Instance.t8 = n;
        }
        if (deCard == 9)
        {
            GameManager.Instance.t9 = n;
        }

    }
    void GMChangeTurn()
    {
        GameManager.Instance.ChangeTurn();
        //Debug.Log("naze");
    }
    
}
