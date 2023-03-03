using Asteroids.Model;
using System;
using System.Collections.Generic;

public class Army
{
    private List<Nlo> _nlo;

    public Army()
    {
        _nlo = new List<Nlo>();
    }

    public Nlo GetFreeNLO()
    {
        foreach (Nlo nlo in _nlo)
        {
            if (nlo.InFight == false)
                return nlo;
        }
        return null;
    }

    public void AddNewNLO(Nlo nlo)
    {
        if (_nlo.Contains(nlo))
            return;

        if (nlo.InArmy)
            return;

        _nlo.Add(nlo);
        nlo.Destroying += () => RemoveMlo(nlo);
        nlo.SetArmy();
    }

    private void RemoveMlo(Nlo nlo)
    {
        if (!_nlo.Contains(nlo))
            return;
        _nlo.Remove(nlo);
    }
}