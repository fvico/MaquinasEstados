using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;           
using Pada1.BBCore.Tasks;     
using Pada1.BBCore.Framework; 

[Action("MyActions/SetEnemyFollowing")]
//[Help("Indicar que persiga al enemigo")]
public class Bodyguards : BasePrimitiveAction
{
    [InParam("isFollow")]
    public bool isFollow;

    public override TaskStatus OnUpdate()
    {
        IsFollow.isFollowing = isFollow;

        return TaskStatus.COMPLETED;
    }


 }
