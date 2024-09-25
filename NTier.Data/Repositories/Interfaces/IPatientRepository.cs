using NTier.Data.Entities;

namespace NTier.Data.Repositories.Interfaces;

public interface IPatientRepository
{
    Task<Patient> AddAsync(Patient patient);
    Task<List<Patient>> GetAllAsync();
    Task<Patient?> GetByUserPublicIdAsync(Guid userPublicId);

    static string GenerateRandomCode()
    {
        Random random = new Random();
        char[] digits = new char[4];

        for (int i = 0; i < digits.Length; i++)
        {
            digits[i] = (char)(random.Next(0, 10));
        }

        return new string(digits);
    }
}
