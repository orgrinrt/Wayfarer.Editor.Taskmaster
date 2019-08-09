#if TOOLS

using Godot;
using System;
using Wayfarer.UI.Controls;
using Wayfarer.Utils.Attributes;
using Wayfarer.Utils.Debug;
using Wayfarer.Utils.Helpers;

[Tool]
public class TaskmasterDock : Control
{
    [Get("VBox/OrganizableContainer")] private OrganizableContainer _container;
    [Get("VBox/Top/IsSortedValue")] private Label _isSortedValue;
    [Get("VBox/Top/HoverIdxValue")] private Label _hoverIdxValue;
    
    public override void _Ready()
    {
        this.SetupWayfarer();
        
        
    }

    public override void _Process(float delta)
    {
        try
        {
            _isSortedValue.Text = _container.IsSortDone().ToString();
            _hoverIdxValue.Text = _container.GetCurrHoveredIndex().ToString();
        }
        catch (Exception e)
        {
            //Log.Wf.Editor("Couldn't update Taskmaster's debug labels", e, true);
        }
        
    }
}

#endif