﻿namespace Guard.Bot.Integrations.GuardApi.DTOs;

public class RegisterDto
{
    public string Name { get; set; }
    public string Password { get; set; }
    public int Validator { get; set; }
}