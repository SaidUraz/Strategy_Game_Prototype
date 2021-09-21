using System;
using UnityEngine;
using System.Collections;

namespace Framework.Extension
{
    public static class ExtensionMethods
    {
        #region Functions

        public static void StopCoroutines()
		{
            ExtensionHelper.Instance.StopAllCoroutines();
		}

        public static void AddDelay(this Delegate action, float delay, params object[] list)
		{
            ExtensionHelper.Instance.StartCoroutine(DelayedCoroutine(action, delay, null, list));
		}
        
        private static IEnumerator DelayedCoroutine(Delegate action ,float delay, Delegate callBackAction, params object[] list)
		{
            yield return new WaitForSeconds(delay);
            var returnType = action.DynamicInvoke(list);
            callBackAction?.DynamicInvoke(returnType);
        }

        #endregion Functions
    }
}