namespace IridiumEditor
{
    public static class Constants
    {
        // Program info
        public static string Name { get; } = "Iridium";
        public static string Author { get; } = "Miguel Guthridge";
        public static string GitHubUrl { get; } = "https://github.com/MiguelGuthridge/Iridium-Editor";
        
        // Version info
        public static int VersionMajor = 0;
        public static int VersionMinor = 0;
        public static int VersionRevision = 1;
        public static string VersionSuffix = "Alpha";
        public static string GetVersion() => $"{VersionMajor}.{VersionMinor}.{VersionRevision} {VersionSuffix}";
        
        // Project defaults
        public static string ProjectDefaultName = "Untitled Project";
    }
}
