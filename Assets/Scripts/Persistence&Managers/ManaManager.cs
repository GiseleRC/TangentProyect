using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManaManager : Singleton<ManaManager>
{
    [SerializeField] string _titleNotif = "Full Stamina";
    [SerializeField] string _textNotif = "Tenes la stamina full, volve a jugar conmigo";

    private bool _rechargingMana;
    private TimeSpan timer;
    private int id;

    private void Start()
    {
        GameManager.Instance.LoadPersistentData();
        StartCoroutine(RechargeManaCourutine());

        if (GameManager.Instance.PersistentData.Mana < GameManager.Instance.ConstantsDataStats.MaxManaCapacity)
        {
            timer = GameManager.Instance.PersistentData.NextManaTime - DateTime.Now;
            id = NotificationManager.Instance.DisplayNotification(_titleNotif, _textNotif, AddTime(DateTime.Now, ((GameManager.Instance.ConstantsDataStats.MaxManaCapacity - GameManager.Instance.PersistentData.Mana + 1) * GameManager.Instance.ConstantsDataStats.RechargeTime) + 1 + (float)timer.TotalSeconds));
        }
    }

    public bool HasEnoughMana(int mana) => GameManager.Instance.PersistentData.Mana >= mana;

    public void UseMana(int mana)
    {
        if (GameManager.Instance.PersistentData.Mana >= mana)
        {
            GameManager.Instance.PersistentData.Mana -= mana;

            NotificationManager.Instance.CancelNotification(id);
            id = NotificationManager.Instance.DisplayNotification(_titleNotif, _textNotif, AddTime(DateTime.Now, ((GameManager.Instance.ConstantsDataStats.MaxManaCapacity - GameManager.Instance.PersistentData.Mana + 1) * GameManager.Instance.ConstantsDataStats.RechargeTime) + 1 + (float)timer.TotalSeconds));

            if (!_rechargingMana)
            {
                GameManager.Instance.PersistentData.NextManaTime = AddTime(DateTime.Now, GameManager.Instance.ConstantsDataStats.RechargeTime);
                StartCoroutine(RechargeManaCourutine());
            }
        }
        else
        {
            Debug.Log("Feedback no tenes stamina suficiente");
        }
    }

    private IEnumerator RechargeManaCourutine()
    {
        _rechargingMana = true;

        while (GameManager.Instance.PersistentData.Mana < GameManager.Instance.ConstantsDataStats.MaxManaCapacity)
        {
            DateTime currentT = DateTime.Now;
            DateTime nextT = GameManager.Instance.PersistentData.NextManaTime;

            bool _addingStamina = false;

            while (currentT > nextT)
            {
                if (GameManager.Instance.PersistentData.Mana >= GameManager.Instance.ConstantsDataStats.MaxManaCapacity) break;

                GameManager.Instance.PersistentData.Mana += 1;//en el video dice que se suma un valor?
                _addingStamina = true;

                DateTime timeToAdd = nextT;
                if (GameManager.Instance.PersistentData.LastManaTime > nextT) timeToAdd = GameManager.Instance.PersistentData.LastManaTime;//Checkear si el usuario cerro la app

                nextT = AddTime(timeToAdd, GameManager.Instance.ConstantsDataStats.RechargeTime);
            }

            if (_addingStamina)
            {
                GameManager.Instance.PersistentData.NextManaTime = nextT;
                GameManager.Instance.PersistentData.LastManaTime = DateTime.Now;
            }

            GameManager.Instance.SavePersistentData();

            yield return new WaitForEndOfFrame();
        }
        _rechargingMana = false;
    }

    private DateTime AddTime(DateTime timeToAdd, float timerToRechargeMana)
    {
        return timeToAdd.AddSeconds(timerToRechargeMana);
    }
}
