using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArena : MonoBehaviour {
    //griffin game object for the enemy object
	public BossEnemy Griffin;
	//boolean for griffin being alive or dead
	public static bool GriffinIsDead = false;

	private void Update()
	{
		//if griffin is destoryed, player automatically goes back to the main level 3 scene at the x, y, z outside the arena, which they can now pass
		if (!Griffin) {
			GriffinIsDead = true;
			SceneManager.LoadScene("Level 3 main scene");
		}
	}
}
