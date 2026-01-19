using System.Collections;
using UnityEngine;

namespace Marbles.Code.Infrastructure
{
    public interface  ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator routine);
    }
}