﻿namespace Domain;

public class Supervisor : User
{
    public Supervisor(string password, int id) : base(id, password)
    {
    }
}