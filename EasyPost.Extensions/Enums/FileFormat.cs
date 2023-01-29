namespace EasyPost.Extensions.Enums;

/// <summary>
///     An enum that represents the different file formats available for EasyPost.
/// </summary>
public class FileFormat : NetTools.Common.ValueEnum
{
    /// <summary>
    ///     PDF file format
    /// </summary>
    public static readonly FileFormat Pdf = new(0, "pdf");

    /// <summary>
    ///     ZPL file format
    /// </summary>
    public static readonly FileFormat Zpl = new(1, "zpl");

    /// <summary>
    ///     EPL2 file format
    /// </summary>
    public static readonly FileFormat Epl2 = new(2, "epl2");

    private FileFormat(int id, string name) : base(id, name)
    {
    }
}
