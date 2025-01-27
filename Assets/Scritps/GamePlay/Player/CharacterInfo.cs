using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CharacterInfo : MonoBehaviour, IDameable
{
    [SerializeField] private PlayerData player;

    private int dame;

    public int Dame { get => dame; }
    public float Speed { get => player.speed; }
    public float Mana { get => player.mp; }

    private float currentHp;
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

    // Start is called before the first frame update
    void Start()
    {
        dame = player.dame;
        currentHp = player.hp;
    }


    // Update is called once per frame
    void Update()
    {
    }
   
    public void TakeDame(int dame)
    {
       currentHp -= dame;

       // Debug.Log("hien thi current dame"+ currentHp);
        if (currentHp<=0)
        {
            GameManager.Instance.GameOver();
        }

    }

}
