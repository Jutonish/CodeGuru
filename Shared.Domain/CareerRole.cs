﻿using EnumsNET;
using System.ComponentModel;

namespace Shared.Domain;

public enum CareerRole
{
    [Description("Опыт не ивестен")]
    Unknown = 0,

    [Description("Amateur")]
    Amateur = 1,

    [Description("Amateur+")]
    AmateurPlus = 11,

    [Description("Intern")]
    Intern = 2,

    [Description("Intern+")]
    InternPlus = 22,

    [Description("Junior")]
    Junior = 3,

    [Description("Middle")]
    Middle = 4,

    [Description("Senior")]
    Senior = 5,
}

public static class CareerRoleExtensions
{
    /// <summary>
    /// Повысить роль по прохождению собеседования.
    /// </summary>
    /// <param name="role">Роль которую требуеются забустить.</param>
    /// <returns>Следующую роль, которая выдается после прохождения собеседования.</returns>
    /// <exception cref="ArgumentException">Роль нельзя забустить.</exception>
    public static CareerRole BoostByInterview(this CareerRole role)
    {
        if(role is CareerRole.Amateur)
            return CareerRole.AmateurPlus;

        if (role is CareerRole.AmateurPlus)
            return CareerRole.Intern;

        if (role is CareerRole.Intern)
            return CareerRole.InternPlus;

        throw new ArgumentException("Роль нельзя забустить");
    }

    /// <summary>
    /// Получить реальное название роли.
    /// </summary>
    public static string GetRealName(this CareerRole role)
    {
        return role.AsString(EnumFormat.Description)!;
    }
}