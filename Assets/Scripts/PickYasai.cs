using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kinotake.Player
{
    /// <summary>
    /// ヤサイを回収します
    /// </summary>
    public class PickYasai : MonoBehaviour
    {
        [SerializeField] int playerID;
        [SerializeField] string[] targetObjName; //オブジェクトのタグ名

        string inputText_pick;
        GameObject targetObj; //拾うオブジェクト
        int targetObjID; //拾うオブジェクトの種類
        bool isCanPick; //拾えるか

        void Start()
        {
            inputText_pick = "Pick_" + playerID;
        }

        void Update()
        {
            if (isCanPick && targetObj != null && Input.GetButtonDown(inputText_pick))
            {
                //ヤサイの種類で処理を分ける
                switch (targetObjID)
                {
                    case 0:
                        //ヤサイを増やす
                        Debug.Log("[<color=yellow>PickYasai</color>]処理0");
                        //ヤサイ消滅
                        Destroy(targetObj);
                        break;
                    case 1:
                        //アイテムの効果
                        Debug.Log("[<color=yellow>PickYasai</color>]処理1");
                        //ヤサイ消滅
                        Destroy(targetObj);
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (LayerMask.LayerToName(collision.gameObject.layer) == "Yasai")
            {
                //ヤサイの種類を検出
                for (int i = 0; i <= targetObjName.Length; i++)
                {
                    if (collision.gameObject.tag == targetObjName[i])
                    {
                        targetObjID = i;
                        targetObj = collision.gameObject;
                        break;
                    }
                }
                isCanPick = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            //拾えなくする
            if (LayerMask.LayerToName(collision.gameObject.layer) == "Yasai")
            {
                isCanPick = false;
            }
        }
    }
}