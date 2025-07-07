Práctica Programada 2 – SC-701 Programación Avanzada

1. Integrantes del grupo

- Jennifer Soto Mora
- Kevin Emmanuel Chavarría Vargas
- Brayan Daniel Orozco Madrigal
- Jason Hernán Chavarría Ramos

2. https://github.com/JasonChavarriaR/PracticaProgramada2-PrograAvanzadaWeb.git

3. Especificación del Proyecto

a. Arquitectura del Proyecto:
El sistema fue desarrollado siguiendo una arquitectura de múltiples capas, utilizando los siguientes proyectos:
- ApiClientes: Proyecto ASP.NET Core Web API encargado de brindar una API REST para el manejo de clientes y sus teléfonos.
- AppClientesMVC: Aplicación ASP.NET Core (Model-View-Controller) que actúa como el consumidor del API, brindando una interfaz web para manejar el sistema.
- ClientesCore: Biblioteca de clases (.NET) que contiene las entidades, interfaces, repositorios y servicios de lógica de negocio establecidos según lo indicado en el
documento.

b. Librerías o paquetes de NuGet utilizados:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.AspNetCore.Mvc.NewtonsoftJson
- Swashbuckle.AspNetCore
- System.Net.Http.Json

c. Principios de SOLID y patrones de diseño utilizados:

- Single Responsibility: Cada clase posee una sola obligación.
- Open/Closed: Es posible ampliar los servicios y repositorios sin alterar los ya existentes.
- Liskov Substitution: Las interfaces pueden reemplazarse por sus versiones implementadas sin alterar su funcionalidad.
- Interface Segregation: División entre las interfaces de repositorios y servicios para preservar contratos transparentes.
- Dependency Inversion: La API está vinculada a las interfaces.

Patrones:
- Repository Pattern: Organiza la entrada de datos a través de clases como "ClienteRepository".
- Service Layer: La estrategia empresarial se encuentra encapsulada en los términos "ClienteService" y "TelefonoService".
- Dependency Injection: Se inyectan todos los servicios y repositorios a través del contenedor de servicios en "Program.cs".