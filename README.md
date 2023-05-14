# CodingChallengeAzureFunction

HTTP-triggered Azure function with a single POST endpoint that will accept a JSON payload then later on save the contents of that payload in a table in an SQL server database

## How to use
1. Create a Database in your SQL Server
2. Replace the connection string in the AppDbContext.cs file with your own

 ![image](https://github.com/metall-wave/CodingChallengeAzureFunction/assets/133597414/252c5cb2-ff11-4b78-bb8d-00f496c87e0f)

3. Type "Update-Database" in the Package Manager Console to execute the migration
4. Run the app
5. send a post request to "http://localhost:7245/api/sales-data" using the JSON Format
```json
{
    "BranchId": 1,
    "TransactionId": "TXN-0001-0034895",
    "TransactionDate": "2023-05-09 15:02:34",
    "Amount": 9000.34,
    "LoyaltyCardNumber": null
}
```
