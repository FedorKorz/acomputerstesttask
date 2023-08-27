using UserInterfaceVisual.Utils;

namespace UserInterfaceVisual.Resources;

public static class ExternalVarsStorage
{
    public static readonly string Url = UtilsJson.ReadJsonFile("url");
    public static readonly string ParentId = UtilsJson.ReadJsonFile("parent_id");
    public static readonly string Passwrod = "dt%ga8`g&?MU53qW";

    public static readonly string RequestBody = @"
                {
                    ""parent_id"": ""8e1daa5e-d974-40c0-926b-8bda8770624c"",
                    ""type"": ""organization"",
                    ""name"": ""фывфывфыв""
                }";
}