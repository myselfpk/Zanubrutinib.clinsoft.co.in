# Zanubrutinib ClinSoft

Legacy ASP.NET Web Forms clinical-study application targeting .NET Framework 4.8.

## Local setup

1. Copy `web.config.example` to `web.config`.
2. Set the SQL Server connection string named `constr`.
3. Set `LegacyPasswordEncryptionKey` to the deployment's existing key. Changing it without a data migration prevents existing encrypted values from being read.
4. Configure the SMTP sender and credentials under `system.net/mailSettings`.
5. Host the repository root as an ASP.NET 4.8 application in IIS or IIS Express.

`web.config`, uploaded files under `Files/`, publish profiles, debug symbols, and local secrets are intentionally excluded from source control.
