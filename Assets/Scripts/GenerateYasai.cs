using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kinotake.Stage
{
    /// <summary>
    /// ヤサイを生成します
    /// </summary>
    public class GenerateYasai : MonoBehaviour
    {
        [SerializeField] GameObject targetObj; //生成するオブジェクト
        [SerializeField] string targetTag; //生成するオブジェクトのタグ名

        [SerializeField] int generateSpan; //生成する間隔
        [SerializeField] int maxObjValue; //生成する上限

        float generateSpan_now;

        //生成する位置
        [SerializeField] float startPos;
        [SerializeField] float endPos;
        [SerializeField] float heightPos; //高さ

        void Update()
        {
            generateSpan_now += Time.deltaTime;
            if (generateSpan_now > generateSpan)
            {
                generateSpan_now = 0;
                //上限チェック
                if (GameObject.FindGameObjectsWithTag(targetTag).Length <= maxObjValue)
                {
                    //ヤサイを生成
                    GameObject g = Instantiate(targetObj, new Vector3(Random.Range(startPos, endPos), heightPos, 0), transform.rotation);
                    g.gameObject.tag = targetTag;
                }
            }
        }
    }
}