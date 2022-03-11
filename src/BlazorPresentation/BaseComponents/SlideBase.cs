using Microsoft.AspNetCore.Components;

namespace BlazorPresentation.BaseComponents;

public class SlideBase : ComponentBase
{
    public override Task SetParametersAsync(ParameterView parameters)
    {
        if (parameters.TryGetValue(nameof(SlideIndex), out int? value))
        {
            if (IsCurrent && value is not null)
            {
                if (value < 0)
                {
                    OnDecrementSlide.InvokeAsync();
                }
                else if (value > SlideIndexMax)
                {
                    OnIncrementSlide.InvokeAsync();
                }
            }
        }

        return base.SetParametersAsync(parameters);
    }

    public virtual int SlideIndexMax { get; set; } = 0;

    [Parameter]
    public bool IsCurrent { get; set; } = false;

    [Parameter]
    public int SlideIndex { get; set; } = 0;

    [Parameter]
    [EditorRequired]
    public EventCallback OnIncrementSlide { get; set; }

    [Parameter]
    [EditorRequired]
    public EventCallback OnDecrementSlide { get; set; }

    protected string ShowSlide(int index)
    {
        if (index <= SlideIndex)
        {
            return "stop-element show";
        }
        return "stop-element hide";
    }
}
