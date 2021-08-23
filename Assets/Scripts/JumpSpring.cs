using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kinotake.Object
{
    /// <summary>
    /// �Ԃ������v���C���[���W�����v�����܂�
    /// </summary>
    public class JumpSpring : MonoBehaviour
    {
        [SerializeField] float jumpPower;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.rigidbody.velocity = Vector2.zero;
                collision.rigidbody.AddForce(Vector2.up * jumpPower);
            }
        }
    }
}