using System.Collections.Generic;
using UnityEngine;
using Actions;

public class Player : Character
{
    [SerializeField] private Animator animator;
    //private Inventory inventory;
    private Action firstAction;
    private Action secondAction;
    void Start()
    {
       // if (inventory.activeWeapon == null)
       //     inventory.activeWeapon = new Hands();

        //firstAction = new StandartHit(inventory.activeWeapon.minDamage, 
        //                              inventory.activeWeapon.maxDamage,
        //                              inventory.activeWeapon.anim, gameObject);
    }
    void Update()
    {
        //Передвижение
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        transform.Translate(xInput * speed * Time.deltaTime, yInput * speed * Time.deltaTime, 0f);

        //Обработка первого действия
        float a1Input = Input.GetAxis("Action1");
        //firstAction.Start();



        //Обработка второго действия
        float a2Input = Input.GetAxis("Action2");
        //secondAction.Start();
    }

    //void setHandsWeapon
}