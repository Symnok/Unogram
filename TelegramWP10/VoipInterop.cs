using libtgvoip;

namespace TelegramWP10
{
    /// <summary>
    /// Thin probe over the libtgvoip WinRT component. Step 1 of adding voice
    /// calls: this exists to prove the winmd binds and that the ARM32
    /// implementation DLL is packaged and survives .NET Native compilation.
    /// Signalling (step 2) and controller wiring (step 3) are not implemented yet.
    ///
    /// Member names are camelCase because they come straight from the C++/CX
    /// component; the WinRT projection does not PascalCase them.
    /// </summary>
    internal static class VoipInterop
    {
        /// <summary>
        /// Touches the libtgvoip types so the reference cannot be silently
        /// dropped by the compiler or trimmed by the .NET Native linker.
        /// </summary>
        internal static string Probe()
        {
            var config = new VoIPConfig
            {
                initTimeout = 30.0,
                recvTimeout = 20.0,
                dataSaving = 0,
                enableAEC = true,
                enableNS = true,
                enableAGC = true,
                enableVolumeControl = true,
            };

            var endpoint = new Endpoint
            {
                id = 0,
                ipv4 = "127.0.0.1",
                port = 0,
            };

            return string.Format(
                "libtgvoip {0}: config(init={1}s recv={2}s aec={3}) endpoint({4}:{5})",
                VoIPControllerWrapper.GetVersion(),
                config.initTimeout,
                config.recvTimeout,
                config.enableAEC,
                endpoint.ipv4,
                endpoint.port);
        }
    }
}
