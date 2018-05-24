using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPanel : MonoBehaviour {

    void OnGUI()
    {
        SaveLoad.Load();
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();

      
       if (true)
        {

            GUILayout.Box("Select Save File");
            GUILayout.Space(10);

            foreach (Game g in SaveLoad.savedGames)
            {
                if (GUILayout.Button(g.saveName))
                {
                    Game.current = g;
                    //Game.current.LoadPlayerData();
                    //Move on to game...
                    Time.timeScale = 1;
                    SceneManager.LoadScene(3);
                }

            }

            //GUILayout.Space(10);
            //if (GUILayout.Button("Cancel"))
            //{
            //    currentMenu = Menu.MainMenu;
            //}

        }

        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();

    }
}
