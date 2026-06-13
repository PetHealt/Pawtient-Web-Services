# Pendiente de implementar — Pawtient Web Services

Lo que falta completar por Bounded Context siguiendo el patrón del proyecto del profesor `learning-center-platform`.

---

## Patrón a seguir por cada Bounded Context

```
BoundedContext/
├── Application/
│   ├── CommandServices/        # IXCommandService (interfaz)
│   ├── QueryServices/          # IXQueryService (interfaz)
│   └── Internal/
│       ├── CommandServices/    # XCommandService (implementación con lógica)
│       └── QueryServices/      # XQueryService (implementación con lógica)
└── Interfaces/
    └── Rest/
        ├── Resources/          # DTOs de entrada y salida
        ├── Transform/          # Assemblers entidad → resource
        └── XController.cs      # Endpoints REST
```

---

## IAM Bounded Context

### Application
- [ ] `IAM/Application/CommandServices/IUserCommandService.cs`
- [ ] `IAM/Application/QueryServices/IUserQueryService.cs`
- [ ] `IAM/Application/Internal/CommandServices/UserCommandService.cs`
- [ ] `IAM/Application/Internal/QueryServices/UserQueryService.cs`

### Interfaces
- [ ] `IAM/Interfaces/Rest/Resources/UserResource.cs`
- [ ] `IAM/Interfaces/Rest/Resources/CreateUserResource.cs`
- [ ] `IAM/Interfaces/Rest/Transform/UserResourceFromEntityAssembler.cs`
- [ ] `IAM/Interfaces/Rest/UsersController.cs` *(actualizar para usar Service)*

---

## Profiles Bounded Context

### Application
- [ ] `Profiles/Application/CommandServices/IVeterinarianCommandService.cs`
- [ ] `Profiles/Application/CommandServices/IClinicCommandService.cs`
- [ ] `Profiles/Application/QueryServices/IVeterinarianQueryService.cs`
- [ ] `Profiles/Application/QueryServices/IClinicQueryService.cs`
- [ ] `Profiles/Application/Internal/CommandServices/VeterinarianCommandService.cs`
- [ ] `Profiles/Application/Internal/CommandServices/ClinicCommandService.cs`
- [ ] `Profiles/Application/Internal/QueryServices/VeterinarianQueryService.cs`
- [ ] `Profiles/Application/Internal/QueryServices/ClinicQueryService.cs`

### Interfaces
- [ ] `Profiles/Interfaces/Rest/Resources/VeterinarianResource.cs`
- [ ] `Profiles/Interfaces/Rest/Resources/CreateVeterinarianResource.cs`
- [ ] `Profiles/Interfaces/Rest/Resources/ClinicResource.cs`
- [ ] `Profiles/Interfaces/Rest/Resources/CreateClinicResource.cs`
- [ ] `Profiles/Interfaces/Rest/Transform/VeterinarianResourceFromEntityAssembler.cs`
- [ ] `Profiles/Interfaces/Rest/Transform/ClinicResourceFromEntityAssembler.cs`
- [ ] `Profiles/Interfaces/Rest/VeterinariansController.cs`
- [ ] `Profiles/Interfaces/Rest/ClinicsController.cs`

---

## Clinic Bounded Context

### Application
- [ ] `Clinic/Application/CommandServices/IPetCommandService.cs`
- [ ] `Clinic/Application/CommandServices/IConsultationCommandService.cs`
- [ ] `Clinic/Application/CommandServices/IVaccineCommandService.cs`
- [ ] `Clinic/Application/QueryServices/IPetQueryService.cs`
- [ ] `Clinic/Application/QueryServices/IConsultationQueryService.cs`
- [ ] `Clinic/Application/QueryServices/IVaccineQueryService.cs`
- [ ] `Clinic/Application/Internal/CommandServices/PetCommandService.cs`
- [ ] `Clinic/Application/Internal/CommandServices/ConsultationCommandService.cs`
- [ ] `Clinic/Application/Internal/CommandServices/VaccineCommandService.cs`
- [ ] `Clinic/Application/Internal/QueryServices/PetQueryService.cs`
- [ ] `Clinic/Application/Internal/QueryServices/ConsultationQueryService.cs`
- [ ] `Clinic/Application/Internal/QueryServices/VaccineQueryService.cs`

### Interfaces
- [ ] `Clinic/Interfaces/Rest/Resources/PetResource.cs`
- [ ] `Clinic/Interfaces/Rest/Resources/CreatePetResource.cs`
- [ ] `Clinic/Interfaces/Rest/Resources/ConsultationResource.cs`
- [ ] `Clinic/Interfaces/Rest/Resources/CreateConsultationResource.cs`
- [ ] `Clinic/Interfaces/Rest/Resources/VaccineResource.cs`
- [ ] `Clinic/Interfaces/Rest/Resources/CreateVaccineResource.cs`
- [ ] `Clinic/Interfaces/Rest/Transform/PetResourceFromEntityAssembler.cs`
- [ ] `Clinic/Interfaces/Rest/Transform/ConsultationResourceFromEntityAssembler.cs`
- [ ] `Clinic/Interfaces/Rest/Transform/VaccineResourceFromEntityAssembler.cs`
- [ ] `Clinic/Interfaces/Rest/PetsController.cs`
- [ ] `Clinic/Interfaces/Rest/ConsultationsController.cs`
- [ ] `Clinic/Interfaces/Rest/VaccinesController.cs`

