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
        
            if (distance < 121)
            {
                return;
            }
            else if (distance >= 121&&distance <122)
            {
            GameManager.Instance.EmotionMinus();
            GameManager.Instance.QEmotionMinus();
                Debug.Log("1番近いカードです");
            }
            else if (distance >= 243 && distance < 244)
            {
            for(int i=0; i<2; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
                Debug.Log("2番目に近いカードです");
            }
            else if (distance >= 365 && distance < 366)
            {
            for (int i = 0; i < 3; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
            Debug.Log("3番目に近いカードです");
            }
            else if (distance >= 486 && distance < 487)
            {
            for (int i = 0; i < 4; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
            Debug.Log("4番目に近いカードです");
            }
            else if (distance >= 608 && distance < 609)
            {
            for (int i = 0; i < 5; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
            Debug.Log("5番目に近いカードです");
            }
            else if (distance >= 730 && distance < 731)
            {
            for (int i = 0; i < 6; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
            Debug.Log("6番目に近いカードです");
            }
            else if (distance >= 851 && distance < 852)
            {
            for (int i = 0; i < 7; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
            Debug.Log("7番目に近いカードです");
            }
            else if (distance >= 973 && distance < 974)
            {
            for (int i = 0; i < 8; i++)
            {
                GameManager.Instance.EmotionMinus();
                GameManager.Instance.QEmotionMinus();
            }
            Debug.Log("8番目に近いカードです");
            }
            else if (distance >= 1095 && distance < 1096)
            {
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
        if (distance < 121)
        {
            return;
        }
        else if (distance >= 121 && distance < 122)
        {
            GameManager.Instance.EmotionPlus();
            GameManager.Instance.QEmotionPlus();
        }
        else if (distance >= 243 && distance < 244)
        {
            for (int i = 0; i < 2; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 365 && distance < 366)
        {
            for (int i = 0; i < 3; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 486 && distance < 487)
        {
            for (int i = 0; i < 4; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 608 && distance < 609)
        {
            for (int i = 0; i < 5; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 730 && distance < 731)
        {
            for (int i = 0; i < 6; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 851 && distance < 852)
        {
            for (int i = 0; i < 7; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 973 && distance < 974)
        {
            for (int i = 0; i < 8; i++)
            {
                GameManager.Instance.EmotionPlus();
                GameManager.Instance.QEmotionPlus();
            }
        }
        else if (distance >= 1095 && distance < 1096)
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
