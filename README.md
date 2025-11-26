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

