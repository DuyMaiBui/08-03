namespace Script
{
    using System;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class FinishTarget : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            SceneManager.LoadScene("SelectLevelScene");
        }
    }
}