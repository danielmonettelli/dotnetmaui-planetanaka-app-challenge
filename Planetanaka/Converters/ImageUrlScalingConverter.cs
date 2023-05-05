namespace Planetanaka.Converters;

public class ImageUrlScalingConverter : BaseConverter<object, object, object>
{
    public override object DefaultConvertReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override object DefaultConvertBackReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override object ConvertFrom(object value, object parameter, CultureInfo culture)
    {
        // Image scale type in the parameter: 4(200x200approx), 10(500x500approx)
        return "https://raw.githubusercontent.com/danielmonettelli/MyResources/main/Planetakuna_Resources/" + value + "@" + parameter + "x.png";
    }

    public override object ConvertBackTo(object value, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
