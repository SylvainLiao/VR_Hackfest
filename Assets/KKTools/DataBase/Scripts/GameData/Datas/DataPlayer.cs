using UnityEngine;
using System.Collections;

public class DataPlayer : DataBase
{
    public int PlayerHP;

	#region implemented abstract members of DataBase

	protected override void RefreshData ()
	{
        Init();
    }

	protected override void Init ()
	{
        PlayerHP = 0;
    }

	#endregion



}
