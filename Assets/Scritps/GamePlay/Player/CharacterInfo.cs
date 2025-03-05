using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterInfo : MonoBehaviour, IDameable
{
    [SerializeField] private PlayerData player;


    public int Dame { get => currentDame; }
    public float Speed { get => currentSpeed; }
    public float Mana { get => currentMana; set => currentMana = value; }

    private int currentDame;
    private float currentMana, currentSpeed, currentHp;
    // public float CurrentHP { get => currentHp; set => currentHp = value; }

    int index;
    // [SerializeField]private AssetReference asset;
    //bool active=false;

    private void Awake()
    {
        index = PlayerPrefs.GetInt(StringSave.selectionCharacter);
        index++;
        string playerStr = "Player" + index;
        if (player == null)
            /*asset.LoadAssetAsync<PlayerData>().Completed += (AsyncOperationHandle<PlayerData> obj) =>
            {
                player = obj.Result;
                active = true;            
            };*/
            //Debug.Log("hien thi game object"+);
            player = Resources.Load<PlayerData>("SO/Player/" + playerStr + "");
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
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDame(int dame)
    {
        currentHp -= dame;

        // Debug.Log("hien thi current dame"+ currentHp);
        if (currentHp <= 0)
        {
            GameManager.Instance.GameOver();
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
        Debug.Log(currentMana);

    }
}
