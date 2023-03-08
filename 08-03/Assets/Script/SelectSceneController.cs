namespace Script
{
    using System;
    using Cysharp.Threading.Tasks;
    using TMPro;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class SelectSceneController : MonoBehaviour
    {
        public Image          select1;
        public Image          select2;
        public Button         btnSelect1;
        public Button         btnSelect2;
        public Button         btnNext;
        public TMP_InputField inputField;
        public GameObject     popupFail;

        private void Start()
        {
            this.SetDefaultButtonSelect();
            this.btnNext.onClick.AddListener(this.LoadToMainScene);
            this.btnSelect1.onClick.AddListener(this.SelectCharacter_1);
            this.btnSelect2.onClick.AddListener(this.SelectCharacter_2);
        }

        private void SetDefaultButtonSelect()
        {
            this.select1.color = Color.grey;
            PlayerPrefs.SetInt("character", 1);
        }

        private void SelectCharacter_1()
        {
            PlayerPrefs.SetInt("character", 1);
            this.select1.color = Color.grey;
            this.select2.color = Color.white;
        }

        private void SelectCharacter_2()
        {
            PlayerPrefs.SetInt("character", 2);
            this.select2.color = Color.grey;
            this.select1.color = Color.white;
        }

        private async void LoadToMainScene()
        {
            if (this.inputField.text == "")
            {
                this.popupFail.SetActive(true);
                await UniTask.Delay(TimeSpan.FromSeconds(1.5f));
                this.popupFail.SetActive(false);
                return;
            }
            PlayerPrefs.SetString("name",this.inputField.text);
            SceneManager.LoadScene("MainScene");
        }
    }
}