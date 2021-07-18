using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class OnMouseS : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject thisCard;

    public void SendEmotion()
    {
        if(GameManager.Instance.MyNumber == 1) //自身がプレイヤー１モナリザ、敵がプレイヤー２ムンク
        {

        }
    }
    
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 Apos = thisCard.transform.position;
        Vector3 Jpos = GameObject.FindGameObjectWithTag("Card10").transform.position;
        Vector3 Ypos = GameManager.Instance.Yajirusi.transform.position;
        //Vector3 Bpos = thisCard.transform.localPosition;
        Ypos.x = Apos.x;
        GameManager.Instance.Yajirusi.transform.position = Ypos;
        float distance = (Apos - Jpos).magnitude;
        Debug.Log(distance);
        //Y座標が100以下の時実行
        //if (Apos.y<100)
        //{
            Debug.Log("入ったよ");
        
            if (distance < 1)
            {
            GameManager.Instance.j = 1;
            return;
            }
            else if (distance >= 1&&distance <2)
            {
            GameManager.Instance.j = 0;
            GameManager.Instance.EmotionMinus();
            GameManager.Instance.QEmotionMinus();
                Debug.Log("1番近いカードです");
            }
            else if (distance >= 2 && distance < 3)
            {
            GameManager.Instance.j = 0;
            for (int i=0; i<2; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
                Debug.Log("2番目に近いカードです");
            }
            else if (distance >= 3 && distance < 4)
            {
            GameManager.Instance.j = 0;
            for (int i = 0; i < 3; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
            Debug.Log("3番目に近いカードです");
            }
            else if (distance >= 4 && distance < 5)
            {
            GameManager.Instance.j = 0;
            for (int i = 0; i < 4; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
            Debug.Log("4番目に近いカードです");
            }
            else if (distance >= 5 && distance < 6)
            {
            GameManager.Instance.j = 0;
            for (int i = 0; i < 5; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
            Debug.Log("5番目に近いカードです");
            }
            else if (distance >= 6 && distance < 7)
            {
            GameManager.Instance.j = 0;
            for (int i = 0; i < 6; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
            Debug.Log("6番目に近いカードです");
            }
            else if (distance >= 7 && distance < 8)
            {
            GameManager.Instance.j = 0;
            for (int i = 0; i < 7; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
            Debug.Log("7番目に近いカードです");
            }
            else if (distance >= 9 && distance < 10)
            {
            GameManager.Instance.j = 0;
            for (int i = 0; i < 8; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
            Debug.Log("8番目に近いカードです");
            }
            else if (distance >= 10 && distance < 11)
            {
            GameManager.Instance.j = 0;
            for (int i = 0; i < 9; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
            Debug.Log("9番目に近いカードです");
            }
            
        //}
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        
        Vector3 Apos = thisCard.transform.position;
        Vector3 Jpos = GameObject.FindGameObjectWithTag("Card10").transform.position;
        float distance = (Apos - Jpos).magnitude;
        if (distance < 1)
        {
            return;
        }
        else if (distance >= 1 && distance < 2)
        {
            GameManager.Instance.EmotionPlus();
            GameManager.Instance.QEmotionPlus();
        }
        else if (distance >= 2 && distance < 3)
        {
            for (int i = 0; i < 2; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 3 && distance < 4)
        {
            for (int i = 0; i < 3; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 4 && distance < 5)
        {
            for (int i = 0; i < 4; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 5 && distance < 6)
        {
            for (int i = 0; i < 5; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 6 && distance < 7)
        {
            for (int i = 0; i < 6; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 7 && distance < 8)
        {
            for (int i = 0; i < 7; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 9 && distance < 10)
        {
            for (int i = 0; i < 8; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 10 && distance < 11)
        {
            for (int i = 0; i < 9; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        
        Debug.Log("出たよ");

    }
    
}
