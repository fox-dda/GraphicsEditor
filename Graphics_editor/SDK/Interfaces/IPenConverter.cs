using System.Drawing;

namespace SDK.Interfaces
{
    internal interface IPenConverter
    {
        Pen ConvertToPen(IPenSettings settings);
    }
}