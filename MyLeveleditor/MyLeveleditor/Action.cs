using System;
using System.Collections.Generic;
using System.Text;

namespace MyLeveleditor
{
    /// <summary>
    /// Describes a action that can be saved and restored
    /// </summary>
    abstract class Action
    {
        /// <summary>
        /// Restores the target
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public abstract Action Restore(MapForm target);
    }
}
