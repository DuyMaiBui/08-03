namespace Script
{
    using System;
    using UnityEngine;

    public class CharacterController : MonoBehaviour
    {
        private Rigidbody2D rigid;
        private Animator    animator;
        public  GameObject  finishTarget;
        private int         countTrigger = 0;
        public  bool        canMove      = true;
        private void Start()
        {
            this.rigid    = this.GetComponent<Rigidbody2D>();
            this.animator = this.GetComponent<Animator>();
            this.finishTarget.SetActive(false);
        }
        private void Update()
        {
            if(!this.canMove) return;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.gameObject.transform.position += new Vector3(5, 0) * Time.deltaTime;
                this.animator.SetBool("Run",true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.transform.position += new Vector3(-5, 0) * Time.deltaTime;
                this.animator.SetBool("Run",true);
            }
            else
            {
                this.animator.SetBool("Run",false);
            }

            if (this.countTrigger >= 3)
            {
                this.finishTarget.SetActive(true);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            this.countTrigger++;
        }

        public void SetRun(bool canRun)
        {
            this.canMove = canRun;
            if (!canRun)
            {
                this.animator.SetBool("Run",false);
            }
        }
    }
}