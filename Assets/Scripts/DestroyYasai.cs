using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kinotake.Object
{
    /// <summary>
    /// 一定時間後にヤサイを消滅させます
    /// </summary>
    public class DestroyYasai : MonoBehaviour
    {
        [SerializeField] int lifeTime; //生存時間

        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, lifeTime);
        }
    }
}