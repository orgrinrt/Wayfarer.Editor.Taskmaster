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
    [Get("VBox/Top/Regular")] private Button _regularButton;
    [Get("VBox/Top/Dir")] private Button _dirButton;
    
    public override void _Ready()
    {
        this.SetupWayfarer();

        try
        {
            _regularButton.Connect("button_up", this, nameof(OnRegularButtonPressed));
            _regularButton.Text = "Regular: " + _container.RegularSizeChildren;
        }
        catch (Exception e)
        {
            
        }
        try
        {
            _dirButton.Connect("button_up", this, nameof(OnDirButtonPressed));
            _dirButton.Text = "Dir: " + _container.SortDirection;
        }
        catch (Exception e)
        {
            
        }
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

    private void OnRegularButtonPressed()
    {
        _container.SetRegularSizedChildren(!_container.RegularSizeChildren);

        _regularButton.Text = "Regular: " + _container.RegularSizeChildren;
    }

    private void OnDirButtonPressed()
    {
        _container.SetSortDirection(_container.SortDirection == SortDirection.Right ? SortDirection.Left : SortDirection.Right);

        _dirButton.Text = "Dir: " + _container.SortDirection;
    }
}

#endif