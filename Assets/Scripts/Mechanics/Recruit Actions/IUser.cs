using System;
using System.Collections.Generic;
using UnityEngine.UI;

public interface IUser
{
    string GetFirstName();
    string GetFullName();
    bool TryToConvert(Random random);
    int GetConversionChance();
    void ChangeConversionChance(int delta);
	double Distance { get; }
}