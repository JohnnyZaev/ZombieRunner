using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 618
namespace UnityStandardAssets.Utility
{
    public class SimpleActivatorMenu : MonoBehaviour
    {
        // An incredibly simple menu which, when given references
        // to game objects in the scene
        public Text camSwitchButton;
        public GameObject[] objects;


        private int _currentActiveObject;


        private void OnEnable()
        {
            // active object starts from first in array
            _currentActiveObject = 0;
            camSwitchButton.text = objects[_currentActiveObject].name;
        }


        public void NextCamera()
        {
            var nextActiveObject = _currentActiveObject + 1 >= objects.Length ? 0 : _currentActiveObject + 1;

            for (var i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(i == nextActiveObject);
            }

            _currentActiveObject = nextActiveObject;
            camSwitchButton.text = objects[_currentActiveObject].name;
        }
    }
}
