#if TOOLS

using Godot;
using System;
using Wayfarer.Editor;
using Wayfarer.UI.Controls;
using Wayfarer.Utils.Attributes;
using Wayfarer.Utils.Debug;
using Wayfarer.Utils.Helpers;

[Tool]
public class TaskmasterDock : Control
{
    [Get("Panel/OrganizableContainer")] private OrganizableContainer _container;
    [Get("VBox/Top/IsSortedValue")] private Label _isSortedValue;
    [Get("VBox/Top/HoverIdxValue")] private Label _hoverIdxValue;
    [Get("VBox/Top/RowIdxValue")] private Label _rowIdxValue;
    [Get("VBox/Top/RowCountValue")] private Label _rowCount;
    [Get("VBox/Top/Regular")] private Button _regularButton;
    [Get("VBox/Top/Dir")] private Button _dirButton;
    [Get("VBox/Top/Inspect")] private Button _inspectButton;
    
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
        try
        {
            _inspectButton.Connect("button_up", this, nameof(OnInspectPressed));
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
            int hoverIdx = _container.GetCurrHoveredIndex();
            _hoverIdxValue.Text = hoverIdx.ToString();
            _rowIdxValue.Text = _container.GetRowIdxByItemIdx(hoverIdx).ToString();
            _rowCount.Text = _container.GetRowCount().ToString();
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
        _container.SetSortDirection(_container.SortDirection == SortDirection.Forward ? SortDirection.Backward : SortDirection.Forward);

        _dirButton.Text = "Dir: " + _container.SortDirection;
    }

    private void OnInspectPressed()
    {
        WayfarerEditorPlugin.Instance.EditorInterface.InspectObject(_container);
    }
}

#endif