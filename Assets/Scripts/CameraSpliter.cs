using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kinotake.System
{
    /// <summary>
    /// プレイヤーが離れた際にカメラを分割させます
    /// </summary>
    public class CameraSpliter : MonoBehaviour
    {
        [SerializeField] Transform targetObj_L;
        [SerializeField] Transform targetObj_R;
        [SerializeField] GameObject normalCamera;
        [SerializeField] GameObject splitCamera;
        [SerializeField] float targetDistance;

        // Update is called once per frame
        private void LateUpdate()
        {
            if (Vector3.Distance(targetObj_L.position, targetObj_R.position) >= targetDistance)
            {
                splitCamera.SetActive(true);
                normalCamera.SetActive(false);
            }
            else
            {
                splitCamera.SetActive(false);
                normalCamera.SetActive(true);
            }
        }
    }
}