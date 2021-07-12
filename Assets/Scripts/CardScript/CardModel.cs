using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardModel
{
    public int cardID;
    public Sprite icon,ura;

    public CardModel(int cardID)
    {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card" + cardID);

        cardID = cardEntity.cardID;
        icon = cardEntity.icon;
        ura = cardEntity.ura;
    }
}