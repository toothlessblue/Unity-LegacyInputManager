using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity_LegacyInputManager
{
    [Serializable]
    public class ControlGroup
    {
        public string groupName;
        public Binding[] bindings;
    }
}