using Microsoft.Data.SqlClient;
using PrescritponsApp.Models;

namespace PrescritponsApp.Repositories;

public class PrescriptionRepository(IConfiguration configuration) : IPrescriptionRepository
{
    public async Task<IEnumerable<PrescriptionPatientDoctorNames>> GetPrescriptions()
    {
        await using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        await using var command = connection.CreateCommand();

        command.CommandText =
            "SELECT IdPrescription, Date, DueDate, Patient.LastName AS PatientLastName, Doctor.LastName AS DoctorLastName FROM Prescription " +
            "INNER JOIN Patient ON Prescription.IdPatient = Patient.IdPatient " +
            "INNER JOIN Doctor ON Doctor.IdDoctor = Prescription.IdDoctor";

        await connection.OpenAsync();
        await using var reader = await command.ExecuteReaderAsync();
        var prescriptions = new List<PrescriptionPatientDoctorNames>();

        while (await reader.ReadAsync())
            prescriptions.Add(new PrescriptionPatientDoctorNames
            {
                IdPrescription = (int)reader["IdPrescription"],
                Date = (DateTime)reader["Date"],
                DueDate = (DateTime)reader["DueDate"],
                PatientLastName = (string)reader["PatientLastName"],
                DoctorLastName = (string)reader["DoctorLastName"]
            });

        return prescriptions;
    }

    public async Task<IEnumerable<PrescriptionPatientDoctorNames>> GetPrescriptions(string doctorLastName)
    {
        await using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        await using var command = connection.CreateCommand();

        command.CommandText =
            "SELECT IdPrescription, Date, DueDate, Patient.LastName AS PatientLastName, Doctor.LastName AS DoctorLastName FROM Prescription " +
            "INNER JOIN Patient ON Prescription.IdPatient = Patient.IdPatient " +
            "INNER JOIN Doctor ON Doctor.IdDoctor = Prescription.IdDoctor " +
            "WHERE Doctor.LastName = @DoctorLastName";

        command.Parameters.AddWithValue("@DoctorLastName", doctorLastName);

        await connection.OpenAsync();
        await using var reader = await command.ExecuteReaderAsync();
        var prescriptions = new List<PrescriptionPatientDoctorNames>();

        while (await reader.ReadAsync())
            prescriptions.Add(new PrescriptionPatientDoctorNames
            {
                IdPrescription = (int)reader["IdPrescription"],
                Date = (DateTime)reader["Date"],
                DueDate = (DateTime)reader["DueDate"],
                PatientLastName = (string)reader["PatientLastName"],
                DoctorLastName = (string)reader["DoctorLastName"]
            });

        return prescriptions;
    }

    public async Task<Prescription> CreatePrescription(Prescription prescription)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        await using var connection = new SqlConnection(connectionString);
        await using var command = new SqlCommand();

        command.Connection = connection;

        await connection.OpenAsync();
        var transaction = (SqlTransaction)await connection.BeginTransactionAsync();
        command.Transaction = transaction;

        try
        {
            command.CommandText =
                "INSERT INTO Prescription (Date, DueDate, IdPatient, IdDoctor) VALUES (@Date, @DueDate, @IdPatient, @IdDoctor);";
            command.Parameters.AddWithValue("@Date", prescription.Date);
            command.Parameters.AddWithValue("@DueDate", prescription.DueDate);
            command.Parameters.AddWithValue("@IdPatient", prescription.IdPatient);
            command.Parameters.AddWithValue("@IdDoctor", prescription.IdDoctor);

            var rowsInserted = await command.ExecuteNonQueryAsync();

            if (rowsInserted < 1) throw new Exception("Error while adding new prescription");

            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            await connection.CloseAsync();
            throw new Exception("Error while adding new prescription", e);
        }

        command.Parameters.Clear();
        command.CommandText = "SELECT TOP 1 * FROM Prescription ORDER BY IdPrescription DESC";

        var reader = await command.ExecuteReaderAsync();

        if (!reader.HasRows) throw new Exception("Error while adding new prescription");

        await reader.ReadAsync();

        prescription = new Prescription
        {
            IdPrescription = (int)reader["IdPrescription"],
            Date = (DateTime)reader["Date"],
            DueDate = (DateTime)reader["DueDate"],
            IdPatient = (int)reader["IdPatient"],
            IdDoctor = (int)reader["IdDoctor"]
        };


        await reader.CloseAsync();
        await connection.CloseAsync();

        return prescription;
    }
}