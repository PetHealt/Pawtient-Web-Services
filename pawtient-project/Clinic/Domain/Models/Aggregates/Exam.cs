namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class Exam
{
    public int Id { get; private set; }
    public int ConsultationId { get; private set; }
    public int ExamTypeId { get; private set; }
    public string? Result { get; private set; }
    public string Status { get; private set; }
    public DateOnly? Date { get; private set; }

    public Consultation? Consultation { get; private set; }
    public ExamType? ExamType { get; private set; }

    public Exam() { }

    public Exam(int consultationId, int examTypeId, DateOnly? date)
    {
        ConsultationId = consultationId;
        ExamTypeId = examTypeId;
        Date = date;
        Status = "PENDING";
    }
}