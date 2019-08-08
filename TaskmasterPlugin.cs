using Godot;
using Wayfarer.ModuleSystem;

#if TOOLS

namespace Wayfarer.Editor.Taskmaster
{
    [Tool]
    public class TaskmasterPlugin : WayfarerModule
    {
        private Control _dock;
        
        public override void _EnterTreeSafe()
        {
            PackedScene dockScene = GD.Load<PackedScene>("res://Addons/Wayfarer.Editor.Taskmaster/Assets/Scenes/TaskmasterDock.tscn");
            _dock = (Control)dockScene.Instance();
            AddControlToBottomPanel(_dock, "Taskmaster");
        }

        public override void _ExitTreeSafe()
        {
            RemoveControlFromBottomPanel(_dock);
        }
    }
}

#endif