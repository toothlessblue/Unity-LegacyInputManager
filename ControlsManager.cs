using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity_LegacyInputManager
{
    public class ControlsManager : MonoBehaviour
    {
        private static ControlsManager instance;
        
        public ControlGroup[] groups;

        private Dictionary<string, KeyCode> controls;

        private void Start() {
            if (ControlsManager.instance != null) {
                Debug.LogError("More than one instance of ControlsManager exists, remove all but one. The spares are unused");
                return;
            }
            
            ControlsManager.instance = this;
            
            this.controls = new Dictionary<string, KeyCode>();

            foreach (ControlGroup controlGroup in this.groups) {
                foreach (Binding binding in controlGroup.bindings) {
                    this.controls.Add($"{controlGroup.groupName}/{binding.name}", binding.keyCode);
                }
            }
        }

        public static void registerControl(string controlName, KeyCode keyCode) {
            ControlsManager.instance.controls.Add(controlName, keyCode);
        }
        
        public static void setKeyCode(string controlName, KeyCode keyCode) {
            throw new NotImplementedException();
        }
        
        public static KeyCode getKeyCode(string controlName) {
            return ControlsManager.instance.controls[controlName];
        }
        
        public static bool getKey(string controlName) {
            return Input.GetKey(ControlsManager.instance.controls[controlName]);
        }

        public static ControlGroup[] getAllGroups() {
            return ControlsManager.instance.groups;
        }
    }
}