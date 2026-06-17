namespace pawtient_project.Report.Interfaces.Rest.Resources;

public record ReportSummaryResource(
    decimal TotalRevenue,
    decimal TotalExpenses,
    decimal NetProfit,
    int LowStockAlerts,
    int TotalAppointments
    );