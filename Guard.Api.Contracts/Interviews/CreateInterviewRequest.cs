using Domain.Shared;

namespace Guard.Api.Contracts.Interviews;

/// <summary>
/// ���������� ��� �������� �������������.
/// </summary>
public class CreateInterviewRequest
{
    /// <summary>
    /// ���� ������.
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// ����� ���������� - �.
    /// </summary>
    public TimeOnly FromTime { get; set; }

    /// <summary>
    /// ����� ���������� - ��.
    /// </summary>
    public TimeOnly ToTime { get; set; }

    /// <summary>
    /// ���� � ������� ����� ���������.
    /// </summary>
    public CareerRole FromRole { get; set; }

    /// <summary>
    /// ���� �� ������� ����� ���������.
    /// </summary>
    public CareerRole ToRole { get; set; }

    /// <summary>
    /// ��� �������������.
    /// </summary>
    public string IntervieweeName { get; set; }
}
