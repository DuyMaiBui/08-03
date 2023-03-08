namespace Script
{
    using System;
    using Cysharp.Threading.Tasks;
    using TMPro;
    using Unity.VisualScripting;
    using UnityEngine;

    public class HeartController : MonoBehaviour
    {
        public GameObject      popupObject;
        public GameObject      playerGameObject;
        public TextMeshProUGUI messageText;
        public int             indexMessage = 0;

        private static string   Message1 = $"Em chúc chị {PlayerPrefs.GetString("name")} có một ngày 8/3 thật tuyệt vời ạ";
        private static string   Message2 = $"Chúc chị {PlayerPrefs.GetString("name")} một ngày 8/3 luôn hạnh phúc nhé";
        private static string   Message3 = $"chúc em {PlayerPrefs.GetString("name")} một ngày 8/3 luôn tươi cười nhé";
        private        string[] Messages = { Message1, Message2, Message3 };

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (this.popupObject != null)
            {
                this.popupObject.SetActive(true);
                this.ShowMessageText();
                this.gameObject.SetActive(false);
            }
        }

        private async void ShowMessageText()
        {
            this.messageText.text                                             = "";
            this.playerGameObject.GetComponent<CharacterController>().SetRun(false);
            var message = this.Messages[this.indexMessage].ToCharArray();
            foreach (var item in message)
            {
                this.messageText.text += item;
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
            }

            await UniTask.Delay(TimeSpan.FromSeconds(2));
            this.popupObject.SetActive(false);
            this.playerGameObject.GetComponent<CharacterController>().SetRun(true);
        }
    }
}