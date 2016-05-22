using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string name)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(name);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
