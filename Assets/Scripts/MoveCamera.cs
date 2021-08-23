using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kinotake.System
{
    /// <summary>
    /// 特定のオブジェクトにカメラを移動します
    /// </summary>
    public class MoveCamera : MonoBehaviour
    {
        [SerializeField] Transform targetObj;
        [SerializeField] float heightAdjust;

        void LateUpdate()
        {
            gameObject.transform.position = new Vector3(targetObj.position.x, targetObj.position.y + heightAdjust, -10);
        }
    }
}