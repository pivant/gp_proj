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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
