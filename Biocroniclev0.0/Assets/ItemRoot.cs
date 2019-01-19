using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
{
    public enum TYPE // 아이템종류
    {
        NONE = -1, //없음
        IRON = 0,  // 철광석
        APPLE,     // 사과
        PLANT,      // 식물
        NUM,        // 아이템이 몇종류인지 나타낸다
    };
};

public class ItemRoot : MonoBehaviour
{

    public GameObject ironPrefab = null;    //프리팹 iron
    public GameObject plantPrefab = null;   //프리팹 plant
    public GameObject applePrefab = null;   //프리팹 apple

    protected List<Vector3> respawn_points; //출현지점 list

    public float step_timer = 0.0f;         //
    public static float RESPAWN_TIME_APPLE = 20.0f;     //사과 출현 시간 상수
    public static float RESPAWN_TIME_IRON = 12.0f;     //철광석 출현 시간 상수
    public static float RESPAWN_TIME_PLANT = 6.0f;     //식물 출현 시간 상수
    public static float respawn_timer_apple = 0.0f;     //사과 출현 시간 
    public static float respawn_timer_iron = 0.0f;     //철광석 출현 시간 
    public static float respawn_timer_plant = 0.0f;     //식물 출현 시간 


    //아이템 종류를 item.TYPE로 반환하는 메서드.
    public Item.TYPE getItemType(GameObject item_go)
    {
        Item.TYPE type = Item.TYPE.NONE;
        if(item_go != null) // 인수로 받은 게임 오브젝트가 비어있지 않으면
        {
            switch(item_go.tag)//태그로 분기
            {
                case "Iron": type = Item.TYPE.IRON; break;
                case "Apple": type = Item.TYPE.APPLE; break;
                case "Plant": type = Item.TYPE.PLANT; break;
            }
        }

        return (type);
    }

    public void respawnIron()
    {
        //철광석 프리팹을 인스턴스화
        GameObject go =
            GameObject.Instantiate(this.ironPrefab) as GameObject;

        //철광석의 출현 지점을 취득.
        Vector3 pos = GameObject.Find("IronRespawn").transform.position;

        //출현 위치를 조정.
        pos.y = 1.0f;
        pos.x += Random.Range(-1.0f, -1.0f);
        pos.z += Random.Range(-1.0f, -1.0f);

        //철광석의 위치를 이동
        go.transform.position = pos;
    }

    public void respawnApple()
    {
        //사과 프리팹을 인스턴스화
        GameObject go =
            GameObject.Instantiate(this.applePrefab) as GameObject;

        //철광석의 출현 지점을 취득.
        Vector3 pos = GameObject.Find("AppleRespawn").transform.position;

        //출현 위치를 조정.
        pos.y = 1.0f;
        pos.x += Random.Range(-1.0f, -1.0f);
        pos.z += Random.Range(-1.0f, -1.0f);

        //철광석의 위치를 이동
        go.transform.position = pos;
    }

    public void respawnPlant()
    {
        if(this.respawn_points.Count>0)
        {
            //식물 프리팹을 인스턴스화
            GameObject go =
                GameObject.Instantiate(this.plantPrefab) as GameObject;

            //식물의 출현 지점을 랜덤하게 취득.
            int n = Random.Range(0, this.respawn_points.Count);

            Vector3 pos = this.respawn_points[n];

            //출현 위치를 조정.
            pos.y = 1.0f;
            pos.x += Random.Range(-1.0f, -1.0f);
            pos.z += Random.Range(-1.0f, -1.0f);

            //철광석의 위치를 이동
            go.transform.position = pos;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
