using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterInfo : MonoBehaviour, IDameable
{
    [SerializeField] private PlayerData player;
    private int currentDame;
    private static float currentMana, currentSpeed, currentHp;

    public int Dame { get => currentDame; }
    public float Speed { get => currentSpeed; }
    public float Mana { get => currentMana; set => currentMana = value; }
    public float Heath { get => currentHp; set => currentHp = value; }



    private float  manaRate = 5, maxMana, maxHeath;
    private bool isRegenRating = false;

    int index;

    private void Awake()
    {
        index = PlayerPrefs.GetInt(StringSave.selectionCharacter);
        index++;
        string playerStr = "Player" + index;
        if (player == null) player = Resources.Load<PlayerData>("SO/Player/" + playerStr + "");
    }
    private void OnEnable()
    {
        UpdateDataforCharacter();
    }
    void UpdateDataforCharacter()
    {
        currentDame = player.dame;
        currentHp = player.hp;
        currentMana = player.mp;
        currentSpeed = player.speed;


        maxMana = currentMana;
        maxHeath = currentHp;
    }

    public void TakeDame(int dame)
    {
        currentHp -= dame; // trừ máu hiện tại theo dame'
        //
        // Debug.Log("hien thi current dame"+ currentHp);
        if (currentHp <= 0)
        {
            GameManager.Instance.GameOver(); //máu bằng 0 sẽ game over
        }

    }

    public void ReductionMana(int mana)
    {
        if (currentMana >= mana)
        {
            currentMana -= mana;

            if (currentMana <= 0)
            {
                currentMana = 0;
            }
        }
    }

    public void RegenMana()
    {
        isRegenRating = true;

        StartCoroutine(RegenManaCoroutine());

    }

    IEnumerator RegenManaCoroutine()
    {
        // nếu đúng  điều kiện  và isRegenRating bằng true
        while (currentDame < maxMana && isRegenRating)
        {
            yield return new WaitForSeconds(0.5f);
            currentMana += manaRate * Time.deltaTime;

            if (currentMana >= maxMana)
            {
                currentMana = maxMana; // nếu mana bằng hoặc hơn maxMana thì sẽ cho bằng maxMana

                isRegenRating = false;
            }

            Debug.Log(currentMana);

            yield return null;
        }

        isRegenRating = false;
    }

    public void AddHeath(int value)
    {
        currentHp += value;
        if (currentHp >= maxHeath)
            currentHp = maxHeath;
    }
    public void AddMana(int value)
    {
        currentMana += value;
        if(currentMana >= maxMana)
            currentMana = maxMana;
    }
}


