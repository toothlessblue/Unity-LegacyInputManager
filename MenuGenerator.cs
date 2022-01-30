using UnityEngine;

namespace Unity_LegacyInputManager
{
    public abstract class MenuGenerator : MonoBehaviour
    {
        protected void generate() {
            ControlGroup[] groups = ControlsManager.getAllGroups();

            foreach (ControlGroup controlGroup in groups) {
                this.addGroup(controlGroup.groupName);

                foreach (Binding binding in controlGroup.bindings) {
                    this.addBinding(controlGroup.groupName, binding);
                }
            }
        }

        protected abstract void addGroup(string controlGroup);

        protected abstract void addBinding(string controlGroup, Binding binding);
    }
}