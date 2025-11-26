# TEC WEB PROYECTO 
# 🏥 Salud Total – Sistema de Turnos Médicos 

**Salud Total** es una API RESTful desarrollada con **ASP.NET Core 9**. Su propósito es gestionar doctores, pacientes, citas médicas, diagnósticos y consultorios dentro de un sistema clínico moderno.

El objetivo es centralizar la programación de turnos y la información médica, eliminando la gestión manual y los errores frecuentes, ofreciendo una solución **segura, escalable y mantenible**.

---

##  1. Arquitectura del Proyecto

El sistema sigue una **Arquitectura por Capas (Layered Architecture)** para separar responsabilidades y mejorar la mantenibilidad.

###  Capas del Proyecto

| Carpeta        | Responsabilidad                                                |
|----------------|----------------------------------------------------------------|
| **Controller** | Maneja las peticiones HTTP (GET, POST, PUT, DELETE).           |
| **Services**   | Contiene la lógica de negocio y validaciones.                  |
| **Repositories** | Se encarga del acceso a datos usando Entity Framework Core.   |
| **Models**     | Define las entidades del dominio (User, Doctor, Appointment).  |
| **Data**       | Contiene el `AppDbContext` y configuración de la BD.           |
| **DTOs**       | Modelos para transferencia de datos entre capa y capa.         |

##  2. Funcionalidades del Sistema

###  Gestión de Autenticación (Auth)

- Registro de usuarios  
- Inicio de sesión con JWT  
- Refresh Token  
- Logout  
- Roles: `Admin` y `User`

###  Doctores

- Registrar doctor (**Admin**)  
- Editar doctor  
- Listar doctores  
- Consultar por ID  
- Eliminar doctor  
- Relación 1:1 con `User`

###  Pacientes 

- Información básica del paciente  
- Relación 1:1 con `User`  
- Relación con citas médicas y diagnóstico

###  Citas Médicas (Appointments)

- Crear cita (**Admin**)  
- Asignar doctor y paciente  
- Cambiar estado (Pendiente, Confirmada, Cancelada)  
- Actualizar fecha, hora o notas  
- Buscar citas por doctor  
- Buscar citas por paciente  

>  **Nota importante de modelo:**  
> `Appointment` actúa como una **tabla intermedia con atributos**.  
> A nivel de base de datos se modela como:
>
> - Doctor **1:N** Appointment  
> - Patient **1:N** Appointment  
>
> Pero conceptualmente define una relación **N:M entre Doctor y Patient**:
> un doctor puede atender a muchos pacientes y un paciente puede ser atendido por muchos doctores, y cada encuentro se representa con una cita.

###  Diagnóstico 

- Exámenes realizados  
- Tratamiento recomendado  
- Relación 1:1 con `Patient`  

###  Consultorio

- Dirección  
- Equipamiento  
- Relación 1:1 con `Doctor`  

---
