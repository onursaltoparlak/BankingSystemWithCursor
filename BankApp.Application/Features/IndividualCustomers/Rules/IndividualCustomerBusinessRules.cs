using BankApp.Application.Services.Repositories;
using BankApp.Core.CrossCuttingConcerns.Exceptions;

namespace BankApp.Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;

    public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public async Task IndividualCustomerShouldExistWhenRequested(Guid id)
    {
        var result = await _individualCustomerRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException("Individual customer not found.");
    }

    public async Task IndividualCustomerShouldExistWhenSelected(Guid id)
    {
        var result = await _individualCustomerRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException("Individual customer not found.");
    }

    public async Task IndividualCustomerNationalIdCanNotBeDuplicatedWhenInserted(string nationalId)
    {
        var result = await _individualCustomerRepository.GetAsync(b => b.NationalId == nationalId);
        if (result != null) throw new BusinessException("Individual customer national ID already exists.");
    }

    public async Task IndividualCustomerEmailCanNotBeDuplicatedWhenInserted(string email)
    {
        var result = await _individualCustomerRepository.GetAsync(b => b.Email == email);
        if (result != null) throw new BusinessException("Individual customer email already exists.");
    }

    public void IndividualCustomerNationalIdShouldBeValid(string nationalId)
    {
        if (string.IsNullOrEmpty(nationalId)) throw new BusinessException("National ID is required.");
        if (nationalId.Length != 11) throw new BusinessException("National ID must be 11 digits.");
        if (!nationalId.All(char.IsDigit)) throw new BusinessException("National ID must contain only digits.");
    }

    public void IndividualCustomerEmailShouldBeValid(string email)
    {
        if (string.IsNullOrEmpty(email)) throw new BusinessException("Email is required.");
        if (!email.Contains("@")) throw new BusinessException("Email must contain @ symbol.");
    }

    public void IndividualCustomerPhoneNumberShouldBeValid(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber)) throw new BusinessException("Phone number is required.");
        if (!phoneNumber.All(char.IsDigit)) throw new BusinessException("Phone number must contain only digits.");
    }

    public void IndividualCustomerDateOfBirthShouldBeValid(DateTime dateOfBirth)
    {
        if (dateOfBirth > DateTime.Now) throw new BusinessException("Date of birth cannot be in the future.");
        if (dateOfBirth < DateTime.Now.AddYears(-100)) throw new BusinessException("Date of birth cannot be more than 100 years ago.");
    }
} 