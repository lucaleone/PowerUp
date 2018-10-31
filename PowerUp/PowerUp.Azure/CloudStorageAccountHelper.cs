using Microsoft.WindowsAzure.Storage;
using System;

namespace PowerUp.Web
{
    public static class CloudStorageAccountHelper
    {
        /// <summary>
        ///     Parses redundantly the 2 connection strings and returns a Microsoft.WindowsAzure.Storage.CloudStorageAccount
        ///     created from the connection string.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/blob/master/README.md#azureextensions" />
        /// <param name="connectionString1">CloudStorage main connection string</param>
        /// <param name="connectionString2">CloudStorage secondary connection string</param>
        /// <exception cref="ArgumentNullException">Thrown if connectionString is null or empty.</exception>
        /// <exception cref="FormatException">Thrown if connectionString is not a valid connection string.</exception>
        /// <exception cref="ArgumentException">Thrown if connectionString cannot be parsed.</exception>
        /// <returns>
        ///     A Microsoft.WindowsAzure.Storage.CloudStorageAccount object constructed from the values provided in the
        ///     connection string.
        /// </returns>
        public static CloudStorageAccount RedundantParse(string connectionString1,
                                                         string connectionString2)
        {
            return CloudStorageAccount.TryParse(connectionString1, out var storageAccount)
                ? storageAccount
                : CloudStorageAccount.Parse(connectionString2);
        }
    }
}