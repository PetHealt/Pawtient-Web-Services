namespace pawtient_project.Report.Interfaces.Rest.Resources;

public record ReportSummaryResource(
    decimal TotalIncome,
    decimal NetProfit,
    int InventoryAlerts);
