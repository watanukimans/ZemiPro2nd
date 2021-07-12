using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceScript : MonoBehaviour
{
    //普通の顔は１０
    int Emotion = 10;
    Image UwamabutaR;
    Image UwamabutaL;
    Image SitamabutaR;
    Image SitamabutaL;
    Image Eyeball;
    Image Namida;
    Image MayuR;
    Image MayuL;
    Image MouthClose;
    Image MouthOpen;
    // Start is called before the first frame update
    void UwamabutaMinus()
    {
        
            //右上瞼
            Transform umrTransform = UwamabutaR.transform;
            //位置
            Vector3 posr = umrTransform.position;
            posr.y += 1f;
            umrTransform.position = posr;
            //しなり
            //角度
            Vector3 localAngleR = umrTransform.localEulerAngles;
            localAngleR.z += 10f;
            umrTransform.localEulerAngles = localAngleR;

            //左上瞼
            Transform umlTransform = UwamabutaL.transform;
            //位置
            Vector3 posl = umlTransform.position;
            posl.y+= 1f;
            umlTransform.position = posl;
            //しなり
            //角度
            Vector3 localAngleL = umlTransform.localEulerAngles;
            localAngleL.z -= 10f;
            umlTransform.localEulerAngles = localAngleL;
            
        

    }
    void UwamabutaPlus()
    {
        
            //右上瞼
            //位置
            Transform umrTransform = UwamabutaR.transform;
            Vector3 posr = umrTransform.position;
            posr.y -= 1f;
            umrTransform.position = posr;
            //しなり
            //角度
            Vector3 localAngleR = umrTransform.localEulerAngles;
            localAngleR.z -= 10f;
            umrTransform.localEulerAngles = localAngleR;
            //左上瞼
            //位置
            Transform umlTransform = UwamabutaL.transform;
            Vector3 posl = umlTransform.position;
            posl.y -= 1f;
            umlTransform.position = posl;
            //しなり
            //角度
            Vector3 localAngleL = umlTransform.localEulerAngles;
            localAngleL.z += 10f;
            umlTransform.localEulerAngles = localAngleL;
        
    }
    void SitamabutaMinus()
    {
        
            //右下瞼
            //位置
            Transform smrTransform = SitamabutaR.transform;
            Vector3 posr = smrTransform.position;
            posr.y += 1f;
            smrTransform.position = posr;
            //しなり
            //角度
            Vector3 localAngleR = smrTransform.localEulerAngles;
            localAngleR.z += 10f;
            smrTransform.localEulerAngles = localAngleR;

            //左下瞼
            //位置
            Transform smlTransform = SitamabutaL.transform;
            Vector3 posl = smlTransform.position;
            posl.y += 1f;
            smlTransform.position = posl;
            //しなり
            //角度
            Vector3 localAngleL = smlTransform.localEulerAngles;
            localAngleL.z -= 10f;
            smlTransform.localEulerAngles = localAngleL;
        
        
    }
    void SitamabutaPlus()
    {
        
            //右下瞼
            //位置
            Transform smrTransform = SitamabutaR.transform;
            Vector3 posr = smrTransform.position;
            posr.y -= 1f;
            smrTransform.position = posr;
            //しなり
            //角度
            Vector3 localAngleR = smrTransform.localEulerAngles;
            localAngleR.z -= 10f;
            smrTransform.localEulerAngles = localAngleR;

            //左下瞼
            //位置
            Transform smlTransform = SitamabutaL.transform;
            Vector3 posl = smlTransform.position;
            posl.y -= 1f;
            smlTransform.position = posl;
            //しなり
            //角度
            Vector3 localAngleL = smlTransform.localEulerAngles;
            localAngleL.z += 10f;
            smlTransform.localEulerAngles = localAngleL;
        
    }
    void EyeBallPlus()
    {
        
            Transform ebTransform = Eyeball.transform;
            //大きさ
            ebTransform.localScale = new Vector3(
                ebTransform.localScale.x * 1.1f,
                ebTransform.localScale.y * 1.1f,
                ebTransform.localScale.z
            );
            //振動
        
    }
    void EyeBallMinus()
    {
        
            Transform ebTransform = Eyeball.transform;
            //大きさ
            ebTransform.localScale = new Vector3(
                ebTransform.localScale.x / 1.1f,
                ebTransform.localScale.y / 1.1f,
                ebTransform.localScale.z
            );
            //振動
        
    }
    void NamidaPlus()
    {
        
            Transform nTransform = Namida.transform;
            //大きさ
            nTransform.localScale = new Vector3(
                nTransform.localScale.x / 1.1f,
                nTransform.localScale.y / 1.1f,
                nTransform.localScale.z
           );
        
    }
    void NamidaMinus()
    {
        
            Transform nTransform = Namida.transform;
            //大きさ
            nTransform.localScale = new Vector3(
                nTransform.localScale.x * 1.1f,
                nTransform.localScale.y * 1.1f,
                nTransform.localScale.z
           );
        
    }
    void MayuPlus()
    {
        //右眉
        Transform mrTransform = MayuR.transform;
        //角度
        Vector3 localAngleR = mrTransform.localEulerAngles;
        localAngleR.z -= 10f;
        mrTransform.localEulerAngles = localAngleR;
        //しなり

        //左眉
        Transform mlTransform = MayuL.transform;
        //角度
        Vector3 localAngleL = mlTransform.localEulerAngles;
        localAngleL.z += 10f;
        mlTransform.localEulerAngles = localAngleL;
        //しなり
    }
    void MayuMinus()
    {
        //右眉
        Transform mrTransform = MayuR.transform;
        //角度
        Vector3 localAngleR = mrTransform.localEulerAngles;
        localAngleR.z += 10f;
        mrTransform.localEulerAngles = localAngleR;
        //しなり

        //左眉
        Transform mlTransform = MayuL.transform;
        //角度
        Vector3 localAngleL = mlTransform.localEulerAngles;
        localAngleL.z -= 10f;
        mlTransform.localEulerAngles = localAngleL;
        //しなり
    }
        void Mouth()
    {
        //しなり
        //開き具合
    }
    void EmotionPlus()
    {
        if (Emotion < 20 && Emotion > 0)
        {
            Emotion++;
            UwamabutaPlus();
            SitamabutaPlus();
            EyeBallPlus();
            NamidaMinus();
        }
        else
        {
            return;
        }
        }
    void EmotionMinus()
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
    /*
    void vibration(float viblv)
    {
        Transform ebTransform = Eyeball.transform;
        Vector3 pos = ebTransform.position;
        pos.x -= viblv;
        ebTransform.position = pos;
    }
    */
}
