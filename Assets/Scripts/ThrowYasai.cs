using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kinotake.Player
{
    /// <summary>
    /// ヤサイを投げます
    /// </summary>
    public class ThrowYasai : MonoBehaviour
    {
        [SerializeField] int playerID; //プレイヤー番号
        [SerializeField] GameObject throwObject; //投げるオブジェクト
        [SerializeField] int throwPower; //投げるパワー

        string inputText_throw;
        string inputText_throwObj;

        // Start is called before the first frame update
        void Start()
        {
            //初期値設定
            if (throwPower <= 0) { throwPower = 500; }
            inputText_throw = "Throw_" + playerID;
            inputText_throwObj = "ThrowObj_" + playerID;
        }

        void Update()
        {
            //投げる
            if (Input.GetButtonDown(inputText_throw))
            {
                //オブジェクト生成
                GameObject g = Instantiate(throwObject, transform.position, transform.rotation);
                g.tag = inputText_throwObj;

                //投げる
                Vector2 vec = new Vector2(transform.forward.z, 1);
                g.GetComponent<Rigidbody2D>().AddForce(vec * throwPower);
            }
        }
    }
}