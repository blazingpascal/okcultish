using System;

public interface IUser
{
    string GetFirstName();
    string GetFullName();
    bool TryToConvert(Random random);
    int GetConversionChance();
    void ChangeConversionChance(int delta);
    Gender Gender { get; }
}