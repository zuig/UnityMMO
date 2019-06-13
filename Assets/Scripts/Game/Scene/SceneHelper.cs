using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace UnityMMO
{
public class SceneHelper
{
    private static EntityManager EntityMgr;
    public static Entity[] UIDTempCacheList = new Entity[10];

    public static void Init(EntityManager entityMgr)
    {
        EntityMgr = entityMgr;
    }

    public static long GetSceneObjectByPos(Vector3 absPos, Dictionary<long, Entity> entityDic)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log("Input.mousePosition : "+Input.mousePosition.x+" "+Input.mousePosition.y+" z:"+Input.mousePosition.z);
        RaycastHit hit=new RaycastHit();
        if(Physics.Raycast(ray,out hit))
        {
            Debug.Log(hit.collider.name);
        }
        return 0;
        // int inAreaNum = 0; 
        // foreach (var item in entityDic)
        // {
        //     var isIn = IsPosInEntityBound(absPos, item.Value);
        //     if (isIn)
        //     {
        //         UIDTempCacheList[inAreaNum] = item.Value;
        //         inAreaNum++;
        //     }
        // }
        // return 0;
    }

    public static bool IsPosInEntityBound(Vector3 absPos, Entity entity)
    {
        var hasMoveQuery = EntityMgr.HasComponent<MoveQuery>(entity);
        if (hasMoveQuery)
        {
            var moveQuery = EntityMgr.GetComponentObject<MoveQuery>(entity);
            var entityPos = moveQuery.transform.position;
            var bottomY = entityPos.y;
            var topY = entityPos.y + moveQuery.height;
            var leftX = entityPos.x - moveQuery.radius;
            var rightX = entityPos.x + moveQuery.radius;
        }
        return false;
    }
}
}