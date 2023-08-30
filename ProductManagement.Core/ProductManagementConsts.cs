using ProductManagement.Debugging;

namespace ProductManagement
{
    public class ProductManagementConsts
    {
        public const string LocalizationSourceName = "ProductManagement";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "24e682d3b00e41bfa1f26c0e9cbe8da4";
    }
}
