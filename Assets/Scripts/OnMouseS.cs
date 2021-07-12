using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class OnMouseS : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject thisCard;
    
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
        
            if (distance < 33)
            {
                return;
            }
            else if (distance >= 33&&distance <34)
            {
            GameManager.Instance.EmotionMinus();
                Debug.Log("1番近いカードです");
            }
            else if (distance >= 66 && distance < 67)
            {
            for(int i=0; i<2; i++)
            {
                GameManager.Instance.EmotionMinus();
            }
                Debug.Log("2番目に近いカードです");
            }
            else if (distance >= 99 && distance < 100)
            {
            for (int i = 0; i < 3; i++)
            {
                GameManager.Instance.EmotionMinus();
            }
            Debug.Log("3番目に近いカードです");
            }
            else if (distance >= 132 && distance < 133)
            {
            for (int i = 0; i < 4; i++)
            {
                GameManager.Instance.EmotionMinus();
            }
            Debug.Log("4番目に近いカードです");
            }
            else if (distance >= 165 && distance < 166)
            {
            for (int i = 0; i < 5; i++)
            {
                GameManager.Instance.EmotionMinus();
            }
            Debug.Log("5番目に近いカードです");
            }
            else if (distance >= 198 && distance < 199)
            {
            for (int i = 0; i < 6; i++)
            {
                GameManager.Instance.EmotionMinus();
            }
            Debug.Log("6番目に近いカードです");
            }
            else if (distance >= 231 && distance < 232)
            {
            for (int i = 0; i < 7; i++)
            {
                GameManager.Instance.EmotionMinus();
            }
            Debug.Log("7番目に近いカードです");
            }
            else if (distance >= 264 && distance < 265)
            {
            for (int i = 0; i < 8; i++)
            {
                GameManager.Instance.EmotionMinus();
            }
            Debug.Log("8番目に近いカードです");
            }
            else if (distance >= 297 && distance < 298)
            {
            for (int i = 0; i < 9; i++)
            {
                GameManager.Instance.EmotionMinus();
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
        if (distance < 33)
        {
            return;
        }
        else if (distance >= 33 && distance < 34)
        {
            GameManager.Instance.EmotionPlus();
        }
        else if (distance >= 66 && distance < 67)
        {
            for (int i = 0; i < 2; i++)
            {
                GameManager.Instance.EmotionPlus();
            }
        }
        else if (distance >= 99 && distance < 100)
        {
            for (int i = 0; i < 3; i++)
            {
                GameManager.Instance.EmotionPlus();
            }
        }
        else if (distance >= 132 && distance < 133)
        {
            for (int i = 0; i < 4; i++)
            {
                GameManager.Instance.EmotionPlus();
            }
        }
        else if (distance >= 165 && distance < 166)
        {
            for (int i = 0; i < 5; i++)
            {
                GameManager.Instance.EmotionPlus();
            }
        }
        else if (distance >= 198 && distance < 199)
        {
            for (int i = 0; i < 6; i++)
            {
                GameManager.Instance.EmotionPlus();
            }
        }
        else if (distance >= 231 && distance < 232)
        {
            for (int i = 0; i < 7; i++)
            {
                GameManager.Instance.EmotionPlus();
            }
        }
        else if (distance >= 264 && distance < 265)
        {
            for (int i = 0; i < 8; i++)
            {
                GameManager.Instance.EmotionPlus();
            }
        }
        else if (distance >= 297 && distance < 298)
        {
            for (int i = 0; i < 9; i++)
            {
                GameManager.Instance.EmotionPlus();
            }
        }
        
        Debug.Log("出たよ");

    }
    
}
