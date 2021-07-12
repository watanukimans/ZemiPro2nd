using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] Image iconImage;

    public void Show(CardModel cardModel) // cardModelのデータ取得と反映
    {
        iconImage.sprite = cardModel.icon;
    }
    //お試し裏面
    public void Showura(CardModel cardModel)
    {
        iconImage.sprite = cardModel.ura;
    }
}

