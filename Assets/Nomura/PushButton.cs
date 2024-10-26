using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Nomura
{
    public class PushButton : MonoBehaviour
    {
        [SerializeField]
        private Pusher _pusher;


        /// <summary>
        /// �v�b�V���{�^���̎��s
        /// </summary>
		public void Execution()
        {
            _pusher.Push();
        }
    }
}