---

## Appointment Bounded Context

### Application
- [ ] `Appointment/Application/CommandServices/IAppointmentCommandService.cs`
- [ ] `Appointment/Application/CommandServices/IScheduleCommandService.cs`
- [ ] `Appointment/Application/QueryServices/IAppointmentQueryService.cs`
- [ ] `Appointment/Application/QueryServices/IScheduleQueryService.cs`
- [ ] `Appointment/Application/Internal/CommandServices/AppointmentCommandService.cs`
- [ ] `Appointment/Application/Internal/CommandServices/ScheduleCommandService.cs`
- [ ] `Appointment/Application/Internal/QueryServices/AppointmentQueryService.cs`
- [ ] `Appointment/Application/Internal/QueryServices/ScheduleQueryService.cs`

### Interfaces
- [ ] `Appointment/Interfaces/Rest/Resources/AppointmentResource.cs`
- [ ] `Appointment/Interfaces/Rest/Resources/CreateAppointmentResource.cs`
- [ ] `Appointment/Interfaces/Rest/Resources/ScheduleResource.cs`
- [ ] `Appointment/Interfaces/Rest/Resources/CreateScheduleResource.cs`
- [ ] `Appointment/Interfaces/Rest/Transform/AppointmentResourceFromEntityAssembler.cs`
- [ ] `Appointment/Interfaces/Rest/Transform/ScheduleResourceFromEntityAssembler.cs`
- [ ] `Appointment/Interfaces/Rest/AppointmentsController.cs`
- [ ] `Appointment/Interfaces/Rest/SchedulesController.cs`

---

## Store Bounded Context

### Application
- [ ] `Store/Application/CommandServices/IProductCommandService.cs`
- [ ] `Store/Application/CommandServices/ISupplierCommandService.cs`
- [ ] `Store/Application/QueryServices/IProductQueryService.cs`
- [ ] `Store/Application/QueryServices/ISupplierQueryService.cs`
- [ ] `Store/Application/Internal/CommandServices/ProductCommandService.cs`
- [ ] `Store/Application/Internal/CommandServices/SupplierCommandService.cs`
- [ ] `Store/Application/Internal/QueryServices/ProductQueryService.cs`
- [ ] `Store/Application/Internal/QueryServices/SupplierQueryService.cs`

### Interfaces
- [ ] `Store/Interfaces/Rest/Resources/ProductResource.cs`
- [ ] `Store/Interfaces/Rest/Resources/CreateProductResource.cs`
- [ ] `Store/Interfaces/Rest/Resources/SupplierResource.cs`
- [ ] `Store/Interfaces/Rest/Resources/CreateSupplierResource.cs`
- [ ] `Store/Interfaces/Rest/Transform/ProductResourceFromEntityAssembler.cs`
- [ ] `Store/Interfaces/Rest/Transform/SupplierResourceFromEntityAssembler.cs`
- [ ] `Store/Interfaces/Rest/ProductsController.cs`
- [ ] `Store/Interfaces/Rest/SuppliersController.cs`

---

## Report Bounded Context

### Application
- [ ] `Report/Application/CommandServices/IInvoiceCommandService.cs`
- [ ] `Report/Application/QueryServices/IInvoiceQueryService.cs`
- [ ] `Report/Application/QueryServices/IConsultationReportQueryService.cs`
- [ ] `Report/Application/QueryServices/IInventoryReportQueryService.cs`
- [ ] `Report/Application/QueryServices/IAppointmentReportQueryService.cs`
- [ ] `Report/Application/Internal/CommandServices/InvoiceCommandService.cs`
- [ ] `Report/Application/Internal/QueryServices/InvoiceQueryService.cs`
- [ ] `Report/Application/Internal/QueryServices/ConsultationReportQueryService.cs`
- [ ] `Report/Application/Internal/QueryServices/InventoryReportQueryService.cs`
- [ ] `Report/Application/Internal/QueryServices/AppointmentReportQueryService.cs`

### Interfaces
- [ ] `Report/Interfaces/Rest/Resources/InvoiceResource.cs`
- [ ] `Report/Interfaces/Rest/Resources/CreateInvoiceResource.cs`
- [ ] `Report/Interfaces/Rest/Transform/InvoiceResourceFromEntityAssembler.cs`
- [ ] `Report/Interfaces/Rest/InvoicesController.cs`

