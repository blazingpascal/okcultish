using System;

public interface IUser
{
    String GetFirstName();

    String GetFullName();

    int GetConversionChance();

    void ChangeConversionChance(int delta);
}
