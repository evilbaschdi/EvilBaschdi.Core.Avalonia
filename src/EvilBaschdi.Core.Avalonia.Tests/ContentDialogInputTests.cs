using Avalonia;
using Avalonia.Controls;
using EvilBaschdi.Core.Avalonia.Controls;
using EvilBaschdi.Testing.Avalonia;
using FluentAssertions;

namespace EvilBaschdi.Core.Avalonia.Tests;

public class ContentDialogInputTests : AvaloniaTestBase<TestApp>
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_WithCaptionText_InitializesCaptionProperty(string captionText)
    {
        var sut = new ContentDialogInput { CaptionText = captionText };

        sut.CaptionText.Should().Be(captionText);
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void ResultText_PropertyCanBeAccessed(string captionText)
    {
        var sut = new ContentDialogInput { CaptionText = captionText };

        var resultText = sut.ResultText;
        resultText.Should().BeNull();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void CaptionText_Property_IsInit(string captionText)
    {
        var sut = new ContentDialogInput { CaptionText = captionText };

        sut.CaptionText.Should().Be(captionText);
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_CreatesValidUserControl(string captionText)
    {
        var sut = new ContentDialogInput { CaptionText = captionText };

        sut.Should().BeAssignableTo<UserControl>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_WithCaptionText_DoesNotThrow(string captionText)
    {
        var act = () => new ContentDialogInput { CaptionText = captionText };

        act.Should().NotThrow();
    }
}
