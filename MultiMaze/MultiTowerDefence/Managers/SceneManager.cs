
using MazeClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MazeClient
{
    class SceneManager
    {
        public Form GetSceneInstance(Define.GameState gameState)
        {
            Form newScene;
            switch (gameState)
            { 
                case Define.GameState.MainScene:
                    newScene = new MainScene();
                    break;
                case Define.GameState.SettingScene:
                    newScene = new SettingScene();
                    break;
                case Define.GameState.WaitScene:
                    newScene = new WaitScene();
                    break;
                case Define.GameState.InGameScene:
                    newScene = new InGameScene();
                    break;
                case Define.GameState.RoundOverScene:
                    newScene = new RoundOverScene();
                    break;
                case Define.GameState.GameOverScene:
                    newScene = new GameOverScene();
                    break;
                default:
                    newScene = null;
                    break;
            }
            return newScene;
        }
        public void ChangeGameState(Form sender, Define.GameState gameState)
        {
            Form waitScene = GetSceneInstance(gameState);
            sender.Hide();
            waitScene.ShowDialog();
            sender.Close();
        }
    }
}
