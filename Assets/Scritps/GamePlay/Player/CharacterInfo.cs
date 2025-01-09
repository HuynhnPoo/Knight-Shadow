using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] private  PlayerData player;
   // [SerializeField]private AssetReference asset;
   //bool active=false;

    private void Awake()
    {
        if (player == null)
            /*asset.LoadAssetAsync<PlayerData>().Completed += (AsyncOperationHandle<PlayerData> obj) =>
            {
                player = obj.Result;
                active = true;            
            };*/

            player = Resources.Load<PlayerData>("SO/Player1");
    }

    // Start is called before the first frame update
    void Start()
    {
       
            Debug.Log("hien thi name" + player.name + "  hp:" + player.hp);
        
    }

   
    // Update is called once per frame
    void Update()
    {
       
    }
    public void Moving(float directionX, float directionY)
    {
        Vector3 playerDirection = new Vector3(directionX, directionY);
        transform.parent.parent.Translate(playerDirection * player.speed * Time.deltaTime);
    }


}
