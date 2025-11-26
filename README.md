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

---

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

##  3. Diagrama ER

Basado en el modelo diseñado para **Salud Total**:

### Entidades y Atributos

| Entidad         | Atributos Principales                                                       | Descripción                                  |
|-----------------|-----------------------------------------------------------------------------|----------------------------------------------|
| **User**        | Id, Username, Password, Email, Phone, Role                                  | Credenciales del sistema                     |
| **Doctor**      | DoctorId, UserId, Name, Specialty, Phone                                    | Información del médico                       |
| **Patient**     | PatientId, UserId, Name, Phone                                              | Datos del paciente                           |
| **Appointment** | AppointmentId, DoctorId, PatientId, Date, Time, Reason, Status, Notes       | Cita médica (turno)                          |
| **Diagnostic**  | PatientId (PK), Exams, Treatment                                            | Diagnóstico del paciente                     |
| **Consultorio** | ConsultorioId, ConsultorioName, Address, Equipment                          | Consultorio asignado a un doctor             |

### Relaciones

- **User – Doctor:** 1:1  
- **User – Patient:** 1:1  
- **Doctor – Appointment:** 1:N  
- **Patient – Appointment:** 1:N  
- **Doctor – Patient:** N:M **a través de Appointment**  
- **Patient – Diagnóstico:** 1:1  
- **Doctor – Consultorio:** 1:1  

---

##  4. Autenticación y Autorización (JWT)

El sistema implementa autenticación mediante **JSON Web Tokens**:

### Flujo:

1. El usuario envía email + contraseña  
2. La API valida credenciales  
3. Devuelve **AccessToken** y **RefreshToken**  
4. El token se envía en cada request protegida:

```http
Authorization: Bearer <token>
```
Roles disponibles

Admin → Acceso total (CRUD y administración general)

User → Lectura y operaciones básicas permitidas

---

##  5. EndPoints Principales


---

##  6. Swagger Documentation

El proyecto incluye documentación interactiva con Swagger.

 URL por defecto:
```
http://localhost:5020/swagger
```

Desde ahí se pueden:

- Probar endpoints

- Ver modelos y respuestas

- Autorizar con JWT (botón Authorize)

---

##  7. Instalación y Configuración
Requisitos

- .NET 9 SDK

- PostgreSQL (o Docker)

- Postman (recomendado para pruebas)

**1. Clonar repositorio**
```
git clone https://github.com/RashLop/ProyectoTecWeb.git

cd ProyectoTecWeb
```
**2. Configurar archivo .env**

Ejemplo:
```
DATABASE_HOST=localhost
POSTGRES_DB=Hospitaldb
POSTGRES_USER=Hospitaluser
POSTGRES_PASSWORD=supersecret
POSTGRES_PORT=5432

JWT_KEY=CLAVE_SUPER_SECRETA
JWT_ISSUER=MiApi
JWT_AUDIENCE=MiCliente
JWT_EXPIRES=60
JWT_REFRESH=14
```
**3. Levantar PostgreSQL con Docker**
```
docker run --name hospitaldb -e POSTGRES_DB=Hospitaldb -e POSTGRES_USER=Hospitaluser -e POSTGRES_PASSWORD=supersecret -p 5432:5432 -d postgres:16
```
**4. Ejecutar la API**
```
dotnet run
```
La API estará disponible en:
```
http://localhost:5020
```

---

## 📦 8. Datos de Prueba (Demo)

| Email           | Password   | Rol  |
|-----------------|-----------|-------|
| admin@gmail.com | P@ssw0rd  | Admin |
| user@gmail.com  | User1234  | User  |

---

## 🧪 9. Pruebas en Postman


