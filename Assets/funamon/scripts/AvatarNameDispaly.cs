using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class AvatarNameDispaly : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        var nameLabel = GetComponent<TextMeshPro>();
        //プレイやー名とプレイやーIDを表示する
        nameLabel.text = $"{photonView.Owner.NickName}({photonView.OwnerActorNr})";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
