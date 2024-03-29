using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kinotake.Player
{
    /// <summary>
    /// プレイヤーを移動,ジャンプさせます
    /// </summary>
    public class MovePlayer : MonoBehaviour
    {
        Rigidbody2D rigidbody;

        [SerializeField] int playerID; //プレイヤー番号
        [SerializeField] float moveSpeed; //移動速度
        [SerializeField] int jumpPower; //ジャンプ力
        [SerializeField] bool isGround; //着地フラグ

        [SerializeField] Vector2 debug_groundCol;
        float moveValue; //移動方向
        string inputText_move;
        string inputText_jump;

        void Start()
        {
            //初期値設定
            rigidbody = GetComponent<Rigidbody2D>();
            if (moveSpeed <= 0f) { moveSpeed = 0.5f; }
            if (jumpPower <= 0) { jumpPower = 500; }
            inputText_move = "Horizontal_" + playerID;
            inputText_jump = "Jump_" + playerID;
        }

        void FixedUpdate()
        {
            //移動
            if (Input.GetAxis(inputText_move) != 0)
            {
                moveValue = Input.GetAxis(inputText_move);
                transform.position += new Vector3(moveSpeed * moveValue, 0, 0);

                //向きを変える
                if (moveValue > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 1, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, -180, 0);
                }
            }
            //ジャンプ
            if (isGround && Input.GetButton(inputText_jump))
            {
                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(Vector2.up * jumpPower);
            }
            //ジャンプ重力補正
            //if (rigidbody.velocity.y > 25)
            //{
            //    rigidbody.velocity = new Vector2(0, 25);
            //}
        }

        //着地判定
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground") { isGround = true; }
            debug_groundCol = collision.relativeVelocity;
        }

        //着地判定
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground") { isGround = false; }
        }
    }
}