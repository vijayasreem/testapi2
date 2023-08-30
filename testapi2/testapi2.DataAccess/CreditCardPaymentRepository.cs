using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using testapi2.DTO;

namespace testapi2
{
    public class CreditCardPaymentRepository : ICreditCardPaymentService
    {
        private readonly string connectionString;

        public CreditCardPaymentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> CreateAsync(CreditCardPaymentModel payment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO CreditCardPayment (CreditCardNumber, ExpiryDate, Cvv, Amount, PurchaseNotification) " +
                               "VALUES (@CreditCardNumber, @ExpiryDate, @Cvv, @Amount, @PurchaseNotification); " +
                               "SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CreditCardNumber", payment.CreditCardNumber);
                command.Parameters.AddWithValue("@ExpiryDate", payment.ExpiryDate);
                command.Parameters.AddWithValue("@Cvv", payment.Cvv);
                command.Parameters.AddWithValue("@Amount", payment.Amount);
                command.Parameters.AddWithValue("@PurchaseNotification", payment.PurchaseNotification);

                await connection.OpenAsync();
                return Convert.ToInt32(await command.ExecuteScalarAsync());
            }
        }

        public async Task<CreditCardPaymentModel> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM CreditCardPayment WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return new CreditCardPaymentModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CreditCardNumber = reader["CreditCardNumber"].ToString(),
                        ExpiryDate = reader["ExpiryDate"].ToString(),
                        Cvv = reader["Cvv"].ToString(),
                        Amount = Convert.ToDecimal(reader["Amount"]),
                        PurchaseNotification = reader["PurchaseNotification"].ToString()
                    };
                }
                return null;
            }
        }

        public async Task<List<CreditCardPaymentModel>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM CreditCardPayment";
                SqlCommand command = new SqlCommand(query, connection);

                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                List<CreditCardPaymentModel> payments = new List<CreditCardPaymentModel>();
                while (await reader.ReadAsync())
                {
                    payments.Add(new CreditCardPaymentModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CreditCardNumber = reader["CreditCardNumber"].ToString(),
                        ExpiryDate = reader["ExpiryDate"].ToString(),
                        Cvv = reader["Cvv"].ToString(),
                        Amount = Convert.ToDecimal(reader["Amount"]),
                        PurchaseNotification = reader["PurchaseNotification"].ToString()
                    });
                }
                return payments;
            }
        }

        public async Task<int> UpdateAsync(CreditCardPaymentModel payment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE CreditCardPayment SET CreditCardNumber = @CreditCardNumber, ExpiryDate = @ExpiryDate, " +
                               "Cvv = @Cvv, Amount = @Amount, PurchaseNotification = @PurchaseNotification WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", payment.Id);
                command.Parameters.AddWithValue("@CreditCardNumber", payment.CreditCardNumber);
                command.Parameters.AddWithValue("@ExpiryDate", payment.ExpiryDate);
                command.Parameters.AddWithValue("@Cvv", payment.Cvv);
                command.Parameters.AddWithValue("@Amount", payment.Amount);
                command.Parameters.AddWithValue("@PurchaseNotification", payment.PurchaseNotification);

                await connection.OpenAsync();
                return await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM CreditCardPayment WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
                return await command.ExecuteNonQueryAsync();
            }
        }
    }
}