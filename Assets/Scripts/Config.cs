using UnityEngine;
using System.Collections;

public class Config
{
	public struct Enemy
	{
		public static string[] m_Index {
			get {
				return new string[] { 
					"Idle",
					"Block",
					"Damage",
					"Dash",
					"Jump",
					"ATK1",
					"ATK2",
					"ATK3"
				};
			}
		}

			
		public static string[] m_IndexArrival {
			get { 
				return new string[] {
					"ATK1",
					"ATK2",
					"ATK3",
					"Move_L",
					"Move_R",
					"Block"
				};
			}	
		}
	}
}